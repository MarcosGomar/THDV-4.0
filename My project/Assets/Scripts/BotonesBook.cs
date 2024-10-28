using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesBook : MonoBehaviour
{
    public void Volver()
    {
        SceneManager.LoadScene("Main Menu");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

}
