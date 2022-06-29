using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentTimer : MonoBehaviour
{
    // Start is called before the first frame update
    public static PresentTimer Instance;

    int toAppearMinutes =0;

    int toAppearSeconds = 0;

    public bool changeToBonus = false;

    public bool HeartEssenial= false;
    public bool CoinEssenial= false;
    int randomNumber = 0;
   public IEnumerator PresentTimerCountdown;
    bool alreadyInside = false;


    void Awake()
    {
      
        if ( Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
            return;
        }
       // DontDestroyOnLoad(transform.root.gameObject);

    }
    private void Start()
    {
        alreadyInside = false;

    }

    public void StartPresentTimer()
    {

        ChoseEssential();

        changeToBonus = false;
        /*  if(GameManager.Instance.firstPresent == false)
          {
              toAppearMinutes = 10;
              toAppearSeconds = 60 * toAppearMinutes;
          }

          else
          {
              toAppearMinutes = UnityEngine.Random.Range(45, 60);
              toAppearSeconds = 60 * toAppearMinutes;
              print("mintes" + toAppearMinutes);
              print("seconds" + toAppearSeconds);
              print("start coroutine");
              StartCoroutine(presentTimer());

          }*/
        //  toAppearMinutes = 1;
        // toAppearSeconds = 20;
        print("presTimerActive?? " + GameManager.Instance.presTimerActive);
        print("presTimerSeconds?? " + GameManager.Instance.presTimerSeconds);

      //  GameManager.Instance.presTimerSeconds = 0;

        if ( GameManager.Instance.presTimerActive == true &&
            GameManager.Instance.presTimerSeconds >0)
        {

            toAppearSeconds = GameManager.Instance.presTimerSeconds;
            if(alreadyInside == false)
            {
                PresentTimerCountdown = presentTimer();

                StartCoroutine(PresentTimerCountdown);
            }
            // StartCoroutine(presentTimer());
            print("TIMER ALREADY ACTIVE");

        }
        else if( GameManager.Instance.presTimerActive == false || GameManager.Instance.presTimerSeconds ==0)
        {
            // toAppearSeconds = 20;
            toAppearMinutes = UnityEngine.Random.Range(5, 16);
            toAppearSeconds = 60 * toAppearMinutes;

         //   toAppearSeconds = 5;
            GameManager.Instance.presTimerActive = true;

            GameManager.Instance.presTimerSeconds = toAppearSeconds;

            PresentTimerCountdown = presentTimer();

            StartCoroutine(PresentTimerCountdown);
            
            //StartCoroutine(PresentTimerCountdown);
            print("START TIMER");

        }


    }

    private void ChoseEssential()
    {
        //life or coin
     randomNumber=   UnityEngine.Random.Range(0, 2);
        if (randomNumber == 1)
        {
            GameManager.Instance.nextEssentialHeart = true;
            GameManager.Instance.nextEssentialCoin = false;
        }
        else if(randomNumber == 0)
        {
            HeartEssenial = false;
            GameManager.Instance.nextEssentialHeart = false;
            GameManager.Instance.nextEssentialCoin = true;
            CoinEssenial = true;

        }
        print("randomnumber" + randomNumber);

    }


    public void StopThisCoroutine()
    {

        StopCoroutine(PresentTimerCountdown);
    }


    public void StartThisCoroutine()
    {
        if (alreadyInside == false)
        {
            PresentTimerCountdown = presentTimer();

            StartCoroutine(PresentTimerCountdown);
        }
    }


public    IEnumerator presentTimer  ()
    {
        print("inside countdown prestimer");
        GameManager.Instance.presTimerActive = true;
        alreadyInside = true;
        int duration = toAppearSeconds ;
        while(duration > 0)
        {

        yield return new  WaitForSeconds(1);
            duration--;
            GameManager.Instance.presTimerSeconds = duration;


    print("duration" + duration);
            if(duration == 0)
            {
                /*if (GameManager.Instance.firstPresent == false)
                {

                GameManager.Instance.firstPresent = true;

                }*/
                alreadyInside = false;

                // give one present 
                changeToBonus = true;
                break;
            }
        }


    }


}
