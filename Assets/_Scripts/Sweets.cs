using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweets : MonoBehaviour
{
    // Start is called before the first frame update
    public static Sweets Instance;
    [SerializeField]private  TMPro.TextMeshProUGUI SweetLolli;
    [SerializeField] private TMPro.TextMeshProUGUI SweetBonbon;

    public GameObject LolliAnim;

    public CanvasGroup backgroundPanel;
    public GameObject backgroundPanelGameObject;


    [SerializeField] private GameObject AlreadyUsedAlert;
    [SerializeField] private Board _board;


  public  bool lolliClicked = false;
    bool bonbonClicked = false;

    public bool alreadyUsed = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }


   public void DisplaySweetCount()
    {
        print("extrasweetlolli"+GameManager.Instance.ExtraSweetLolli);

        SweetLolli.text = GameManager.Instance.ExtraSweetLolli.ToString();
        SweetBonbon.text = GameManager.Instance.ExtraSweetBonbon.ToString();
    }

   
    public void UseLolli()
    {
        if (_board.checkForPopFinish == true)
        {
            if (lolliClicked == false)
            {
                print("lolli clicked");
                lolliClicked = true;
                if (GameManager.Instance.ExtraSweetLolli > 0 && alreadyUsed == false)
                {
                    // reduce one 
                    // open featureTile not close --> try destroy child object

                    //animation
                    backgroundPanelGameObject.SetActive(true);
                    backgroundPanel.LeanAlpha(0, 0);

                    backgroundPanel.LeanAlpha(1, 0.2f);
                    LolliAnim.SetActive(true);

                    alreadyUsed = true;
                }
                else if (alreadyUsed == true)
                {
                    AlreadyUsedAlert.SetActive(true);
                   

                    // ypu already used this 
                }
                else if (GameManager.Instance.ExtraSweetLolli == 0)
                {
                    //showAlert (sorry not enough sweets)
                    lolliClicked = false;
                }
            }



        }
    }

    public void UseBonbon()
    {
        if (bonbonClicked == false)
        {
            bonbonClicked = true;
            if (GameManager.Instance.ExtraSweetBonbon > 0)
            {
                // reduce one 
                // open featureTile not close --> try destroy child object
                backgroundPanel.LeanAlpha(0, 0);

                backgroundPanel.LeanAlpha(1, 0.2f);
                bonbonClicked = false;

            }
            else
            {
                //showAlert (sorry not enough sweets)
                bonbonClicked = false;
            }
        }




    }


}
