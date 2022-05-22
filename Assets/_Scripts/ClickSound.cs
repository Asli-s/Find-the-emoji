using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audio;
    public AudioClip[] clips;
    private void Awake()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    public void Click()
    {
        audio.clip = clips[0];
        audio.volume = 1;

        audio.Play();
    }
    public void Cancel()
    {
        audio.clip = clips[1];
        audio.volume = 0.3f;
        audio.Play();
    }
}
