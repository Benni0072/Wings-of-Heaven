using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepPlayer : MonoBehaviour
{
    public EventInstance FootstepInstance;
    //2. Möglichkeiten
    //event path
    //public string AtmoEventPath;
    //event reference
    public EventReference FootstepEvent;

    public string DefaultSound = "Forest";
    public string WoodSound = "Wood";

    // Start is called before the first frame update
    void Start()
    {
        FootstepInstance = RuntimeManager.CreateInstance(FootstepEvent);
    }

    public void PlayFootstep()
    {
        FootstepInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform));
        FootstepInstance.start();
        //RuntimeManager.PlayOneShot(FootstepEvent, transform.position);
    }

}