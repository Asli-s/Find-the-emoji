using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Sound[] sounds;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        /* foreach(Sound s in sounds)
         {

 //            s.source =gameObject.AddComponent<AudioSource>();
             s.source.clip = s.audioClip;
             s.source.pitch = s.pitch;
             s.source.volume = s.volume;
             s.source.loop = s.loop;
         }*/
    }


    public void Play(string name, bool loop = false, bool stop = false)
    {
        if (GameManager.Instance.soundActive == true)
        {

            audioSource = gameObject.GetComponent<AudioSource>();
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s == null) return;
            //(sound)
            audioSource.clip = s.audioClip;
            audioSource.pitch = s.pitch;
            audioSource.volume = s.volume;
            audioSource.loop = loop;
            //    audioSource.Play();
            /*     if(loop == true)
                   {
                       audioSource.loop = true;
                   }
                   else if(loop ==false)
                   {
                     print("deactivate loop");
                     audioSource.Stop();

                     audioSource.loop = false;
                   }*/
            if (stop == true)
            {
                print("stop =true");
                audioSource.Stop();

            }
            else if (stop == false)
            {

                audioSource.Play();
            }

            // audioSource.clip = s.audioClip;
            /*
                    s.source.clip = s.audioClip;
                    s.source.pitch = s.pitch;
                    s.source.volume = s.volume;
                    s.source.loop = s.loop;
                    s.source.Play();
            */
        }
    }


   

}
