using System.Collections;
using System.Collections.Generic;
using _Main.Project.Scripts.Interfaces;
using UnityEngine;

public class InteractableObject : MonoBehaviour,IDetectable
{

    /// <summary>
    /// Takes keycode param for interactable object's type
    /// </summary>
    /// <param name="keycode"></param>
    public void OnDetected()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Detection Started");
        }
    }

}
