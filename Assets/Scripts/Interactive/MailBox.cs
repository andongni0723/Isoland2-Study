using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailBox : Interactive
{
    [Header("Setting")] 
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D coll;

    public Sprite openSprite;
    public GameObject mail;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    #region Event

    private void OnEnable()
    {
        EventHandler.AfterSceneLoad += OnAfterSceneLoad;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoad -= OnAfterSceneLoad;
        
    }

    private void OnAfterSceneLoad()
    {
        // Check mail box statue
        if (isCorrect)
        {
            spriteRenderer.sprite = openSprite;
            coll.enabled = false;
        }
        else
        {
            mail.SetActive(false);
        }
    }

    #endregion

    protected override void CorrectClick()
    {
        spriteRenderer.sprite = openSprite;
        coll.enabled = false;
        mail.SetActive(true);
        base.CorrectClick();
    }
}
