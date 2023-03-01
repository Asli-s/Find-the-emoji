using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class findFeatureScreenAnim : MonoBehaviour
{
    // Start is called before the first frame update
    public static findFeatureScreenAnim Instance;


    [SerializeField] GameObject mainBlock ;
public GameObject featureImageObject;
    private Vector3 featureTile;
    public FeaturedPrefab featreTileInstantiated;
    public GameObject featureTileParent;
    public Camera cam;
    public GameObject backGround;
    public GameObject activateSelf;

    public GameObject Instructions;

    private Sprite featureTileSprite;

    private int _width = 4;
    private int _height = 4;
    private Vector3 cameraPos;
    public bool animEnded =false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        /*else return;*/
    }
    private void OnEnable()
    {
        if (GameManager.Instance.coinNotEnough == false)
        {
            Featured.Instance.screenActive = true;
          
            animateFindScreen();


        }
    }




    public void startFindScreenAnimation()
    {
        GameManager.Instance.ChangeState(GameState.GenerateGrid);
   
        animateFindScreen();


    }

    public void animateFindScreen()
   
    {


        Featured.Instance.screenActive = true;
        //TODO ---> move to onenable()


        /*DEACTIVE REAL FEAUTURE TILE */
        LeanTween.scale(featureTileParent, Vector3.zero, 0).setOnComplete(playSound); 
       

        /*MOVE DOWN MAIN BLOCK */
        LeanTween.moveLocal(mainBlock, new Vector3(0, 0, 0), 2.2f).setDelay(0.2f).setEaseOutElastic().setOnComplete(CheckFirstTime);
     
      

        /*POP FFEATURE TILE IMAGE*/
        LeanTween.scale(featureImageObject, new Vector3(2.9f, 2.9f, 3.7f), .6f).setDelay(0.5f).setEaseInOutElastic(); 
     Invoke("playSoundSlide", 2.9f);
        Invoke("littlePop", 0.86f);



        LeanTween.scale(backGround, Vector3.zero, 0.2f).setDelay(3.5f).setEaseOutElastic();


        /*FEATURE TILE MOVE UP*/
        if (GameManager.Instance.squarish)
        {
            LeanTween.move(featureImageObject.GetComponent<RectTransform>(), new Vector3(0, 335, 0), .3f).setDelay(3.5f).setEaseOutExpo()/*.setOnComplete(scaleBack)*/;
            LeanTween.move(featureImageObject.GetComponent<RectTransform>(), new Vector3(0, 335, 0), .3f).setDelay(3.8f).setEaseInElastic();

        }
        else
        {
            LeanTween.move(featureImageObject.GetComponent<RectTransform>(), new Vector3(0, 300, 0), .3f).setDelay(3.5f).setEaseOutExpo()/*.setOnComplete(scaleBack)*/;
            LeanTween.move(featureImageObject.GetComponent<RectTransform>(), new Vector3(0, 300, 0), .3f).setDelay(3.8f).setEaseInElastic();


        }

     
        /*FEATURE TILE SCALE BACK*/
      

        LeanTween.scale(featureImageObject, new Vector3(2.1f, 2.1f, 0), 1.51f).setDelay(3.6f).setEaseInElastic().setOnComplete(FeautureTileAppear); 
        Invoke("playSound2", 5f);




    }

    private void CheckFirstTime()
    {
        if (GameManager.Instance.firstTime == true)
        {
            Time.timeScale = 0;
            GameManager.Instance.firstFindScreen = true;
            Instructions.SetActive(true);

        }
        else
        {
            Time.timeScale = 1;
        }


    }



    void featureTileAppear()
    {
     

        featureTileParent.SetActive(true);
        LeanTween.scale(featureTileParent, new Vector3(12,12f,1), 0).setOnComplete(disAbleSelf);




    }
    void playSound()
    {
        FindObjectOfType<AudioManager>().Play("swipe",false);

    }
    void playSound2()
    {
   
        FindObjectOfType<PlayExtraSound>().Play("click");
       

    }

    void FeautureTileAppear()
    {
       
     
        featureTileAppear();

    }

    void playSoundSlide()
    {
        FindObjectOfType<AudioManager>().Play("swipe", false);

      

    }
    void littlePop()
    {
        FindObjectOfType<PlayExtraSound>().Play("littlePop");

    }
    void disAbleSelf()
    {

        if (Board.Instance.gridPopulation == false)
        {

        Board.Instance.PopSprite();

      
        }
        Featured.Instance.screenActive = false;

        gameObject.SetActive(false);
        //

        Board.Instance.findScreenFinished = true;

        animEnded = true; //--> needed for menu button click


        //set everything back
        LeanTween.moveLocal(mainBlock, new Vector3(0, 2067,1), 0f);
        LeanTween.scale(featureImageObject, new Vector3(1f, 1f, 1f), 0);
        LeanTween.moveLocal(featureImageObject, new Vector3(0, 0f,1f), 0);
        LeanTween.scale(featureImageObject, new Vector3(1f, 1f, 1f), 0);
    //    LeanTween.scale(featureTileParent, new Vector3(1f, 1f, 1), 0);
        LeanTween.scale(backGround, Vector3.one, 0f);



    }


 
}











