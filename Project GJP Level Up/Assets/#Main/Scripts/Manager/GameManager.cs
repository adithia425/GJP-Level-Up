using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public bool isPause;


    [Header("References")]
    public CanvasManager canvasManager;
    public MemoryManager memoryManager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPause) return;

        if(Input.GetKey(KeyCode.Tab))
            canvasManager.PanelMemory(true);
        else
            canvasManager.PanelMemory(false);
        
    }

    public void GameEnd()
    {
        isPause = true;
        canvasManager.PanelEnding(true);
    }
}
