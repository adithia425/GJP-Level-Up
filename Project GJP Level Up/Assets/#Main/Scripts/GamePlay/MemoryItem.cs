using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryItem : MonoBehaviour
{
    public bool isUnlock;
    [TextArea(1,3)]
    public string stringDescription;


    public Image imageSprite;
    public Sprite spriteLock;
    public Sprite spriteUnlock;

    public void SetUp()
    {
        isUnlock = false;

        RefreshSprite();
    }


    public void Unlock()
    {
        isUnlock = true;

        RefreshSprite();
    }

    public void RefreshSprite()
    {
        if(isUnlock)
            imageSprite.sprite = spriteUnlock;
        else
            imageSprite.sprite = spriteLock;
    }
}
