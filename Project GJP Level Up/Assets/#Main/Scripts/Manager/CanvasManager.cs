using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject panelMemory;
    public GameObject panelEnding;

    void Start()
    {
        
    }

    public void PanelMemory(bool con)
    {
        panelMemory.SetActive(con);
    }
    public void PanelEnding(bool con)
    {
        panelEnding.SetActive(con);
    }
}
