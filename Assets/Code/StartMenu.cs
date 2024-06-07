using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    EventInstance musicInstance;

    public EventReference MusicEvent;

    // Start is called before the first frame update
    void Start()
    {
        musicInstance = RuntimeManager.CreateInstance(MusicEvent);
        musicInstance.start();
    }

    public void StartGame()
    {
        // musicInstance.setParameterByNameWithLabel("Scene", "Level");

        SceneManager.LoadScene(1);
    }

    public void MuteAudio(bool muted)
    {
        RuntimeManager.MuteAllEvents(muted);
    }


}
