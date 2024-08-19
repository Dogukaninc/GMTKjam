using System;
using _Main.Project.Scripts.NPC;
using _Main.Project.Scripts.NPC.States;
using AI.Base;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

namespace Character.EnemyRuntime
{
    public class NPCController : MonoBehaviour
    {
        private StateMachine _activeStateMachine;

        // private NPCAnimatorController _npcAnimatorController;
        private Enemy _enemy;

        private bool _isIdleCharacter;
        private BoxCollider _patrolAreaCollider;

        public bool isDead;
        public bool isPatrolling;

        private void Awake()
        {
            _enemy = GetComponentInParent<Enemy>();
        }

        private void Start()
        {
            SetEnemyStates();
        }

        #region States

        private void SetEnemyStates()
        {
            _activeStateMachine = new StateMachine();

            var _idle = new EnemyIdleState(_enemy);
            var patrol = new EnemyPatrolState(_enemy); //TODO-> eger state içerisinde ulaşmak istediğim bir componenti varsa enemy'nin burdan construct ederek ulaşıcam
            var attack = new EnemyAttackState(_enemy);

            #region State Changing Conditions

            Func<bool> Patrolling() => () => !isDead && isPatrolling; //TODO-> Buraya geçiş koşulları atanacak
            Func<bool> AttackToPlayer() => () => !isDead && _enemy.isEnemyDetectedPlayer;
            Func<bool> UnDetectPlayer() => () => !_enemy.isEnemyDetectedPlayer;

            #endregion

            #region Transitions

            _activeStateMachine.AddTransition(_idle, patrol, Patrolling()); //TODO-> Buraya geçişler atanacak
            _activeStateMachine.AddTransition(attack, patrol,UnDetectPlayer());
            _activeStateMachine.AddTransition(patrol, attack,AttackToPlayer());

            #endregion

            _activeStateMachine.SetState(_idle);
        }

        #endregion

        private void Update()
        {
            _activeStateMachine.Tick();
        }
    }
}