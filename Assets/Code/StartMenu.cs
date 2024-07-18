using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    //const = konstant
    //nachdem der Konstante einen Wert gegeben wird, darf dieser Wert nicht geändert werden (im Runtime)
    string masterVolumePref = "MasterVolume";

    //___________________________________________________________________

    public static EventInstance MusicInstance;

    public EventReference MusicEvent;

    public Slider MasterSlider;

    public Slider MusicSlider;

    public Slider AmbienceSlider;

    public Slider SfxSlider;

    static bool hasLoadingScreen;

    //_____________________________________________________________________

    // Start is called before the first frame update
    void Start()
    {
        if(!hasLoadingScreen)
        SceneManager.LoadScene (3, LoadSceneMode.Additive);
        hasLoadingScreen = true; 

        if (!MusicInstance.hasHandle())
        {
            MusicInstance = RuntimeManager.CreateInstance(MusicEvent);
            MusicInstance.start();
        }

        MasterSlider.onValueChanged.AddListener(MasterSliderChanged);
        MusicSlider.onValueChanged.AddListener(MusicSliderChanged);
        AmbienceSlider.onValueChanged.AddListener(AmbienceSliderChanged);
        SfxSlider.onValueChanged.AddListener(SfxSliderChanged);

        MasterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        AmbienceSlider.value = PlayerPrefs.GetFloat("AmbienceVolume");
        SfxSlider.value = PlayerPrefs.GetFloat("SfxVolume");

        //Code für selected object
        //UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject.(MasterSlider.gameObject);
    }


    public void StartGame()
    {
        MusicInstance.setParameterByNameWithLabel("Scene", "Level");

        FindAnyObjectByType<LoadingManager>(FindObjectsInactive.Include).UnloadAndLoad(0, 1);
    }
    public void EndGame()
    {
        MusicInstance.setParameterByNameWithLabel("Scene", "End-Cutscene");

        SceneManager.LoadScene(2);
    }

    


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void MasterSliderChanged(float value)
    {
        //nur eins von beiden:

        //RuntimeManager.GetBus("bus:/").setVolume(value);   //zwischen 0 und 1

        //VCA
        RuntimeManager.GetVCA("vca:/Master").setVolume(value);

        PlayerPrefs.SetFloat("MasterVolume", value);
    }

    public void MusicSliderChanged(float value)
    {

        RuntimeManager.GetVCA("vca:/Music").setVolume(value);

        PlayerPrefs.SetFloat("MusicVolume", value);
    }
    public void AmbienceSliderChanged(float value)
    {

        RuntimeManager.GetVCA("vca:/Ambience").setVolume(value);

        PlayerPrefs.SetFloat("AmbienceVolume", value);
    }
    public void SfxSliderChanged(float value)
    {

        RuntimeManager.GetVCA("vca:/SFX").setVolume(value);

        PlayerPrefs.SetFloat("SfxVolume", value);
    }
}
