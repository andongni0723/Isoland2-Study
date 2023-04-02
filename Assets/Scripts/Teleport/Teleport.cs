using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour, ICursorClick
{
    [SceneName] public string fromScene;
    [SceneName] public string toScene;
    
    public void ICursorClick()
    {
        TeleportToScene();
    }

    public void TeleportToScene()
    {
        TeleportManager.Instance.Transition(fromScene, toScene);
    }

    
}
