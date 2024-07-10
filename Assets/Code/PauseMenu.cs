using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject PauseContainer;

    public UnityEvent<bool> PauseOpen;




    public void PauseGame()
    {
        PauseContainer.SetActive(true);
        PauseOpen.Invoke(true);
    }

    public void ToMenu()
    {
      //MusicInstance.setParameterByNameWithLabel("Scene", "End-Cutscene");
        StartMenu.MusicInstance.setParameterByNameWithLabel("Scene", "Menu");

        SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        PauseContainer.SetActive(false);
        PauseOpen.Invoke(false);
    }


    public void MuteAudio(bool muted)
    {
        RuntimeManager.MuteAllEvents(muted);
    }


}
