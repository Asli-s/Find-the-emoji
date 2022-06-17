using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassAnim : MonoBehaviour
{
    // Start is called before the first frame update


    // Start is called before the first frame update
    [SerializeField] private GameObject Glass;
    public GameObject backgroundPanelGameObject;
    public Vector3 goalVector = new Vector3(0, 0, 0);
    Vector3[] vectorList = new[] { new Vector3(-206f,-463f,  1f), new Vector3(39f, 236f, 1f), new Vector3(335, -342, 1f) };
    int posInArray = 0;
    public CanvasGroup backPanel;

    private void OnEnable()
    {




                    GameManager.Instance.glassSearch = true;
        if (Board.Instance.paused == false)
        {
            print("paused?? " + Board.Instance.paused);
            Board.Instance.pauseBoard();
        }

        Board.Instance.appearedForSeach = 0;
        Board.Instance.resetappearedForSeachCounter = true;


        //checkifInCurrentnodes
        Board.Instance.checkCurrentNodes(); 
        





        //leanAnim


        if (Board.Instance.foundSearchedTile ==false) // not found  // move glass else new place goalvecttor
        {
            if(posInArray == 0)
            {
                LeanTween.moveLocal(Glass.GetComponent<RectTransform>().gameObject, vectorList[posInArray], .9f).setOnComplete(NextLocation);
            
            }
            else if(posInArray == 1)
            {
                LeanTween.moveLocal(Glass.GetComponent<RectTransform>().gameObject, vectorList[posInArray], .9f).setOnComplete(NextLocation);

            }else if (posInArray == 2)
            {
                LeanTween.moveLocal(Glass.GetComponent<RectTransform>().gameObject, vectorList[posInArray], .9f).setOnComplete(NextLocation);


            }
        }
        else
        {
            print("goalvector " + goalVector);

            LeanTween.moveLocal(Glass.GetComponent<RectTransform>().gameObject, goalVector, .5f).setOnComplete(DeactiveGameObject);
            backPanel.LeanAlpha(1, 0.2f);
           // Glass.SetActive(false);

        }


    }

    void MoveLocation()
    {

        if (Board.Instance.foundSearchedTile == false) // not found  // move glass else new place goalvecttor
        {
            if (posInArray == 0)
            {
                LeanTween.moveLocal(Glass.GetComponent<RectTransform>().gameObject, vectorList[posInArray], .9f).setOnComplete(NextLocation);

            }
            else if (posInArray == 1)
            {
                LeanTween.moveLocal(Glass.GetComponent<RectTransform>().gameObject, vectorList[posInArray], .9f).setOnComplete(NextLocation);

            }
            else if (posInArray == 2)
            {
                LeanTween.moveLocal(Glass.GetComponent<RectTransform>().gameObject, vectorList[posInArray], .9f).setOnComplete(NextLocation);


            }
        }
        else
        {
            print("goalvector " + goalVector);

            LeanTween.moveLocal(Glass.GetComponent<RectTransform>().gameObject, goalVector, .5f).setOnComplete(DeactiveGameObject);
            backPanel.LeanAlpha(1, 0.2f);

        }

    }

    void NextLocation()

    {
        if(posInArray < 2)
        {
            posInArray += 1;
            MoveLocation();
        }
        else if(posInArray ==2)
        {
            posInArray = 0;
                MoveLocation();
        }

    }










    void DeactiveGameObject()
    {
        //after anim completion deactivate gameobject;
     /*   if (Board.Instance.paused == true)
        {
            Featured.Instance.screenActive = true;
            print("paused?? " + Board.Instance.paused);
            Board.Instance.pauseBoard();
        }*/
        Sweets.Instance.bonbonClicked = false;
        Glass.SetActive(false);
    //    Featured.Instance.screenActive = false;

 /*       backgroundPanelGameObject.SetActive(false);
        Glass.GetComponent<RectTransform>().transform.localPosition = new Vector3(0, -1200, 1);
     //   Glass.GetComponent<RectTransform>().transform.localScale = new Vector3(1.7f, 1.7f, 1);
        Glass.GetComponent<RectTransform>().transform.eulerAngles = new Vector3(0, 0, 0);
*/


    }


}
