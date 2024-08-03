using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuanManager : MonoBehaviour
{

    private int toplamPuan;
    private int puanArtisi;

    [SerializeField]
    private Text puanText;


    // Start is called before the first frame update
    void Start()
    {
        puanText.text = toplamPuan.ToString(); 
/*
        if (SceneManager.sceneCount == 2 )
        {
            puanText.text = DataManager.Instance.Coin.ToString();
        }
*/
        
    }

  public  void PuanArtýr(string zorlukSeviyesi)
    {
        switch (zorlukSeviyesi)
        {
            case "kolay":
                puanArtisi += 5;
                DataManager.Instance.Coin += 5;
                break;
            case "orta":
                puanArtisi += 10;
                DataManager.Instance.Coin += 10;
                break;
            case "zor":
                puanArtisi += 15;
                DataManager.Instance.Coin += 15;
                break;
        }
        toplamPuan += puanArtisi;
        puanText.text = toplamPuan.ToString();


    }


}
