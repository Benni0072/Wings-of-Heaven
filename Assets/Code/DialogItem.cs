using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogItem : MonoBehaviour
{
    public string Text;

    public List<DialogOption> Options;

    public object Image { get; internal set; }
}
