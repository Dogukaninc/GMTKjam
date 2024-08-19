using AI.Base.Interfaces;
using UnityEngine;

namespace _Main.Project.Scripts.NPC.States
{
    public class EnemyPatrolState : IState
    {
        private Enemy _enemy;
        public EnemyPatrolState(Enemy enemy)
        {
            this._enemy = enemy;
        }
        
        public void Tick()
        {
        }

        public void OnEnter()
        {
            Debug.Log("Enemy Patrol State'ine girdim");
        }

        public void OnExit()
        {
        }
    }
}