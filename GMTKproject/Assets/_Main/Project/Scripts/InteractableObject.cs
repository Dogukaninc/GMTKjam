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

    /// <summary>
    /// Takes keycode param for interactable object's type
    /// </summary>
    /// <param name="keycode"></param>
    public void OnDetectionStarted()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Detection Started");
        }
    }

}
