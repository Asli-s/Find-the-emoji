using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static GameOver Instance;
    public Tiles _tiles;
    public Board _board;
    public GameObject _parent;
    public GameObject _parent_mainCanvas;

    private GameObject winScreen;
    private GameObject loseScreen;
    private List<Tiles> _allTiles;
    public GameObject featureTile;
    public Image[] Stars;
    public Sprite greyStar;
    public Sprite yellowStar;
    public  int score;


    //activating screens
    public GameObject WinScreen;
    public GameObject LoseScreen;
   // public GameObject WinScreen;



    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    public void Win()
    {
         WinScreen.SetActive(true);
        score = GameManager.Instance.score;

        /*ACCESS CHILD OBJECT STARS ___PREFAB CHILDREN NOT ACCESSIBLE*/



       /* for (int i = 0; i < Stars.Length; i++)
        {
            if(_board.appearCounter==0 || _board.appearCounter == 1)
            {
              //  print(_board.appearCounter);
            Stars[i].sprite = yellowStar;
              
                score = 3;
            }
           else if (_board.appearCounter >1 && _board.appearCounter <= 3)
            {
                Stars[0].sprite = yellowStar;
                Stars[1].sprite = yellowStar;
                Stars[2].sprite = greyStar;
                score = 2;
            }
            else if (_board.appearCounter >3)
            {
                // Stars[i].sprite = greyStar;
                Stars[0].sprite = yellowStar;
                Stars[1].sprite = greyStar;
                Stars[2].sprite = greyStar;
                score = 1;

            }
            // save score

        }
          */

         


        _allTiles = _board._nodes;
        _tiles.GetComponent<BoxCollider2D>();
       
        _allTiles.ForEach((tile)=>{ tile.GetComponent<BoxCollider2D>().enabled = false; });
        featureTile.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = false;

        StopCoroutine(_board.StartTimer);

        /*  Time.timeScale = 0f;
          winScreen.SetActive(true);
          //call board star rating*/


        //   winScreen = Instantiate(WinScreen,Vector2.one,Quaternion.identity);
        //    winScreen.transform.parent = _parent_mainCanvas.transform;


    }
    public void Lose()
    {
           LoseScreen.SetActive(true);
        score = GameManager.Instance.score;

        score = 0;
        _allTiles = _board._nodes;
        _tiles.GetComponent<BoxCollider2D>();

        _allTiles.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = false; });
        featureTile.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = false;


        StopCoroutine(_board.StartTimer);

       // Time.timeScale = 0f;

    //  loseScreen=  Instantiate(LoseScreen, Vector2.one, Quaternion.identity);
     //   loseScreen.transform.parent = _parent_mainCanvas.transform;


    }
    public void Restart()
    {
        StopCoroutine(_board.StartTimer);
        Time.timeScale = 1f;
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

    }
}