using System;
using _Main.Project.Scripts.NPC.States;
using AI.Base;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

namespace Character.EnemyRuntime
{
    public class NPCController : MonoBehaviour
    {
        private StateMachine _enemyStateMachine;
        private StateMachine _activeStateMachine;
        // private NPCAnimatorController _npcAnimatorController;


        private bool _isIdleCharacter;
        private BoxCollider _patrolAreaCollider;

        private EnemyIdleState _idle;

        private void Awake()
        {
            
        }

        private void Start()
        {
            SetEnemyStates();
            _activeStateMachine = _enemyStateMachine;
        }

        #region States

        private void SetEnemyStates()
        {
            _enemyStateMachine = new StateMachine();

            //_idle = new Idle(this, NavmeshAgent, _npcAnimatorController);
            // var patrol = new Patrol(this, NavmeshAgent, _npcAnimatorController, _patrolAreaCollider);

            #region State Changing Conditions

            //Func<bool> PlayerDetected() => () => ;//TODO-> Buraya geçiş koşulları atanacak

            #endregion

            #region Transitions

            //_enemyStateMachine.AddTransition(_idle, beingCaught, DetectedByPlayer());//TODO-> Buraya geçişler atanacak

            #endregion

            _enemyStateMachine.SetState(_idle);
        }

        #endregion

        private void Update()
        {
            _activeStateMachine.Tick();
        }
    }
}