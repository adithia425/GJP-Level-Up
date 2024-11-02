using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject infoPopUp, optionPopUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openInfo()
    {
        infoPopUp.SetActive(true);
    }

    public void CloseInfo()
    {
        infoPopUp.SetActive(false);
    }

    public void openOptions()
    {
        optionPopUp.SetActive(true);
    }

    public void closeOptions() {
        optionPopUp.SetActive(false);
    }

    public void exitGame() { 
        Application.Quit();
    }
}