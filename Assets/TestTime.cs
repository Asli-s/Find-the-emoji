using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using System.Globalization;

public class TestTime : MonoBehaviour
{
  //  public static TestTime Instance;

    // Start is called before the first frame update
    [SerializeField] TMPro.TextMeshProUGUI savedTimeDisplay;
    [SerializeField] TMPro.TextMeshProUGUI NowTimeDisplay;
    [SerializeField] TMPro.TextMeshProUGUI SubtractTimeDisplay;

    [SerializeField] TMPro.TextMeshProUGUI minutesText;
    [SerializeField] TMPro.TextMeshProUGUI secondsText;


    [SerializeField] public TMPro.TextMeshProUGUI TimerText;


    public int remainingMinutes;
  public  int remainingSeconds;

    int minutesLeft;
    int secondsLeft;

    int lifesToAdd = 0;


    DateTime loadedDateTime;
    DateTime currentDateTime;
    string currentDateTimeStr;
    string loadedDateTimeStr;

    public double minutesDifference;

    string coinCountText;
    private int coinCountNum;
    private int newNum;
    double minuteDiff;

    private void Awake()
    {/*
        if (Instance != null)
        {
            Debug.LogError("already an instance created");
        }
        Instance = this;*/
        
    }



    void Start()
    {
     
        minutesLeft = GameManager.Instance.minutesLeft;
        secondsLeft = GameManager.Instance.secondsLeft;

        savedTimeDisplay.text = GameManager.Instance.toLoadDatetime.ToString("HH:mm:ss");
        NowTimeDisplay.text = DateTime.Now.ToString("HH:mm:ss");


        currentDateTimeStr = DateTime.Now.ToString(CultureInfo.GetCultureInfo("de-DE"));


/*neccessary*/

        loadedDateTime = GameManager.Instance.toLoadDatetime;
        currentDateTime = DateTime.ParseExact(currentDateTimeStr, "dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("de-DE"));


      //  DateTime newDays = DateTime.Parse(loadedDateTimeStr, System.Globalization.CultureInfo.InvariantCulture).Date - DateTime.Parse(currentDateTimeStr, System.Globalization.CultureInfo.InvariantCulture).ToOADate;
// (DateTime.Parse(yourDate, System.Globalization.CultureInfo.InvariantCulture).Date - DateTime.Parse(DateTime.Today.ToString, System.Globalization.CultureInfo.InvariantCulture)).TotalDays;


        print(currentDateTime);


        print("minutesLeft" + minutesLeft);
        print("secondsLeft" + secondsLeft);


/*check coinnumber*/


        coinCountText = GameManager.Instance.m_Object.text;
        coinCountNum = int.Parse(coinCountText);
        GameManager.Instance.coinNum = coinCountNum;




        if (GameManager.Instance.coinNum <5)
        {
        minutesDifference = (currentDateTime - loadedDateTime).TotalMinutes; /*whole time in minutes format */

            float newMinuteDifference = ToSingle(minutesDifference); /*conversion to float from double*/

            remainingMinutes = (int)Mathf.Floor(newMinuteDifference);  /*make whole minutes */

            remainingSeconds = (int)((minutesDifference - remainingMinutes) * 60); /*make whole seconds */

            minutesText.text = remainingMinutes.ToString();
            secondsText.text = remainingSeconds.ToString();
            /*    if (GameManager.Instance.activeCountDown == true)
                {
    */
            CalculateLifesToAdd(minutesLeft, secondsLeft, remainingMinutes, remainingSeconds);

            //       }
            SubtractTimeDisplay.text = minutesDifference.ToString("");


        }
        else if (GameManager.Instance.coinNum == 5)
        {
              minutesDifference = 0;
            GameManager.Instance.activeCountDown = false;
            GameManager.Instance.secondsLeft = 0;
            GameManager.Instance.minutesLeft = 0;





/*
            minutesDifference = (currentDateTime - loadedDateTime).TotalMinutes;
           float newMinuteDifference= ToSingle(minutesDifference);
            remainingMinutes = (int) Mathf.Floor( newMinuteDifference);
            remainingSeconds = (int)((minutesDifference - remainingMinutes) * 60);

  
            minutesText.text = remainingMinutes.ToString();
            secondsText.text = remainingSeconds.ToString();
            CalculateLifesToAdd(minutesLeft,secondsLeft, remainingMinutes, remainingSeconds);*/


            // SubtractTimeDisplay.text = minutesDifference.ToString("");

        }



    }

    public float ToSingle(double value)
    {
        return (float)value;
    }


    void CalculateLifesToAdd(int minLeft, int secLeft,int minutes, int seconds)
    {
        print("minutesLeft"+minLeft);
        print("secondsLeft"+secLeft);
        /*  secondsLeft = 10;
          minutesLeft = 5;*/
        /*


                minutes = minutesLeft;
                seconds = secondsLeft;*/
        //FindObjectOfType<CountdownTimer>().StartTimer(minLeft, secLeft);


        print("minutes"+minutes);
        print("seconds" + seconds);

            while(minutes >= 30)
            {

                minutes-=30;
                print(minutes);
                lifesToAdd += 1;
                print(minutes);
                print("lifestoadd"+lifesToAdd);
                if (minutes < 30)
                {
                    break;
                }
            }

        print("minutes after while" + minutes);

               if(minutes <30)
                {
                    print("minutes under 30" + minutes);
                        if (minutes < minutesLeft || (minutesLeft == minutes && secondsLeft> seconds) ) 
                            {

                                if (seconds <= secondsLeft) //working
                                {
                                    print(" 1 minutes<mLeft s<sL" + minutes);

                                    minutes = minutesLeft -minutes;

                                    seconds = secondsLeft - seconds;
                                }
                                else if(seconds > secondsLeft) { //working
                                    print(" 1 minutes<mLeft sL<s" + minutes);

                                    minutes = minutesLeft -minutes-1;
                                    seconds =  60+secondsLeft -seconds;
                //*if min ==0*//*

                                }
                        }
                        else if(minutes>minutesLeft ||( minutesLeft ==minutes && seconds> secondsLeft))
                        {
                            print("minutes<mLeft" + minutes);

                                    if (secondsLeft == seconds)
                                    {
                                        minutes =  minutesLeft-minutes;
                                        minutes = 30 - minutes;
                                        lifesToAdd += 1;
                                    }
                                    else if(secondsLeft > seconds)
                                    {
                                        seconds = secondsLeft - seconds;
                                        seconds = seconds * 60 / 100;
                                         //WRONG  26 

                                         //        minutes =  minutesLeft-minutes;
                                        minutes = 30 - minutes+minutesLeft;
                                        lifesToAdd++;
                                        print("minutes<mLeft s<sL" + minutes);


                                    }
                                    else if( secondsLeft <seconds)
                                    {
                                        lifesToAdd++;

                                        // seconds = seconds + 60 - secondsLeft;
                                        seconds =100-  seconds+secondsLeft;
                                        seconds = seconds * 60 / 100;
                                             //   minutes = minutesLeft - minutes - 1;



                                        minutes = 30 - minutes -1 +minutesLeft;
                                        //      seconds = 60 - seconds;
                                        //seconds = seconds;
                                        print("minutes<mLeft sL<s" + minutes);

                                    }

                         }
                }




                if (coinCountNum < 5)
                {

                GameManager.Instance.secondsLeft =seconds;
                GameManager.Instance.minutesLeft = minutes;
                print(lifesToAdd);

                newNum = coinCountNum;
                newNum += lifesToAdd;


                        if (newNum >= 5)
                        {
                            newNum = 5;
                            GameManager.Instance.coinNum = newNum;

                            GameManager.Instance.m_Object.text = newNum.ToString();
                            TimerText.text = "full";
            
                GameManager.Instance.secondsLeft = 0;
                            GameManager.Instance.minutesLeft = 0;
                            GameManager.Instance.activeCountDown = false;
                                FindObjectOfType<CountdownTimer>().timerStarted = false; ;




                        }
                        else
                        {
                            GameManager.Instance.coinNum = newNum;
            
                            GameManager.Instance.m_Object.text = newNum.ToString();
                            FindObjectOfType<CountdownTimer>().StartTimer(minutes,seconds);
                        }

                }
                else
                {
       
                    GameManager.Instance.secondsLeft = 0;
                    GameManager.Instance.minutesLeft = 0;
                    GameManager.Instance.activeCountDown = false;
                    FindObjectOfType<CountdownTimer>().timerStarted = false; ;
                    TimerText.text = "full";



        }

        //  FindObjectOfType<Timer>().starte();*/


    }





}
