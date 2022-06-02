using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayExtraSound : MonoBehaviour
{
    // Start is called before the first frame update
    new AudioSource audio;
    public AudioClip[] clips;
    private void Awake()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    public void Play()
    {
        if (GameManager.Instance.soundActive == true)
        {

           // audio.clip = clips[0];
            audio.volume = 1;

            audio.Play();

        }
    }
}
