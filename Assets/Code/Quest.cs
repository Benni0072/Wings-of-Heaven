using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using UnityEngine;
using UnityEngine.Events;

public class Quest : MonoBehaviour
{
    private QuestScreen QuestScreen;

    public string QuestObjective;

    public bool Completed;
    public UnityEvent OnCompleted;


    // Start is called before the first frame update
    void Start()
    {
        //sehr vorsichtig benutzen bei sehr vielen Objecten und Variabeln da Unity sonst Zeit braucht da es das alles durch sucht danach
        //aufkeinen fall im Update machen
        QuestScreen = FindFirstObjectByType<QuestScreen>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartQuest()
    {
        if (Completed)
            return;

        //1. QuestScreen den Text geben
        QuestScreen.ShowQuest(this);

        //irgendwie eine Bedingung prüfen
    }

    public void EndQuest()
    {
        //überprüfen ob Quest schon erledigt ist
        if (Completed)
            return;

        QuestScreen.FinishQuest(this);
        Completed = true;
        OnCompleted.Invoke();
    }
}
