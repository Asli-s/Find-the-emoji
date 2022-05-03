using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    // Start is called before the first frame update
    public int coinNum;
    public int score;
    public int gameNum;

    public PlayerData( GameManager gameManager){
       score= gameManager.score;
        coinNum = gameManager.coinNum;
        gameNum = gameManager.gameCount;
        }
}
