using AI.Base.Interfaces;
using UnityEngine;

namespace _Main.Project.Scripts.NPC.States
{
    public class EnemyIdleState : IState
    {
        private Enemy _enemy;
        public EnemyIdleState(Enemy enemy)
        {
            this._enemy = enemy;
        }
        public void Tick()
        {
            
        }

        public void OnEnter()
        {
            Debug.Log("Enemy Idle State'ine girdim");
        }

        public void OnExit()
        {
        }
    }
}