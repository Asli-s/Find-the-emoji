using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    // Start is called before the first frame update
    new AudioSource audio;
    public AudioClip[] clips;
    private void Awake()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    public void Click()
    {
        if(GameManager.Instance.soundActive == true)
        {

        audio.clip = clips[0];
        audio.volume = 0.1f;

        audio.Play();

        }
    }
    public void Cancel()
    {
        if (GameManager.Instance.soundActive == true)
        {

            audio.clip = clips[1];
            audio.volume = 0.3f;
            audio.Play();
        }
    }
}
