using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestScreen : MonoBehaviour
{
    public TMP_Text objectiveText;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void ShowQuest(Quest quest)
    {
        objectiveText.text = quest.QuestObjective;
    }

    public void FinishQuest(Quest quest)
    {
        objectiveText.text = ""; //string.Empty  
    }

}
