using AI.Base.Interfaces;
using UnityEngine;

namespace _Main.Project.Scripts.NPC.States
{
    public class EnemyAttackState : IState
    {
        private Enemy _enemy;
        public EnemyAttackState(Enemy enemy)
        {
            this._enemy = enemy;
        }
        public void Tick()
        {
            throw new System.NotImplementedException();
        }

        public void OnEnter()
        {
            Debug.Log("Enemy Attack State'ine girdim");

        }

        public void OnExit()
        {
            throw new System.NotImplementedException();
        }
    }
}