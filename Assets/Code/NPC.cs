using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC : MonoBehaviour
{

    public DialogDisplay DialogDisplay;
    public DialogItem Item;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartDialog()
    {
        DialogDisplay.StartDialog(Item);

    }
    // Update is called once per frame
    public void SetDialog(DialogItem newItem)
    {
        Item = newItem;
    }

}
