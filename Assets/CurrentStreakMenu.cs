using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentStreakMenu : MonoBehaviour
{
    // Start is called before the first frame update
  public TMPro.TextMeshProUGUI currTextNum
        ;

    public void ChangeCurrStreak()
    {

        currTextNum.text = GameManager.Instance.currentStreak.ToString();
    }

}
