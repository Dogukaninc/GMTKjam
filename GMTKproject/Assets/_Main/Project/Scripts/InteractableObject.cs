using System.Collections;
using System.Collections.Generic;
using _Main.Project.Scripts.Interfaces;
using UnityEngine;

public class InteractableObject : MonoBehaviour,IDetectable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDetectionStarted()
    {
        Debug.Log("Detection Started");
    }

    public void OnDetectionEnded()
    {
        Debug.Log("Detection Ended");
    }
}
