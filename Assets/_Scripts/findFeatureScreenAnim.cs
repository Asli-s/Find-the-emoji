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
            /*    setActive();*/

            // featureImageObject.GetComponent<Image>().sprite= Featured.Instance.tile.GetComponent<SpriteRenderer>().sprite;
            /* featureTileSprite = Featured.Instance.tile.GetComponent<SpriteRenderer>().sprite;
             featureImageObject.GetComponent<Image>().sprite = featureTileSprite;
           */
            animateFindScreen();


        }
    }



/*    void setActive()
    {
        if (Featured.Instance.screenActive == false)
        {
            Featured.Instance.setScreenActiveToTrue();
        }

    }*/

    public void startFindScreenAnimation()
    {
        GameManager.Instance.ChangeState(GameState.GenerateGrid);
        // activateSelf.SetActive(true);
        animateFindScreen();

//        print("WELCOOOME");
    }

    public void animateFindScreen()
   
    {


        Featured.Instance.screenActive = true;
        //TODO ---> move to onenable()


        /*DEACTIVE REAL FEAUTURE TILE */
        LeanTween.scale(featureTileParent, Vector3.zero, 0).setOnComplete(playSound); 
        // featureTileParent.SetActive(false);

        /*MOVE DOWN MAIN BLOCK */
        LeanTween.moveLocal(mainBlock, new Vector3(0, 0, 0), 1.9f).setDelay(0.2f).setEaseOutElastic();
        //LeanTween.moveLocal(mainBlock, new Vector3(0,0,0),1.5f).setDelay(0f).setEaseOutElastic();



        /*POP FFEATURE TILE IMAGE*/
        LeanTween.scale(featureImageObject, new Vector3(3.7f, 3.7f, 3.7f), 1.6f).setDelay(0.5f).setEaseOutElastic(); //.setOnComplete(playSoundSlide);
     Invoke("playSoundSlide", 2.9f);



        LeanTween.scale(backGround, Vector3.zero, 0.6f).setDelay(3.5f).setEaseOutElastic();


        /*FEATURE TILE MOVE UP*/
        LeanTween.move(featureImageObject.GetComponent<RectTransform>(), new Vector3(0, 401, 0), .4f).setDelay(3.6f).setEaseOutExpo()/*.setOnComplete(scaleBack)*/;
        LeanTween.move(featureImageObject.GetComponent<RectTransform>(), new Vector3(0, 401, 0),.3f).setDelay(4f).setEaseInElastic();

        //   LeanTween.move(featureImageObject.GetComponent<RectTransform>(),new Vector3(0,381,0),4f).setDelay(3.4f).setEaseOutElastic()/*.setOnComplete(scaleBack)*/;


        /*FEATURE TILE SCALE BACK*/
        // LeanTween.scale(featureImageObject,  new Vector3(3,3,0), 1.6f).setDelay(2.6f).setEaseInBack();

        LeanTween.scale(featureImageObject, new Vector3(3, 3, 0), 1.51f).setDelay(3.6f).setEaseInElastic().setOnComplete(playSound2); //.setOnComplete(featureTileAppear);



    }

 

    void featureTileAppear()
    {
     //   playSound2();


        featureTileParent.SetActive(true);
        LeanTween.scale(featureTileParent, new Vector3(13,13f,1), 0).setOnComplete(disAbleSelf);




    }
    void playSound()
    {
        FindObjectOfType<AudioManager>().Play("swipe",false);

    }
    void playSound2()
    {
        FindObjectOfType<AudioManager>().Play("click");
        featureTileAppear();

    }

    void playSoundSlide()
    {
        FindObjectOfType<AudioManager>().Play("slide");
     

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












//

/*  float distance = transform.position.z - cam.transform.position.z;
  print(distance);
  print(cam.ScreenToWorldPoint(new Vector3(transform.position.x, transform.position.y, distance)));

  cameraPos = cam.ScreenToWorldPoint(new Vector3(transform.position.x, transform.position.y, distance));

  //WHY IS CAMERA POS NOT AT CENTER?
  print(featreTileInstantiated.transform.position);*/
//feature tile move to final position
//10/2 - 0.23f =4.88
//  LeanTween.move(featureImageObject.GetComponent<RectTransform>(), new Vector3(center.x,( 5 - 0.23f)*10, 10),1f).setDelay(3f).setEaseOutElastic();
//   LeanTween.move(featureImageObject.GetComponent<RectTransform>(), new Vector3(0,377.5f,0),1f).setDelay(3f).setEaseOutElastic();

//  featureImageObject.transform.localPosition = new Vector3(0,27,0);

//LeanTween.move(featureImageObject.GetComponent<RectTransform>(), Vector3.zero, 1f).setDelay(3f).setEaseOutElastic();
