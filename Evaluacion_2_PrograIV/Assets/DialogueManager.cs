using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject dialogueBox;
    [SerializeField] PrefabText dialogueText;
    [SerializeField] int[] dialogueIDs;
    int currentLine;

    private PlayerController playerController;

    void Awake()
    {
        dialogueBox.SetActive(false);
        playerController = FindObjectOfType<PlayerController>();
        StartDialogue(dialogueIDs);
    }

    public void StartDialogue(int[] lines)
    {
        dialogueIDs = lines;
        currentLine = 0;
        dialogueBox.SetActive(true);
        dialogueText.ChangeText(dialogueIDs[currentLine]);
        //dialogueText.text = dialogueIDs[currentLine];
        playerController.enabled = false;
    }
    public void ShowNextLine()
    {
        currentLine++;
        if (currentLine < dialogueIDs.Length)
        {
            dialogueText.ChangeText(dialogueIDs[currentLine]);
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        dialogueBox.SetActive(false);
        playerController.enabled = true;
    }
}