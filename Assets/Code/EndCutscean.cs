using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCutscean : MonoBehaviour
{

    static bool hasLoadingScreen;

    // Start is called before the first frame update
    void Start()
    {
        if (!hasLoadingScreen)
            SceneManager.LoadScene(3, LoadSceneMode.Additive);
        hasLoadingScreen = true;
    }

    public void ToMenu()
    {
        //MusicInstance.setParameterByNameWithLabel("Scene", "End-Cutscene");
        StartMenu.MusicInstance.setParameterByNameWithLabel("Scene", "Menu");


        LoadingManager manager = FindObjectOfType<LoadingManager>(true);
        manager.UnloadAndLoad(2, 0);

    }
}
