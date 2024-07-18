using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false); 
    }

    public void UnloadAndLoad(int unload, int load)
    {
        gameObject.SetActive(true);
        StartCoroutine(LoadingCoroutine(unload, load));
    }

    IEnumerator LoadingCoroutine(int unload, int load)
    {

        AsyncOperation op = SceneManager.UnloadSceneAsync(unload);


        //warte 2sec
        //yield return new WaitForSeconds(2f);

        //1 Frame warten
        //yield return null;

        //solange op is NICHT done, werden die Coroutine 1 Frame pausiert
        while (!op.isDone)
        {
            yield return null;
        }

        yield return new WaitForSeconds(3f);
        //entläd alle offenen Scenen
        //SceneManager.LoadScene(0);



        //lädt ohne Scene entfärnen


        op = SceneManager.LoadSceneAsync(load, LoadSceneMode.Additive);

        while (!op.isDone)
        {
            yield return null;
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(load));

        gameObject.SetActive(false);
    }
}
