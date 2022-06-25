using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FeaturedPrefab : MonoBehaviour
{
    public Sprite[] _gameObjects;
    // Start is called before the first frame update
    public GameObject questionMark;
    public GameObject BoxCollision;

    private void OnMouseDown()
    {

        if (Featured.Instance.instruction == false &&EventSystem.current.IsPointerOverGameObject() && Featured.Instance.screenActive == true ||GameManager.Instance.glassSearch == true || Board.Instance.pausePanelActive == true && EventSystem.current.IsPointerOverGameObject() )
        {
              print("gui"+ EventSystem.current.IsPointerOverGameObject());
            //It means clicked on panel. So we do not consider this as click on game Object. Hence returning. 
            return;
        } else if(Featured.Instance.instruction==true){
            FindObjectOfType<ClickSound>().Click();
            Featured.Instance.FeatureTileClicked();

            print("feauturetiile clicked");

           
        }
        else
        {
            //clicked directly on game object. 


            if (Featured.Instance.findScreen.activeSelf == false && Featured.Instance.screenActive == false && Board.Instance.gridPopulation == true && GameManager.Instance.glassSearch ==false)//
            {
                FindObjectOfType<ClickSound>().Click();
                //print("feauturetiile clicked");

                Featured.Instance.FeatureTileClicked();
            }

        }



    }

}


/*CODE TO PREVENT CLICKABLE ACTION  WHEN GUI IS ACTIVE*/
/*   if (EventSystem.current.IsPointerOverGameObject())
          {
            //It means clicked on panel. So we do not consider this as click on game Object. Hence returning. 
              return;
          }
          else{
                //clicked directly on game object. 
          }*/