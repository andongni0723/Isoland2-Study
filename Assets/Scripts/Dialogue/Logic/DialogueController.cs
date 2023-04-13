using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class DialogueController : MonoBehaviour, ICursorClick
{
    public DialogueData_SO commonDialogueData;
    public DialogueData_SO correctDialogueData;
    public GameObject dialogueUIPoint;
    
    public bool isTalk;
    bool isNext;

    public DialogueController()
    {
        isNext = false;
    }

    public void PlayCommonDialogue()
    {
        StartCoroutine(PlayDialogue(commonDialogueData.DialogueList));
    }

    public void PlayCorrectDialogue()
    {
        StartCoroutine(PlayDialogue(correctDialogueData.DialogueList));
    }

    public void ICursorClick()
    {
        // If is talking , click to next the dialogue text
        if (isTalk) isNext = true;
    }

    /// <summary>
    /// Play dialogue a text by a text
    /// </summary>
    /// <param name="dialogueList"></param>
    /// <returns></returns>
    private IEnumerator PlayDialogue(List<string> dialogueList)
    {
        isTalk = true;
        for (int i = 0; i < dialogueList.Count; i++)
        {
            isNext = false;

            EventHandler.CallDialoguePlay(commonDialogueData.DialogueList[i], dialogueUIPoint);
            
            // Wait until player click the character
            yield return new WaitUntil(() => isNext);
        }
    
        EventHandler.CallDialogueDone();
        isTalk = false;
    }
}
