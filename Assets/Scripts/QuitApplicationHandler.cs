using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplicationHandler : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Clicamos em ESC");
        }
    }
}
