using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject PauseContainer;




    public void PauseGame()
    {
        
        PauseContainer.SetActive(true);

    }

    public void ToMenu()
    {

        SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        PauseContainer.SetActive(false);
    }
}
