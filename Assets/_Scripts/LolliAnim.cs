using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LolliAnim : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Lolli;
    public GameObject backgroundPanelGameObject;

    public GameObject featureTileParent;
    public GameObject CrackParent;
    [SerializeField] private GameObject Top;
    [SerializeField] private GameObject Bottom;
    [SerializeField] private GameObject Left;
    [SerializeField] private GameObject Right;
    public Board Board;


    private void Start()
    {
      //  Lolli.GetComponent<RectTransform>().transform.position = new Vector3(0, -1200, 0);
    }


    //top 50y
    //left -50x
    //bottm -50x
    //right 50x

    private void OnEnable()
    {
        if (Board.Instance.paused == false)
        {
            print("paused?? " + Board.Instance.paused);
            Board.Instance.pauseBoard();
        }
        FindObjectOfType<AudioManager>().Play("slide");
            LeanTween.moveLocal(Lolli.GetComponent<RectTransform>().gameObject, new Vector3(150.5f, 245, 1), 1.2f).setEaseOutElastic();
        LeanTween.rotate(Lolli.GetComponent<RectTransform>().gameObject, new Vector3(0,0 , -70), 1f).setEaseOutElastic().setDelay(.8f).setOnComplete(Crack);


        //animate hit
       /* LeanTween.scale(Lolli.GetComponent<RectTransform>(), new Vector3(2.4f, 2.4f,1), .5f).setEaseInElastic().setDelay(.8f).setOnComplete(PlayCrackSound);
        LeanTween.scale(Lolli.GetComponent<RectTransform>(), new Vector3(1.8f, 1.8f, 1), .5f).setEaseInElastic().setDelay(1.4f);
*/

        LeanTween.rotate(Lolli.GetComponent<RectTransform>().gameObject, new Vector3(0f, 0f, -40), .3f).setEaseInElastic().setDelay(1.5f).setOnComplete(PlayCrackSound);


        //scale down
        LeanTween.scale(Lolli.GetComponent<RectTransform>(), new Vector3(0f, 0f, 1), .2f).setDelay(2.5f).setOnComplete(DeactiveGameObject);


    }

    void PlayCrackSound()
    {
        CrackParent.SetActive(true);

        LeanTween.moveLocal(Left.GetComponent<RectTransform>().gameObject, new Vector3(-50,0,0), .5f);
        LeanTween.moveLocal(Right.GetComponent<RectTransform>().gameObject, new Vector3(50, 0, 0), .5f);
        LeanTween.moveLocal(Top.GetComponent<RectTransform>().gameObject, new Vector3(50, 0, 0), .5f);   
        LeanTween.moveLocal(Bottom.GetComponent<RectTransform>().gameObject, new Vector3(-50, 0, 0), 54f);

        Invoke("OpenTile",0.8f);
    }

    void OpenTile()
    {
        Destroy(featureTileParent.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject);
        CrackParent.SetActive(false);
        FindObjectOfType<AudioManager>().Play("bubble");



    }
    void Crack()
    {
        FindObjectOfType<AudioManager>().Play("crack");
    }

    void DeactiveGameObject()
    {
        //after anim completion deactivate gameobject;
        if (Board.Instance.paused == true)
        {
            Featured.Instance.screenActive = true;
            print("paused?? " + Board.Instance.paused);
            Board.Instance.pauseBoard();
        }
        Sweets.Instance.lolliClicked = false;
        gameObject.SetActive(false);
        Featured.Instance.screenActive = false;
   //     GameManager.Instance.SweetCoverHammer.SetActive(true);
        backgroundPanelGameObject.SetActive(false);
          Lolli.GetComponent<RectTransform>().transform.localPosition = new Vector3(0, -1200, 1);
        Lolli.GetComponent<RectTransform>().transform.localScale = new Vector3(1.7f, 1.7f,1);
        Lolli.GetComponent<RectTransform>().transform.eulerAngles = new Vector3(0,0,0);



    }

}
