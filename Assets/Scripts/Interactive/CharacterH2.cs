using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterH2 : Interactive
{
    public DialogueController dialogueController => GetComponent<DialogueController>();

    protected override void CommonClick()
    {
        if (!dialogueController.isTalk)
        {
            if(isCorrect)
                dialogueController.PlayCorrectDialogue();
            else
                dialogueController.PlayCommonDialogue();

        }
    }

    protected override void CorrectClick()
    {
        if (!dialogueController.isTalk)
        {
            base.CorrectClick();
            dialogueController.PlayCorrectDialogue();
        }

    }
}
