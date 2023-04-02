using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.Serialization;

public class TeleportManager : Singleton<TeleportManager>
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration;
    
    private bool isFade = false;
    public void Transition(string from, string to)
    {
        if(!isFade)
            StartCoroutine(TransitionToScene(from, to));
    }

    private IEnumerator TransitionToScene(string from, string to)
    {
        // Fade In
        yield return Fade(1);
        
        // Load Scene
        yield return SceneManager.UnloadSceneAsync(from);
        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);

        // Set new Scent to Active
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(to));
        
        // Fade Out
        yield return Fade(0);
    }

    
    private IEnumerator Fade(float targetAlpha)
    {
        isFade = true;
        fadeCanvasGroup.blocksRaycasts = true;
        
        // Fade 
        yield return fadeCanvasGroup.DOFade(targetAlpha, fadeDuration).WaitForCompletion();

        fadeCanvasGroup.blocksRaycasts = false;
        isFade = false;
    }
}
