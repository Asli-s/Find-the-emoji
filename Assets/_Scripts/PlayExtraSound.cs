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
                audio.volume = 0.2f;

            }
            else if( name == "slash")
            {
                audio.clip = clips[1];
                audio.pitch = 2.6f;
                audio.volume = 1;

            }
            else if (name == "success")
            {
                audio.clip = clips[2];
                audio.pitch = 1.1f;
                audio.volume = 0.1f;

            }
            else if (name == "present")
            {

              
                    audio.clip = clips[3];
                    audio.pitch = 1.1f;
                    audio.volume = 0.15f;

                
            }
            //featuretile anim in place pop sound
            else if (name == "click")
            {

                audio.clip = clips[4];
                audio.pitch = 1f;
                audio.volume = .04f;

            }
            else if (name == "littlePop")
            {

                audio.clip = clips[5];
                audio.pitch = 0.4f;
                audio.volume = .02f;

            }

            audio.Play();

        }
    }
}
