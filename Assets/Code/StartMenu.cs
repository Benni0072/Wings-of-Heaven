using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public static EventInstance musicInstance;

    public EventReference MusicEvent;

    //_____________________________________________________________________

    // Start is called before the first frame update
    void Start()
    {
        if (!musicInstance.hasHandle())
        {
            musicInstance = RuntimeManager.CreateInstance(MusicEvent);
            musicInstance.start();
        }
    }


    public void StartGame()
    {
         musicInstance.setParameterByNameWithLabel("Scene", "Level");

        SceneManager.LoadScene(1);
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
