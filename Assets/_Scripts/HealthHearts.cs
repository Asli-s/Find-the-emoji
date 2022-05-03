using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHearts : MonoBehaviour
{
    // Start
    // is called before the first frame update
    private int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Board _board;
    public Sprite emptyHeart;

    int newHealth;
   
    private void Start()
    {
       
        health = 3;
        setMaxHealth();
    }
 
    public void setMaxHealth()
    {
      //  print("maxhealtth set");
        health = 3; 
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = fullHeart;
        //    print(hearts[i]);
        }
    }
    public int getHealth()
    {
        return health;
    }

    public void loseLife(int positionIndex)
    {



      //  print(health);
        if (health > 0)
        {
          //  print("health bigger 0");
        health--;

        hearts[health].sprite = emptyHeart;
            //ACTIVATE TO CHANGE SINGLE TILE AFTER CLICKED
           // _board.changeClickedSingleTile(positionIndex);
        }
        if(health ==0)
        {
         //   print("health equal 0");
            GameManager.Instance.ChangeState(GameState.Lose);
            //IF AFTER DEATH IMMEDIATE RECOVERY OF HEALTH IS NEEDED
         //   setMaxHealth();
        }
    }

   
}
