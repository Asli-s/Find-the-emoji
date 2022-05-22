using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public TMPro.TextMeshProUGUI playedGames;
    [SerializeField] public TMPro.TextMeshProUGUI WonGames;
    [SerializeField] public TMPro.TextMeshProUGUI LostGames;

    [SerializeField] public TMPro.TextMeshProUGUI score3Stars;
    [SerializeField] public TMPro.TextMeshProUGUI score2Stars;
    [SerializeField] public TMPro.TextMeshProUGUI score1Stars;

    float score1;
    float score2;
    float score3;

    float newScore1;
    float newScore2;
    float newScore3;

    int win;
    int lost;
  


    private void OnEnable()
    {
        playedGames.text = GameManager.Instance.gameCount.ToString();
        LostGames.text = GameManager.Instance.lose.ToString();
        WonGames.text = GameManager.Instance.win.ToString();

        lost = GameManager.Instance.lose;
        win = GameManager.Instance.win;

        print(GameManager.Instance.score1);
        print(GameManager.Instance.score2);
        print(GameManager.Instance.score3);

        score1 = GameManager.Instance.score1 ;
        score2 = GameManager.Instance.score2  ;
        score3 = GameManager.Instance.score3  ;

        newScore1 = score1*100f / win;
        newScore2 = score2 * 100f / win;
        newScore3 = score3 * 100f / win;

        print(newScore1);
        print(newScore2);
        print(newScore3);

        score1Stars.text =Mathf.RoundToInt( newScore1).ToString() + "%";
        score2Stars.text = Mathf.RoundToInt(newScore2).ToString() + "%";
        score3Stars.text = Mathf.RoundToInt(newScore3).ToString() + "%";

    }


}
