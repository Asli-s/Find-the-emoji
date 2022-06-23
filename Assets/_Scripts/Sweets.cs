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
    public GameObject GlassAnim;


    public CanvasGroup backgroundPanel;
    public GameObject backgroundPanelGameObject;


    [SerializeField] private GameObject AlreadyUsedAlertHammer;
    [SerializeField] private Board _board;



    [SerializeField] private GameObject NotEnoughAxe;
    [SerializeField] private GameObject NotEnoughGlass;




    public bool lolliClicked = false;
  public  bool bonbonClicked = false;

    public bool alreadyUsedLolli = false;
    public bool alreadyUsedBonbon = false;


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
                if (GameManager.Instance.ExtraSweetLolli > 0 && alreadyUsedLolli == false)
                {
                    // reduce one 
                    // open featureTile not close --> try destroy child object

                    //animation

                    GameManager.Instance.ExtraSweetLolli -= 1;
                    SweetLolli.text = GameManager.Instance.ExtraSweetLolli.ToString();

                    alreadyUsedLolli = true;

                    backgroundPanelGameObject.SetActive(true);
                    backgroundPanel.LeanAlpha(0, 0);

                    backgroundPanel.LeanAlpha(1, 0.2f);
                    LolliAnim.SetActive(true);
                    DataPersistenceManager.Instance.SaveGame();

                }
                else if (alreadyUsedLolli == true)
                {
                    AlreadyUsedAlertHammer.SetActive(true);
                   

                    // ypu already used this 
                }
                else if (GameManager.Instance.ExtraSweetLolli == 0)
                {
                    //showAlert (sorry not enough sweets)
                    NotEnoughAxe.SetActive(true);
                    lolliClicked = false;
                }
            }



        }
    }

    public void UseBonbon()
    {
        if (_board.checkForPopFinish == true)
        {
            if (bonbonClicked == false)
            {
                bonbonClicked = true;
                if (GameManager.Instance.ExtraSweetBonbon > 0 && alreadyUsedBonbon ==false)
                {
                    // reduce one 
                    // open featureTile not close --> try destroy child object
                    GameManager.Instance.ExtraSweetBonbon -= 1;
                    SweetBonbon.text = GameManager.Instance.ExtraSweetBonbon.ToString();

                    backgroundPanelGameObject.SetActive(true);


                    backgroundPanel.LeanAlpha(0, 0);
                    alreadyUsedBonbon = true;
                    GlassAnim.SetActive(true);
                    backgroundPanel.LeanAlpha(1, 0.2f);
                    DataPersistenceManager.Instance.SaveGame();

                   // bonbonClicked = false;
                   // alreadyUsedBonbon = true;
                }
                else if(alreadyUsedBonbon == true)
                {
                    //activate already used or active alert
                }
                else if(GameManager.Instance.ExtraSweetBonbon == 0)
                {
                    //showAlert (sorry not enough sweets)
                    //  NotEnoughGlass.SetActive(true);
                    NotEnoughGlass.SetActive(true);
                    bonbonClicked = false;
                }
            }
        }



    }


}
