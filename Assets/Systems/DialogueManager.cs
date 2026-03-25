using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{

    public ServiceHub serviceHub;
    private bool wrightingDialogue = false;
    public bool talking = false;
    private UIManager uIManager;
    private Queue<string> dialogue;
    private PlayerMovementController playerController;
    private string currentText;
    private void Start()
    {
        dialogue = new Queue<string>();
        uIManager = serviceHub.UIManager;
        playerController = serviceHub.Player.GetComponent<PlayerMovementController>();
    }
    public void startDialogue(string name,string[] text)
    {
        uIManager.ShowDialoguePanel();
        Debug.Log("talking");
        dialogue.Clear();
        playerController.moveEnabled = false;
        talking = true;

        foreach (string line in text)
        {
            dialogue.Enqueue(line);
        }

        CountinueText(name);



    }
    //why is it that you are never right about how hard programming anything will be
    IEnumerator writeDialogue()
    {
        wrightingDialogue = true;
        for(int i = 0; i < currentText.Length; i++)
        {
            uIManager.WriteDialogue(currentText[i].ToString());
            yield return new WaitForSeconds(0.01f);
        }
        wrightingDialogue = false;
    }
    public void CountinueText(string name)
    {

        if (!wrightingDialogue)
        {
            
            uIManager.clearDialogueBox();
            if (dialogue.Count == 0)
            {
                stopTalking();
                return;
            }


            currentText = dialogue.Dequeue();

            StartCoroutine(writeDialogue());
        }
        else
        {
            StopAllCoroutines();
            uIManager.clearDialogueBox();
            uIManager.WriteDialogue(currentText);
            wrightingDialogue = false;
        }



    }

    public void stopTalking()
    {
        Debug.Log("stoped talking");
        uIManager.HideDialoguePanel();
        playerController.moveEnabled = true;
        talking = false;
    }


}
