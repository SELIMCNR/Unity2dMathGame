using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance; // Singleton instance

    private int doðru;
    public int totaldoðru;
    private int yanlýþ;
    public int totalyanlýþ;
 
    private int coin;
    public int totalcoin;

    private Text doðruText;
    private Text yanlýþText;
    private Text cointext;



    EasyFileSave myFile; // 

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist through scenes
            StartProcess();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Example update logic, if needed
    }

    public int Doðru
    {
        get
        {
            return doðru;
        }
        set
        {
            doðru = value;
            if (doðruText == null)
            {
          //      doðruText = GameObject.Find("Toplamdoðru").GetComponent<Text>();
            }
         //  doðruText.text = "Doðru sayýsý: " + doðru.ToString();
        }
    }

    public int Coin
    {
        get
        {
            return coin;
        }
        set
        {
            coin = value;
            if (cointext == null)
            {
            //   cointext = GameObject.Find("Puan").GetComponent<Text>();
            }
         //   cointext.text = "Puan: " + coin.ToString();
          print(coin);
        }
    }

    public int Yanlýþ
    {
        get
        {
            return yanlýþ;
        }
        set
        {
            yanlýþ = value;
            if (yanlýþText == null)
            {
            //    yanlýþText = GameObject.Find("ToplamYanlýþ").GetComponent<Text>();
            }
         //  yanlýþText.text = "Yanlýþ Sayýsý: " +yanlýþ.ToString();
        
        }
    }

    void StartProcess()
    {
        myFile = new EasyFileSave(); // dosya kaydedecek deðiþken
        LoadData();
    }

    public void SaveData()
    {
        //Verileri kaydetme;
        totaldoðru += doðru;
        totalyanlýþ+=yanlýþ;
        totalcoin += coin;

        myFile.Add("totalDogru",totaldoðru);
        myFile.Add("totalYanlis", totalyanlýþ);
        myFile.Add("totalCoin", totalcoin);

        myFile.Save();
    }

    public void LoadData()
    {
        //Kayýtlý verileri getirme
        if (myFile.Load())
        {
            totaldoðru = myFile.GetInt("totalDogru");
            totalyanlýþ= myFile.GetInt("totalYanlis");
            totalcoin = myFile.GetInt("totalCoin");
        }
    }

    public void WinProcces()
    {

      
    }
    public void LoseProcces()
    {
    
    }
}
