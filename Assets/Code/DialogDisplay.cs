using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogDisplay : MonoBehaviour
{
    private DialogItem currentItem;



    public GameObject Container;

    public TMP_Text TextBox;

    public List<GameObject> Buttons;


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
    }

    public void EndDialog()
    {
        Container.SetActive(false);
    }

    public void ChooseOption(int index)
    {
        DialogOption option = currentItem.Options[index];

        //Invoke = Auslösen
        option.OnOptionSelected.Invoke();

        if (option.NextDialog != null)
        {
            StartDialog(option.NextDialog);
        }
        else
        {
            EndDialog();
        }
    }
}
