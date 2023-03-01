using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using System.Globalization;
using UnityEngine.SceneManagement;

public class TestTime : MonoBehaviour
{
    public static TestTime Instance;

    [SerializeField] TMPro.TextMeshProUGUI savedTimeDisplay;
    [SerializeField] TMPro.TextMeshProUGUI NowTimeDisplay;
    [SerializeField] TMPro.TextMeshProUGUI SubtractTimeDisplay;
    [SerializeField] TMPro.TextMeshProUGUI minutesText;
    [SerializeField] TMPro.TextMeshProUGUI secondsText;
    [SerializeField] public TMPro.TextMeshProUGUI TimerText;

    public CountdownTimer countDownInstance;
    public int remainingMinutes;
    public int remainingSeconds;

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
    [SerializeField] GameObject FirstScreen;
    [SerializeField] GameObject NoCoinScreen;

    public bool alreadyInGame = false;






    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("already an instance created");
        }
        Instance = this;

    }



    public void CalculateTime()
    {



        minutesLeft = GameManager.Instance.minutesLeft;
        secondsLeft = GameManager.Instance.secondsLeft;

        savedTimeDisplay.text = GameManager.Instance.toLoadDatetime.ToString("HH:mm:ss");
        NowTimeDisplay.text = DateTime.UtcNow.ToString("HH:mm:ss");
        currentDateTimeStr = DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss zzz", CultureInfo.InvariantCulture);


        loadedDateTime = GameManager.Instance.toLoadDatetime;
        currentDateTime = DateTime.ParseExact(currentDateTimeStr, "MM/dd/yyyy HH:mm:ss zzz", CultureInfo.InvariantCulture);

        print(currentDateTime);


        print("minutesLeft" + minutesLeft);
        print("secondsLeft" + secondsLeft);


        /*check coinnumber*/


        coinCountText = GameManager.Instance.m_Object.text;
        coinCountNum = int.Parse(coinCountText);
        GameManager.Instance.coinNum = coinCountNum;

        print("loadedDateTime" + loadedDateTime);

        minutesDifference = (currentDateTime - loadedDateTime).TotalMinutes; /*whole time in minutes format */

        float newMinuteDifference = ToSingle(minutesDifference); /*conversion to float from double*/
        print("mindiff" + minutesDifference);

        remainingMinutes = (int)Mathf.Floor(newMinuteDifference);  /*make whole minutes */

        remainingSeconds = (int)((minutesDifference - remainingMinutes) * 60); /*make whole seconds */
        print("remaining minutes and seconds" + remainingMinutes + remainingSeconds);

        print("CURRRENT STREAK" + GameManager.Instance.currentStreak);
        if (remainingMinutes == 0 && remainingSeconds <= 2 || GameManager.Instance.minimizedApp == true)
        {

            GameManager.Instance.restarted = false;


            alreadyInGame = false;



        }
        else if (remainingMinutes >= 0 && remainingSeconds > 2 || GameManager.Instance.minimizedApp == false)
        {
            GameManager.Instance.restarted = true;
            if (GameManager.Instance.currentStreak >= GameManager.Instance.bestStreak)
            {
                GameManager.Instance.bestStreak = GameManager.Instance.currentStreak;
            }

            GameManager.Instance.currentStreak = 0;
            print("currentstreak reset if game is restarted");



        }
        if (remainingMinutes >= 0 && remainingSeconds > 2 && GameManager.Instance.minimizedApp == false)
        {
            GameManager.Instance.gameActive = false;

        }



        if (GameManager.Instance.coinNum < 5)
        {
            GameManager.Instance.activeCountDown = true;


            minutesText.text = remainingMinutes.ToString();
            secondsText.text = remainingSeconds.ToString();

            CalculateLifesToAdd(minutesLeft, secondsLeft, remainingMinutes, remainingSeconds);


            SubtractTimeDisplay.text = minutesDifference.ToString("");


        }
        else if (GameManager.Instance.coinNum == 5)
        {
            print("test time coin nu 5");
            GameManager.Instance.activeCountDown = false;
            GameManager.Instance.secondsLeft = 0;
            GameManager.Instance.minutesLeft = 30;
            TimerText.text = "  full";

            if (GameManager.Instance.restarted == true || FirstScreen.activeSelf == true || GameManager.Instance.gameActive == false)
            {
                print("firtscreen");

                GameManager.Instance.minimizedApp = false;
                if (GameManager.Instance.noCoinSCreenActive == false)
                {

                    FirstScreen.SetActive(true);
                }
                alreadyInGame = false;

            }
            else if (GameManager.Instance.gameActive == true)// && alreadyInGame  == false)
            {
                print("start game");
                FirstScreen.SetActive(false);


                if (GameManager.Instance.bonusOn == false && GameManager.Instance.findScreenGameActive == false)// && GameManager.Instance.restarted == true)
                {
                    PresentTimer.Instance.StartPresentTimer();

                    GameManager.Instance.ChangeState(GameState.FeatureTile);
                }
            }

        }



    }




    public float ToSingle(double value)
    {
        return (float)value;
    }


    void CalculateLifesToAdd(int minLeft, int secLeft, int minutes, int seconds)
    {

        while (minutes >= 30)
        {

            minutes -= 30;
            print(minutes);
            lifesToAdd += 1;
            print(minutes);
            print("lifestoadd while" + lifesToAdd);
            if (minutes < 30)
            {
                break;
            }
        }

        print("minutes after while" + minutes);

        if (minutes < 30)
        {
            print("minutes under 30" + minutes);
            if (minutes < minutesLeft || (minutesLeft == minutes && secondsLeft > seconds))
            {

                if (seconds <= secondsLeft) //working
                {
                    print(" 1 minutes<mLeft s<sL" + minutes);

                    minutes = minutesLeft - minutes;

                    seconds = secondsLeft - seconds;
                }
                else if (seconds > secondsLeft)
                { //working
                    print(" 1 minutes<mLeft sL<s" + minutes);

                    minutes = minutesLeft - minutes - 1;
                    seconds = 60 + secondsLeft - seconds;

                }
            }
            else if (minutes > minutesLeft || (minutesLeft == minutes && seconds > secondsLeft))
            {
                print("minutes<mLeft" + minutes);

                if (secondsLeft == seconds)
                {
                    minutes = minutesLeft - minutes;
                    minutes = 30 - minutes;
                    lifesToAdd += 1;
                }
                else if (secondsLeft > seconds)
                {
                    seconds = secondsLeft - seconds;
                    seconds = seconds * 60 / 100;

                    minutes = 30 - minutes + minutesLeft;
                    lifesToAdd++;
                    print("minutes<mLeft s<sL" + minutes);


                }
                else if (secondsLeft < seconds)
                {
                    lifesToAdd++;

                    seconds = 100 - seconds + secondsLeft;
                    seconds = seconds * 60 / 100;

                    minutes = 30 - minutes - 1 + minutesLeft;
                    print("minutes<mLeft sL<s" + minutes);

                }

            }
        }




        if (coinCountNum < 5)
        {

            GameManager.Instance.secondsLeft = seconds;
            GameManager.Instance.minutesLeft = minutes;
            print(lifesToAdd);

            newNum = coinCountNum;

            newNum += lifesToAdd;
            print(newNum);


            lifesToAdd = 0;

            //after adding life
            if (newNum >= 5)
            {
                print("newnum >5 with added lifes");
                newNum = 5;
                GameManager.Instance.coinNum = newNum;

                GameManager.Instance.m_Object.text = newNum.ToString();
                TimerText.text = "  full";

                GameManager.Instance.secondsLeft = 0;
                GameManager.Instance.minutesLeft = 0;
                GameManager.Instance.activeCountDown = false;
                FindObjectOfType<CountdownTimer>().timerStarted = false; ;
                if (GameManager.Instance?.restarted == true || FirstScreen?.activeSelf == true || GameManager.Instance.gameActive == false)
                {
                    if (GameManager.Instance.noCoinSCreenActive == false)
                    {

                        FirstScreen?.SetActive(true);
                    }
                }

                else if (GameManager.Instance.gameActive == true)
                {
                    print("start game but lifestoadd ==5");
                    FirstScreen.SetActive(false);



                    if (GameManager.Instance.bonusOn == false && GameManager.Instance.findScreenGameActive == false)
                    {
                        PresentTimer.Instance.StartPresentTimer();

                        GameManager.Instance.ChangeState(GameState.FeatureTile);
                    }
                }


                //ifnoscreen == active and newNum >0 ---> deactivate button
            }
            else if (newNum < 5)
            {




                print("finally to start the timer from tesstimer");
                print(minutes + "m" + seconds + " s" + GameManager.Instance.activeCountDown);

                GameManager.Instance.coinNum = newNum;

                GameManager.Instance.m_Object.text = newNum.ToString();



                if (GameManager.Instance.gameActive == false)
                {


                    if (GameManager.Instance.noCoinSCreenActive == false)
                    {

                        FirstScreen?.SetActive(true);
                    }
                }

                else if (GameManager.Instance.gameActive == true)// && alreadyInGame  == false)
                {
                    print("start game from calculate");
                    FirstScreen.SetActive(false);



                    if (GameManager.Instance.bonusOn == false && GameManager.Instance.findScreenGameActive == false)// && GameManager.Instance.restarted == true)
                    {
                        PresentTimer.Instance.StartPresentTimer();

                        GameManager.Instance.ChangeState(GameState.FeatureTile);
                    }
                }


                if (GameManager.Instance.minimizedApp == true && NoCoinScreen.activeSelf == true && GameManager.Instance.coinNum > 0 && GameManager.Instance.restarted == false && alreadyInGame == true)
                {
                    FindObjectOfType<noCoinScreen>().coinButtonCover.gameObject.SetActive(false);
                    FindObjectOfType<noCoinScreen>().coinButton.interactable = true;

                }

                if (GameManager.Instance.minimizedApp == true)
                {
                    GameManager.Instance.minimizedApp = false;
                }




                if (minutes == 0 && seconds == 0)
                {
                    minutes = 29;
                    seconds = 59;
                }

                FindObjectOfType<CountdownTimer>().StartTimer(minutes, seconds);

            }

        }
        else if (coinCountNum == 5)
        {
            print("testtime coin 5");
            GameManager.Instance.secondsLeft = 0;
            GameManager.Instance.minutesLeft = 0;
            GameManager.Instance.activeCountDown = false;
            FindObjectOfType<CountdownTimer>().timerStarted = false; ;
            TimerText.text = "  full";

            if (GameManager.Instance.gameActive == true)// && alreadyInGame  == false)
            {
                print("start game full5 but calculate");
                FirstScreen.SetActive(false);


                if (GameManager.Instance.bonusOn == false && GameManager.Instance.findScreenGameActive == false)
                {


                    PresentTimer.Instance.StartPresentTimer();

                    GameManager.Instance.ChangeState(GameState.FeatureTile);
                }
            }
            else
            {
                if (GameManager.Instance.noCoinSCreenActive == false)
                {

                    FirstScreen?.SetActive(true);
                }
                alreadyInGame = false;

            }

        }



    }





}
