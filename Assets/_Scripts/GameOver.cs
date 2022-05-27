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

    public bool win = false;
    public bool lose = false;
    private List<Tiles> _allTiles;
    public GameObject featureTile;
    public Image[] Stars;
    public Sprite greyStar;
    public Sprite yellowStar;
    public int score;


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
      //  GameManager.Instance.win += 1;
        win = true;
        WinScreen.SetActive(true);
        score = GameManager.Instance.score;
        FindObjectOfType<AudioManager>().Play("win", false);


        _allTiles = _board._nodes;
        _tiles.GetComponent<BoxCollider2D>();

        _allTiles.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = false; });
        featureTile.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = false;

   //     StopCoroutine(_board.StartTimer);


    }
    public void Lose()
    {
    //    GameManager.Instance.lose += 1;
        lose = true;
        LoseScreen.SetActive(true);
        score = GameManager.Instance.score;
        score = 0;
        _allTiles = _board._nodes;
        _tiles.GetComponent<BoxCollider2D>();

        _allTiles.ForEach((tile) => { tile.GetComponent<BoxCollider2D>().enabled = false; });
        FindObjectOfType<AudioManager>().Play("lose", false);

        featureTile.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = false;

    

    //    StopCoroutine(_board.StartTimer);

        // Time.timeScale = 0f;

        //  loseScreen=  Instantiate(LoseScreen, Vector2.one, Quaternion.identity);
        //   loseScreen.transform.parent = _parent_mainCanvas.transform;


    }
    public void Restart()
    {

        StopCoroutine(_board.StartTimer);
        Time.timeScale = 1f;
     
        FindObjectOfType<AudioManager>().Play("coin");
        Invoke("ActualRestart", 0.5f);
    }

    void ActualRestart()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

    }

 
}
