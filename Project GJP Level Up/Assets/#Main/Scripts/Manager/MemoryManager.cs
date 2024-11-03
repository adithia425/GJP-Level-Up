using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MemoryManager : MonoBehaviour
{
    public List<MemoryItem> listItems;


    [Header("Texting")]
    public TextMeshProUGUI textDescription;
    public float typingSpeed = 0.05f;
    public float delayPlayText = 0.5f;
    public float delayHideText = 2f;

    void Start()
    {
        foreach (MemoryItem item in listItems)
        {
            item.SetUp();
        }
    }
    public bool GetItemIsUnlock(int index)
    {
        return listItems[index].isUnlock;
    }

    public void UnlockItem(int index)
    {
        GameManager.Instance.canvasManager.PanelMemory(true);
        GameManager.Instance.isPause = true;

        StartCoroutine(UnlockingItem(index));
    }
    private IEnumerator UnlockingItem(int index)
    {
        yield return new WaitForSeconds(delayPlayText);

        listItems[index].Unlock();
        StartCoroutine(DisplayTextPerLetter(listItems[index].stringDescription));
    }

    public IEnumerator DisplayTextPerLetter(string sentence)
    {
        foreach (char letter in sentence)
        {
            textDescription.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        Invoke(nameof(ResetTexting), delayHideText);
    }

    private void ResetTexting()
    {
        textDescription.text = "";
        GameManager.Instance.canvasManager.PanelMemory(false);

        if(CheckIsAllUnlock())
        {
            GameManager.Instance.GameEnd();
        }

        GameManager.Instance.isPause = false;
    }


    public bool CheckIsAllUnlock()
    {
        bool isEnd = true;
        foreach (MemoryItem item in listItems)
        {
            if(item.isUnlock == false)
            isEnd = false;
        }

        return isEnd;
    }
}