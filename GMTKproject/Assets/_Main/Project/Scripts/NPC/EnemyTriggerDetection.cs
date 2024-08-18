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
        private void OnTriggerEnter(Collider other)
        {
        }

        private void OnTriggerExit(Collider other)
        {
            
        }
    }
}