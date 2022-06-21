using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHearts : MonoBehaviour
{
    // Start
    // is called before the first frame update
    public int health;
    public int numOfHearts;

    public static HealthHearts Instance;

    public Image[] hearts;
    public Sprite fullHeart;
    public Board _board;
    public Sprite emptyHeart;

    int newHealth;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

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

    public void loseLife()
    {



       print(health);
        health= health-1;
        if (health >= 0)
        {
          //  print("health bigger 0");

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

    public void addHealth()
    {
        health += 1;
        if (health ==3)
        {
            //  print("health bigger 0");
            setMaxHealth();

            //ACTIVATE TO CHANGE SINGLE TILE AFTER CLICKED
            // _board.changeClickedSingleTile(positionIndex);
        } else if (health ==2)
        {

            hearts[1].sprite = fullHeart;

        }
      

    }

}
