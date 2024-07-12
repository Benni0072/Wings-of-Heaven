using FMODUnity;

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class DialogDisplay : MonoBehaviour
{
    private DialogItem currentItem;


    public GameObject Container;

    public TMP_Text TextBox;

    public List<GameObject> Buttons;

    public UnityEvent<bool> DialogOpen;

    //2. Möglichkeiten
    //event path
    //public string AtmoEventPath;
    //event reference
    //public EventReference AtmoEventReference;
    //event Emitter
    public StudioEventEmitter Emitter;

    //__________________________________________________________________________________________________________________


    // Start is called before the first frame update
    void Start()
    {
        EndDialog();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartDialog(DialogItem item)
    {
        Container.SetActive(true);


        TextBox.text = item.Text;

        //for schleife
        for (int i = 0; i < Buttons.Count; i++)
        {
            if (i < item.Options.Count)
            {
                Buttons[i].SetActive(true); //einblenden des Buttons
                Buttons[i].GetComponentInChildren<TMP_Text>().text = item.Options[i].Text; //verweis auf Text im Button
            }
            else
            {
                Buttons[i].SetActive(false);
            }
        }

        currentItem = item;


        if (currentItem.image != null)
        {
            currentItem.image.SetActive(true);
        }
        if (currentItem.image_2 != null)
        {
            currentItem.image_2.SetActive(true);
        }
        if (currentItem.image_3 != null)
        {
            currentItem.image_3.SetActive(true);
        }
        item.gameObject.SetActive(true);
        DialogOpen.Invoke(true);

        //_______________SOUND_________________________________________________________________
        // RuntimeManager.CreateInstance(AtmoEventReference).setParameterByName("Frog", 0);
      //  Emitter.EventInstance.setParameterByName("Frog", 0);
    }

    public void EndDialog()
    {
        if (currentItem.image != null)
        {
            currentItem.image.SetActive(false);
        }
        if (currentItem.image_2 != null)
        {
            currentItem.image_2.SetActive(false);
        }
        if (currentItem.image_3 != null)
        {
            currentItem.image_3.SetActive(false);
        }



        Container.SetActive(false);

        DialogOpen.Invoke(false);

       // Emitter.EventInstance.setParameterByName("Frog", 1);
    }

    public void ChooseOption(int index)
    {
        DialogOption option = currentItem.Options[index];

        //Invoke = Auslösen
        option.OnOptionSelected.Invoke();

        if (option.NextDialog != null)
        {
            if (currentItem.image != null)
            {
                currentItem.image.SetActive(false);
            }
            if (currentItem.image_2 != null)
            {
                currentItem.image_2.SetActive(false);
            }
            if (currentItem.image_3 != null)
            {
                currentItem.image_3.SetActive(false);
            }
            StartDialog(option.NextDialog);
        }
        else
        {
            EndDialog();
        }
    }
}
