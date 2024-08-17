using System;
using AI.Base;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

namespace Character.EnemyRuntime
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NPCController : MonoBehaviour
    {
        [field: SerializeField] public TextMeshProUGUI EnemyInventoryWeightText { get; private set; }

        private StateMachine _enemyStateMachine;
        private StateMachine _curedStateMachine;
        private StateMachine _activeStateMachine;
        // private NPCAnimatorController _npcAnimatorController;

        public NavMeshAgent NavmeshAgent { get; private set; }

        private bool _isIdleCharacter;
        private BoxCollider _patrolAreaCollider;

        // private Idle _idle;
        // private NPCVFXController _vfxController;

        private void Awake()
        {
            CollectComponents();
        }

        private void Start()
        { 
            // SetEnemyStates();
            _activeStateMachine = _enemyStateMachine;
        }

        private void CollectComponents()
        {
            NavmeshAgent = GetComponent<NavMeshAgent>();
            // _enemyBeingCaughtSystem = GetComponent<EnemyBeingCaughtSystem>();
            // _npcAnimatorController = GetComponent<NPCAnimatorController>();
            // Stack = GetComponent<ObjectItemsHandler>();
            // _vfxController = GetComponent<NPCVFXController>();
        }

        /*
        public void SetSpawnedValues(bool isIdleCharacter, BoxCollider patrolAreaCollider, NPCSO npcSO, Areas.Level connectedLevel)
        {
            _isIdleCharacter = isIdleCharacter;
            _patrolAreaCollider = patrolAreaCollider;
            NPCSO = npcSO;
            _connectedLevel = connectedLevel;
            _enemyBeingCaughtSystem.NpcSo = npcSO;
        }
        #region States
        */

        /*
        private void SetEnemyStates()
        {
            _enemyStateMachine = new StateMachine();

            _idle = new Idle(this, NavmeshAgent, _npcAnimatorController);
            var patrol = new Patrol(this, NavmeshAgent, _npcAnimatorController, _patrolAreaCollider);
            var beingCaught = new BeingCaught(this, NavmeshAgent, _npcAnimatorController, _enemyBeingCaughtSystem, _connectedLevel.walkableAreas, NPCSO);
            var caught = new Caught(NavmeshAgent, _npcAnimatorController, this, _vfxController, _enemyBeingCaughtSystem);

            #region State Changing Conditions

            Func<bool> DetectedByPlayer() => () => _enemyBeingCaughtSystem.IsStillDetected && !_enemyBeingCaughtSystem.IsDead;
            Func<bool> DetectionEndedAndNotDead() => () => !_enemyBeingCaughtSystem.IsDead && !_enemyBeingCaughtSystem.IsStillDetected;
            Func<bool> IdleTimerReachedMaximum() => () => !_isIdleCharacter && _idle.OnIdleTimer >= 1f && !_enemyBeingCaughtSystem.IsStillDetected;
            Func<bool> IsDead() => () => _enemyBeingCaughtSystem.IsDead || _enemyBeingCaughtSystem.IsCatchingSequenceStarted;
            Func<bool> IsPatrolDestinationReached() => () => !_enemyBeingCaughtSystem.IsDead && NavmeshAgent.enabled && NavmeshAgent.remainingDistance <= 0.5f;

            #endregion

            #region Transitions

            _enemyStateMachine.AddTransition(_idle, beingCaught, DetectedByPlayer());
            _enemyStateMachine.AddTransition(_idle, patrol, IdleTimerReachedMaximum());
            _enemyStateMachine.AddTransition(patrol, _idle, IsPatrolDestinationReached());
            _enemyStateMachine.AddTransition(patrol, beingCaught, DetectedByPlayer());
            _enemyStateMachine.AddTransition(beingCaught, patrol, DetectionEndedAndNotDead());
            _enemyStateMachine.AddTransition(beingCaught, caught, IsDead());

            #endregion

            _enemyStateMachine.SetState(_idle);
        }

        #endregion
        */
        private void Update()
        {
            _activeStateMachine.Tick();
        }
    }
}