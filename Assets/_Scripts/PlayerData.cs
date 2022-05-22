using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    // Start is called before the first frame update
    public int gameNum;
    public int coinNum;

    public int score3;
    public int score2;
    public int score1;

    public PlayerData( GameManager gameManager){
      /* score3= gameManager.score3;
        score2 = gameManager.score3;
        score1 = gameManager.score1;*/

        coinNum = gameManager.coinNum;
        gameNum = gameManager.gameCount;
        }
}
