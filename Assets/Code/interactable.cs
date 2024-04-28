using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour
{
    private MeshRenderer renderer;

    public DialogDisplay DialogDisplay;
    public DialogItem Item;

    public Material NormalMaterial;
    public Material HighlightMaterial;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    public void Interact()
    {
        DialogDisplay.StartDialog(Item);

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

    public void SetDialog(DialogItem newItem)
    {
        Item = newItem;
    }

}
