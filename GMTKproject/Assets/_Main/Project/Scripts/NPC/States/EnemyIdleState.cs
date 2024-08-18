using AI.Base.Interfaces;
using UnityEngine;

namespace _Main.Project.Scripts.NPC.States
{
    public class EnemyIdleState : IState
    {
        /// <summary>
        /// Enemy bu state de olduğu yerde durup bekleyecek nefes alıp verecek
        /// bu state e genelde patrol olurken target pointlere geldiğinde bir süre beklemek için girecek
        /// </summary>
        public void Tick()
        {
        }

        public void OnEnter()
        {
        }

        public void OnExit()
        {
        }
    }
}