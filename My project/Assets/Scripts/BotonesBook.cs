using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesBookFlow : MonoBehaviour
{
    public void Volver()
    {
        SceneManager.LoadScene("Main Menu");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

}
