using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance; // Singleton instance

    private int do�ru;
    public int totaldo�ru;
    private int yanl��;
    public int totalyanl��;
 
    private int coin;
    public int totalcoin;

    private Text do�ruText;
    private Text yanl��Text;
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

    public int Do�ru
    {
        get
        {
            return do�ru;
        }
        set
        {
            do�ru = value;
            if (do�ruText == null)
            {
          //      do�ruText = GameObject.Find("Toplamdo�ru").GetComponent<Text>();
            }
         //  do�ruText.text = "Do�ru say�s�: " + do�ru.ToString();
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

    public int Yanl��
    {
        get
        {
            return yanl��;
        }
        set
        {
            yanl�� = value;
            if (yanl��Text == null)
            {
            //    yanl��Text = GameObject.Find("ToplamYanl��").GetComponent<Text>();
            }
         //  yanl��Text.text = "Yanl�� Say�s�: " +yanl��.ToString();
        
        }
    }

    void StartProcess()
    {
        myFile = new EasyFileSave(); // dosya kaydedecek de�i�ken
        LoadData();
    }

    public void SaveData()
    {
        //Verileri kaydetme;
        totaldo�ru += do�ru;
        totalyanl��+=yanl��;
        totalcoin += coin;

        myFile.Add("totalDogru",totaldo�ru);
        myFile.Add("totalYanlis", totalyanl��);
        myFile.Add("totalCoin", totalcoin);

        myFile.Save();
    }

    public void LoadData()
    {
        //Kay�tl� verileri getirme
        if (myFile.Load())
        {
            totaldo�ru = myFile.GetInt("totalDogru");
            totalyanl��= myFile.GetInt("totalYanlis");
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
