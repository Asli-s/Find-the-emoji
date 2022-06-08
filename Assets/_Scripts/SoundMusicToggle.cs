using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundMusicToggle : MonoBehaviour
{
    // Start is called before the first frame update
    bool soundOn = true;
    bool musicOn = true;
    [SerializeField] Sprite soundOnSprite;
    [SerializeField] Sprite soundOffSprite;
    [SerializeField] Sprite musicOnSprite;
    [SerializeField] Sprite musicOffSprite;
    [SerializeField] Button soundButton; 
    [SerializeField] Button musicButton; 

    void OnEnable()
    {
        soundOn = GameManager.Instance.soundActive;
        musicOn = GameManager.Instance.musicActive;

        if (soundOn == true)
        {
            soundButton.image.sprite = soundOnSprite;
        }
        else if (soundOn == false)
        {
            soundButton.image.sprite = soundOffSprite;
        }
        if (musicOn == true)
        {
            musicButton.image.sprite = musicOnSprite;
        }
        else if (musicOn == false)
        {
            musicButton.image.sprite = musicOffSprite;
        }


    }


    public void MusicToggle()
    {

        if(musicOn == true)
        {
            musicOn = false;
            GameManager.Instance.musicActive =false;
            ThemeSound.Instance.StopThemeSong();
            musicButton.image.sprite = musicOffSprite; 

        }
        else if(musicOn ==false)
        {
            musicOn = true;
            GameManager.Instance.musicActive = true;
            ThemeSound.Instance.PlayThemeSong();
            musicButton.image.sprite = musicOnSprite; 
        }
        DataPersistenceManager.Instance.SaveGame();

    }


    public void SoundToogle()
    {

        if (soundOn == true)
        {
            soundOn = false;
            GameManager.Instance.soundActive = false; 
            soundButton.image.sprite = soundOffSprite;

        }
        else if (soundOn == false)
        {
            soundOn = true;
            GameManager.Instance.soundActive = true;
            soundButton.image.sprite = soundOnSprite;

        }
        DataPersistenceManager.Instance.SaveGame();

    }

    // Update is called once per frame

}
