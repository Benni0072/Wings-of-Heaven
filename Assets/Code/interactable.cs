using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class interactable : MonoBehaviour
{
    private MeshRenderer renderer;


    public Material NormalMaterial;
    public Material HighlightMaterial;

    public UnityEvent OnInteracted;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    public void Interact()
    {
        OnInteracted.Invoke();

        //DialogScreen.StartDialog(Item);
    }

    public void Highlight()
    {
        renderer.material = HighlightMaterial;
    }

    public void Unhighlight()
    {
        renderer.material = NormalMaterial;
    }

}
