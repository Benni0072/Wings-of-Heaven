using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public static EventInstance MusicInstance;

    public EventReference MusicEvent;

    //_____________________________________________________________________

    // Start is called before the first frame update
    void Start()
    {
        if (!MusicInstance.hasHandle())
        {
            MusicInstance = RuntimeManager.CreateInstance(MusicEvent);
            MusicInstance.start();
        }
    }


    public void StartGame()
    {
        MusicInstance.setParameterByNameWithLabel("Scene", "Level");

        SceneManager.LoadScene(1);
    }
    public void EndGame()
    {
        MusicInstance.setParameterByNameWithLabel("Scene", "End-Cutscene");

        SceneManager.LoadScene(2);
    }

    public void MuteAudio(bool muted)
    {
        RuntimeManager.MuteAllEvents(muted);
    }


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }


}
