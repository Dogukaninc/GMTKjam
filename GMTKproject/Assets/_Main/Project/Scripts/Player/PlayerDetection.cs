using System;
using System.Collections;
using System.Collections.Generic;
using _Main.Project.Scripts.Interfaces;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    private Collider2D[] detectedColliders = new Collider2D[10];
    private GameObject closestObject;
    [SerializeField] private float detectionRadius;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private GameObject interactionPanel;

    private void Update()
    {
        var detectionCount = Physics2D.OverlapCircleNonAlloc(transform.position, detectionRadius, detectedColliders, ~_layerMask);

        if (detectionCount > 0)
        {
            closestObject = DetectClosestInteractable(detectionCount);
            if (closestObject.TryGetComponent(out IDetectable detectable))
            {
                detectable.OnDetectionStarted();
                SetInteractionPanel(closestObject.transform.position + new Vector3(0, 2, 0));
                closestObject.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                interactionPanel.gameObject.SetActive(false);
            }
        }
    }

    private GameObject DetectClosestInteractable(int detectionCount)
    {
        float minDistance = float.MaxValue;
        GameObject closest = null;

        for (int i = 0; i < detectionCount; i++)
        {
            float distance = Vector3.Distance(transform.position, detectedColliders[i].transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                closest = detectedColliders[i].gameObject;
            }
        }

        return closest;
    }

    private void SetInteractionPanel(Vector3 target)
    {
        interactionPanel.gameObject.SetActive(true);
        interactionPanel.transform.position = target;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}