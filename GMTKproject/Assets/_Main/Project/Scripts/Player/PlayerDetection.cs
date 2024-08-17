using System;
using System.Collections;
using System.Collections.Generic;
using _Main.Project.Scripts.Interfaces;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    private Collider[] detectedColliders;

    private void Update()
    {
        var detection = Physics.OverlapSphereNonAlloc(transform.position, 1, detectedColliders);
        if (detection > 0)
        {
            for (int i = 0; i < detection; i++)
            {
                float minDistance = 0;
                minDistance = Vector3.Distance(transform.position, detectedColliders[i].transform.position);
                if (Vector3.Distance(transform.position, detectedColliders[i].transform.position) < 2)
                {
                    
                }
            }
        }
    }
}