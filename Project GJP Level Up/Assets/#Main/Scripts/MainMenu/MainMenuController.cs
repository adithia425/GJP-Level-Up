using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject infoPopUp, optionPopUp;
    SoundManager soundManager;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    public void startGame()
    {
        StartCoroutine(PlaySoundAndStartGame());
    }

    private IEnumerator PlaySoundAndStartGame()
    {
        // Mainkan suara klik button
        soundManager.playSFX(soundManager.SFXClip);

        // Tunggu hingga suara selesai diputar
        yield return new WaitForSeconds(soundManager.SFXClip.length);

        // Load scene GamePlay setelah suara selesai
        SceneManager.LoadScene("GamePlay");
    }

    public void openInfo()
    {
        infoPopUp.SetActive(true);
        soundManager.playSFX(soundManager.SFXClip);
    }

    public void CloseInfo()
    {
        infoPopUp.SetActive(false);
        soundManager.playSFX(soundManager.SFXClip);
    }

    public void openOptions()
    {
        optionPopUp.SetActive(true);
        soundManager.playSFX(soundManager.SFXClip);
    }

    public void closeOptions()
    {
        optionPopUp.SetActive(false);
        soundManager.playSFX(soundManager.SFXClip);
    }

    public void exitGame()
    {
        Application.Quit();
        soundManager.playSFX(soundManager.SFXClip);
    }
}
