using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData 
{
    public int coinNumber;
    public int score;
    public int gameNumber;
    public string lastPos;

    public GameData()
    {
        this.coinNumber  = 7;
        this.score = 0;
        this.gameNumber = 0;
        this.lastPos = "slow";

    }
}
