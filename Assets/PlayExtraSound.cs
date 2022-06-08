using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayExtraSound : MonoBehaviour
{
    // Start is called before the first frame update
    new AudioSource audio;
    public AudioClip[] clips;
    AudioClip winAnouncement;
    AudioClip slash;

    private void Awake()
    {
        audio = gameObject.GetComponent<AudioSource>();
        winAnouncement= clips[0];
        slash= clips[1];
    }

    public void Play(string name)
    {
        if (GameManager.Instance.soundActive == true)
        {

            if (name == "win") {
                audio.clip = clips[0];
                audio.pitch = 1.8f;
                audio.volume = 0.5f;

            }
            else if( name == "slash")
            {
                audio.clip = clips[1];
                audio.pitch = 2.6f;
                audio.volume = 1;

            }


            audio.Play();

        }
    }
}
