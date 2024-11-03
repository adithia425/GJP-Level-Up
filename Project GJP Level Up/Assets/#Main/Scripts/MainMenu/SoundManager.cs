using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource BGM;
    [SerializeField] AudioSource SFX;
    

    public AudioClip BGMClip;
    public AudioClip SFXClip;

    public void Start()
    {

        BGM.clip = BGMClip;
        BGM.Play();
    

    }

    public void playSFX(AudioClip Clip)
    {
        SFX.PlayOneShot(Clip);
    }

    
}
