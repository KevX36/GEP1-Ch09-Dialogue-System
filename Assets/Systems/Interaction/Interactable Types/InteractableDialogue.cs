using Unity.VisualScripting;
using UnityEngine;

public class InteractableDIalogue : MonoBehaviour, IInteractable
{
    public ServiceHub hub;
    public string name;
    [TextArea]public string[] Dialogue;
    public void Interact()
    {
        if (!hub.DialogueManager.talking)
        {
            hub.DialogueManager.startDialogue(name, Dialogue);
        }
        else
        {
            hub.DialogueManager.CountinueText(name);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
