using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DialogueUI : MonoBehaviour
{
    public GameObject panel;
    public Text text;

    #region Event

    private void OnEnable()
    {
        EventHandler.DialoguePlay += OnDialoguePlay; // Display the text from controller
        EventHandler.DialogueDone += OnDialogueDone; // Disable self
        EventHandler.BeforeSceneUnload += OnDialogueDone; // Disable self
    }

    private void OnDisable()
    {
        EventHandler.DialoguePlay -= OnDialoguePlay;
        EventHandler.DialogueDone -= OnDialogueDone;
        EventHandler.BeforeSceneUnload -= OnDialogueDone;
    }

    private void OnDialoguePlay(string dialogue, GameObject dialogueUIPoint)
    {
        panel.SetActive(true);
        transform.position = Camera.main.WorldToScreenPoint(dialogueUIPoint.transform.position);
        
        text.text = dialogue;
    }

    private void OnDialogueDone()
    {
        panel.SetActive(false);
    }

    #endregion
}
