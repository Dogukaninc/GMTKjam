using System;
using UnityEngine;

namespace _Main.Project.Scripts.NPC
{
    public class EnemyTriggerDetection : MonoBehaviour
    {
        /// <summary>
        /// Eğer Player bu collider içerisinde girdiyse saldırma durumuna geç
        /// Eğer oyuncu bu collider dışına çıkarsa bir süre sonra saldırma durumundan çık
        /// Ama enemy de navmesh falan yok o nedenle saldırıyı sadece bir alan içinde yapabilir
        /// </summary>
        /// <param name="other"></param>
        [SerializeField] private Enemy _enemy;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _enemy.isEnemyDetectedPlayer = true;
                Debug.Log("isEnemyDetectedPlayer:" + _enemy.isEnemyDetectedPlayer);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _enemy.isEnemyDetectedPlayer = false;
                Debug.Log("isEnemyDetectedPlayer:" + _enemy.isEnemyDetectedPlayer);
            }
        }
    }
}