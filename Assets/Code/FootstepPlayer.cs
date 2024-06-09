using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepPlayer : MonoBehaviour
{

    //2. Möglichkeiten
    //event path
    //public string AtmoEventPath;
    //event reference
    public EventReference FootstepEvent;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void PlayFootstep()
    {
        RuntimeManager.PlayOneShot(FootstepEvent, transform.position);
    }
}