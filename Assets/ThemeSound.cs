using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeSound : MonoBehaviour
{
    // Start is called before the first frame update
    public static ThemeSound Instance;
   new public AudioSource audio;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else {
            Destroy(gameObject);
            return;

        }

        DontDestroyOnLoad(transform.root.gameObject);
        audio = gameObject.GetComponent<AudioSource>();
        
    }
    private void Start()
    {/*
        audio.volume = .8f;
        audio.pitch = 1.08f;*/
        
          PlayThemeSong();
    }

    public void PlayThemeSong()
    {
        if (GameManager.Instance.musicActive == true)
        {
            audio.volume = .1f;
            audio.pitch = 1.1f;

            audio.Play();
        }

    }
    public void StopThemeSong()
    {
        if (GameManager.Instance.musicActive == false)
        {
            audio.volume = .1f;
            audio.pitch = 1.1f;

            audio.Stop();
        }

    }
}
