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

    public bool talking = false;
    private UIManager uIManager;
    private Queue<string> dialogue;
    private PlayerMovementController playerController;

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
    IEnumerator writeDialog(string currentText)
    {
        for(int i = 0; i < currentText.Length; i++)
        {
            uIManager.WriteDialogue(currentText[i].ToString());
            yield return new WaitForSeconds(0.01f);
        }
    }
    public void CountinueText(string name)
    {
        StopAllCoroutines();
        uIManager.clearDialogueBox();
        if(dialogue.Count == 0)
        {
            stopTalking();
            return;
        }


        string currentText = dialogue.Dequeue();

        StartCoroutine(writeDialog(currentText));
        



    }

    public void stopTalking()
    {
        Debug.Log("stoped talking");
        uIManager.HideDialoguePanel();
        playerController.moveEnabled = true;
        talking = false;
    }


}
