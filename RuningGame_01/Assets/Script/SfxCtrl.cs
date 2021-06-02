using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxCtrl : MonoBehaviour
{
    static AudioSource audioSource;
    private static AudioClip audioClip;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = Resources.Load<AudioClip>("Sfx2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SoundPlay()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
