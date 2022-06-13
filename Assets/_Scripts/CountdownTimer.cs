using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{

    public static CountdownTimer Instance;
    // Start is called before the first frame update
    [SerializeField] public TMPro.TextMeshProUGUI TimerText;

    // private float countdown =3f*60;

    public bool timerStarted;
    private DateTime timerBeginn;
    private DateTime timerEnd;

 [ SerializeField]  private GameObject window;

    [SerializeField] int hour;
    [SerializeField] int minute;
    [SerializeField] int second;






  //  public GameManager coinCount;
    string coinCountText;
    private int coinCountNum;
   private int newNum;
    double minuteDiff;
    //public int minute = 30;
    //public int second = 0;


    private void Awake()
    {
       
    }

    private void Start()
    {
        

    }
    /*extra*/

    private void Update()
    {
       // print(Application.runInBackground);

    }




    /**/
    public void StartTimer(int minute =0, int second=0)
    {
        timerStarted = GameManager.Instance.activeCountDown;

        if (coinCountNum <5 && timerStarted ==true )
        {
            print("inside  timerstart");
            print(minute + "m" + second + "s  Inside countdowntimer" );


            coinCountText = GameManager.Instance.m_Object.text;
            coinCountNum = int.Parse(coinCountText);
            GameManager.Instance.coinNum = coinCountNum;
            
            timerBeginn = DateTime.Now;
            hour = 0;
            TimeSpan time = new TimeSpan(hour, minute, second);
            timerEnd = timerBeginn.Add(time);
            timerStarted = true;
            StartCoroutine(actualTimer());
            StartCoroutine(DisplayTime());

        }
        else if(  GameManager.Instance.minutesLeft ==0 && GameManager.Instance.secondsLeft ==0) 
        {
            print("inside coinlose timerstart");
         
            minute = 30;
            second = 0;
            coinCountText = GameManager.Instance.m_Object.text;
            coinCountNum = int.Parse(coinCountText);
            GameManager.Instance.coinNum = coinCountNum;
            timerBeginn = DateTime.Now;
            hour = 0;
            TimeSpan time = new TimeSpan(hour, minute, second);
            timerEnd = timerBeginn.Add(time);
            timerStarted = true;
            StartCoroutine(actualTimer());
            StartCoroutine(DisplayTime());
        }
       
  /*      }*/
      /*  if( countdown > 0)
        {

        }*/
    }

    private IEnumerator DisplayTime()
    {
     //   GameManager.Instance.activeCountDown = true;

        DateTime start = DateTime.Now;
        TimeSpan timeLeft = timerEnd - start;
        double timerSecondsLeft = timeLeft.TotalSeconds;
        double totalSeconds = (timerEnd-timerBeginn).TotalSeconds ;

        GameManager.Instance.activeCountDown = true;


        string text;
        while (window.activeSelf == true && GameManager.Instance.minimizedApp ==false)
        { 
             text = "";
            if (timerSecondsLeft > 1)
            {/*
                if (timeLeft.Hours != 0)
                {
                    text += timeLeft.Hours + "h ";
                    text += timeLeft.Minutes + "m";
                    yield return new WaitForSeconds(timeLeft.Seconds);
                 *//*   print("timeleft minutes" + timeLeft.Minutes);
                    print("timeleft sec" + timeLeft.Seconds);
*//*
                }
                else*/ if (timeLeft.Minutes != 0)
                {
                    TimeSpan ts = TimeSpan.FromSeconds(timerSecondsLeft);
                    if (ts.Minutes < 10)
                    {
                        text += "0" + ts.Minutes + "m ";
                        if (ts.Seconds < 10)
                        {
                            text += "0" + ts.Seconds + "s";

                        }
                        else
                        {
                        text += ts.Seconds + "s";

                        }
                        /*    print("ts minutes" + ts.Minutes); 
                            print("ts seconds" + ts.Seconds);*/
                        GameManager.Instance.minutesLeft = ts.Minutes;
                        GameManager.Instance.secondsLeft = ts.Seconds;

                    }
                    else //minutes bigger than 10
                    {
                        
                            text += ts.Minutes + "m ";
                          
                            if (ts.Seconds < 10)
                            {
                                text += "0" + ts.Seconds + "s";

                            }
                            else
                            {
                                text += ts.Seconds + "s";

                            }
                  
                /*    print("ts minutes" + ts.Minutes); 
                    print("ts seconds" + ts.Seconds);*/
                  GameManager.Instance.minutesLeft = ts.Minutes;
                       GameManager.Instance.secondsLeft = ts.Seconds;
                    
                        }


                }
                else
                {
                    text += "00" + "m ";
                    if(Mathf.FloorToInt((float)timerSecondsLeft) < 10)
                    {
                        text += "0"+ Mathf.FloorToInt((float)timerSecondsLeft) + "s";
                        GameManager.Instance.secondsLeft = Mathf.FloorToInt((float)timerSecondsLeft);
                            print(" seconds" + GameManager.Instance.secondsLeft);
                    }
                    else
                    {
                    text += Mathf.FloorToInt((float)timerSecondsLeft) + "s";
                    GameManager.Instance.secondsLeft = Mathf.FloorToInt((float)timerSecondsLeft );
                   print(" seconds" + GameManager.Instance.secondsLeft);

                    }


                }
                TimerText.text = text;
                timerSecondsLeft -= Time.deltaTime;
          //      print("timersec" + timerSecondsLeft);
                yield return null;
            }
            else
            {
                TimerText.text = "";
                timerStarted = false;
                minuteDiff = 0;

                Debug.Log("FINISHEDD TIMER");

                Debug.Log("TImerend coinnum" + coinCountNum);

                print(" (coinCountNum   " + coinCountNum ) ;
                print(" ( GameManager.Instance.activeCountDown   " + GameManager.Instance.activeCountDown) ;
                print(" ( GameManager.Instance.secondsLeft   " + GameManager.Instance.secondsLeft) ;
                print(" (GameManager.Instance.minutesLeft   " + GameManager.Instance.minutesLeft);

                if (coinCountNum < 5 && GameManager.Instance.activeCountDown == true && GameManager.Instance.secondsLeft <= 1 && GameManager.Instance.minutesLeft == 0)
                {
                    print("call addlife from countdown");
                    AddLife();
                }
             

                break;
            }
         
        }
    

        yield return null;
    }



    /*Add a coin */
    public void AddLife()
    {

        coinCountText = GameManager.Instance.m_Object.text;
        coinCountNum = int.Parse(coinCountText);
        GameManager.Instance.coinNum = coinCountNum;
        print("coinnum addlife" + coinCountNum);


        if (coinCountNum < 5)
        {
            print("added LIFE");
            newNum = coinCountNum;
            newNum += 1;
            print("newnum from addlife"+newNum);

            GameManager.Instance.coinNum = newNum;

            GameManager.Instance.m_Object.text = newNum.ToString();
            //
            print("coinnum" + newNum);
            print("gamemananger coinnum" + GameManager.Instance.coinNum);
            if (GameManager.Instance.coinNum == 1)
            {
                print("coinnum ==1");
                GameManager.Instance.activeCountDown = true;
                timerStarted = true;

                StartTimer(30, 0);

                if (FindObjectOfType<noCoinScreen>().isActiveAndEnabled)
                {
                    FindObjectOfType<noCoinScreen>().coinButtonCover.gameObject.SetActive(false);
                    FindObjectOfType<noCoinScreen>().coinButton.interactable = true;
                }
            
            
                print("NEWNUM ADD LIFE" + newNum);
        

            }
           else if (newNum < 5 && newNum !=1)
            {


                GameManager.Instance.activeCountDown = true;
                timerStarted = true;

                GameManager.Instance.minutesLeft = 0;
                GameManager.Instance.secondsLeft = 0;
                print("NEWNUM ADD LIFE" + newNum);
                minute = 30;
                second = 0;
                StartTimer(30,0);

            }
            else if(newNum ==5)
            {
                newNum = 5;
                GameManager.Instance.coinNum = 5;

                GameManager.Instance.m_Object.text = newNum.ToString();

                GameManager.Instance.activeCountDown = false;
                GameManager.Instance.secondsLeft = 0;
                GameManager.Instance.minutesLeft = 0;
                TimerText.text = "  full";

            }
        }



    }






    private IEnumerator actualTimer()
    {
        DateTime start = DateTime.Now;
        double secondsToFinish= (timerEnd - start).TotalSeconds ;

        yield return new WaitForSeconds(Convert.ToSingle(secondsToFinish));

        timerStarted = false;

    }

}
