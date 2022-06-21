using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetEssential : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject mainBlock;
    public Texture Heart;
    public Texture Coin;
    [SerializeField] public TMPro.TextMeshProUGUI wonItemText;

    public RawImage essentialImageRaw;
    public GameObject essentialImage;

    bool animCompleted = false;
    bool clicked = false;

    public GameObject wonEssentialInventoryScreen;

   


    private void OnEnable()
    {
        essentialImageRaw = essentialImage.GetComponent<RawImage>(); 



        clicked = false;
        animCompleted = false;

        if (Board.Instance.paused == false)
        {
            Board.Instance.pauseBoard();
        }
        Featured.Instance.screenActive = true;


        LeanTween.scale(mainBlock, new Vector3(1f, 1f, 1), 0.5f).setEaseOutExpo().setOnComplete(ChangeScreenActive);




        if (
        GameManager.Instance.nextEssentialCoin  == true)
        {
            essentialImageRaw.texture = Coin;
            wonItemText.text = "COIN";
            GameManager.Instance.ExtraCoin += 1;
            DataPersistenceManager.Instance.SaveGame();
        }
        else
        {
            essentialImageRaw.texture = Heart;

            wonItemText.text = "HEART";
            GameManager.Instance.ExtraLife += 1;
            DataPersistenceManager.Instance.SaveGame();
        }


    }
    void ChangeScreenActive()
    {
        animCompleted = true;
    }

    private void Update()
    {

        if (Input.GetMouseButtonUp(0) && animCompleted == true)
        {


            if (clicked == false)
            {
                clicked = true;

                gameObject.SetActive(false);
                wonEssentialInventoryScreen.SetActive(true);
                //activate next screen 


            }
        }

    }
}
