using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    protected Queue<string> dialogue;

    private void Start()
    {
        dialogue = new Queue<string>();
    }
    public void startDialogue(string name,string[] text)
    {
        Debug.Log("talking");
        dialogue.Clear();


        foreach (string line in text)
        {
            dialogue.Enqueue(line);
        }





    }

    

    


}
