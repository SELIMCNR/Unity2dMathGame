using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject karePrefab;

    [SerializeField]
    private Transform karelerPaneli;
    [SerializeField]
    private Text SoruText;

    private GameObject[] karelerDizisi = new GameObject[25];
    // Start is called before the first frame update

    [SerializeField]
    private Transform soruPaneli;


    [SerializeField]
    private Sprite[] kareSprites;


    List<int> bolumDegerleriListesi = new List<int>();


    int bolunenSayi, bolenSayi;
    int kacinciSoru;
    int dogruSonuc;

    int butonDegeri;

    bool buttonaBasýlsýnMi = false;


    int kalanHak;

    string sorununzorlukSeviyesi;

    kalanHakManager kalanHakManager;

    PuanManager puanManager;

    GameObject gecerliKare;

    [SerializeField]
    private GameObject sonucPaneli;


    [SerializeField]
    private AudioSource audioSource;

    public AudioClip buttonSesi;


    private void Awake()
    {
        kalanHak = 3;

        audioSource = GetComponent<AudioSource>();

        sonucPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;


        kalanHakManager = Object.FindAnyObjectByType<kalanHakManager>();
        puanManager = Object.FindAnyObjectByType<PuanManager>();
        
        
        kalanHakManager.KalanHaklariKontrolEt(kalanHak);
    }
    void Start()
    {
        soruPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;

        kareleriOlustur();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void kareleriOlustur()
    {
        for (int i = 0; i < 25; i++){
            GameObject Kare=Instantiate(karePrefab,karelerPaneli);
            Kare.transform.GetChild(1).GetComponent<Image>().sprite = kareSprites[Random.Range(0,kareSprites.Length)];
            Kare.transform.GetComponent<Button>().onClick.AddListener(()=>ButtonaBasýldý()); 
            karelerDizisi[i]= Kare;
        }
        BolumDegerliniTexteYazdýr();
        StartCoroutine(DoFadeRoutine());
        Invoke("SoruPaneliniAc", 1f);
    }
    void ButtonaBasýldý()
    {
        if (buttonaBasýlsýnMi)
        {
            audioSource.PlayOneShot(buttonSesi);

            butonDegeri = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);

            Debug.Log(butonDegeri);

            gecerliKare = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;


            SonucuKontrolEt();
        }
      
    }

    void SonucuKontrolEt()
    {
        if (butonDegeri == dogruSonuc)
        {
            gecerliKare.transform.GetChild(1).GetComponent<Image>().enabled = true;
            gecerliKare.transform.GetChild(0).GetComponent<Text>().text = "";
            gecerliKare.transform.GetComponent<Button>().interactable = false;

            DataManager.Instance.Doðru++;

            puanManager.PuanArtýr(sorununzorlukSeviyesi);
            bolumDegerleriListesi.RemoveAt(kacinciSoru);
            Debug.Log(bolumDegerleriListesi.Count);
            if(bolumDegerleriListesi.Count> 0)
            {
                SoruPaneliniAc();
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {

            DataManager.Instance.Yanlýþ++;
            kalanHak--;
            kalanHakManager.KalanHaklariKontrolEt(kalanHak); 
        }
        if(kalanHak <= 0)
        {
            OyunBitti();
        }
    }

    void OyunBitti()
    {
        buttonaBasýlsýnMi = false;
       sonucPaneli.GetComponent<RectTransform>().DOScale(1,0.3f).SetEase(Ease.OutBack);  
      
    }
    IEnumerator DoFadeRoutine()
    {
        foreach(var kare in karelerDizisi)
        {
            kare.GetComponent<CanvasGroup>().DOFade(1, 0.2f);
            yield return new WaitForSeconds(0.07f);

        }
    }

    void BolumDegerliniTexteYazdýr()
    {
        foreach(var kare in karelerDizisi)
        {
            int rastgeleDeger = Random.Range(1, 13);
            bolumDegerleriListesi.Add(rastgeleDeger);
            kare.transform.GetChild(0).GetComponent<Text>().text = rastgeleDeger.ToString();

        }
        
    }
    void SoruPaneliniAc()
    {
        SoruyuSor();
        buttonaBasýlsýnMi = true;
        soruPaneli.GetComponent<RectTransform>().DOScale(1, 0.1f).SetEase(Ease.OutBack);

    }

    void SoruyuSor()
    {
        bolenSayi = Random.Range(2, 11);
        kacinciSoru = Random.Range(0, bolumDegerleriListesi.Count);
        Debug.Log(kacinciSoru);

        dogruSonuc = bolumDegerleriListesi[kacinciSoru];


        bolunenSayi = bolenSayi * bolumDegerleriListesi[kacinciSoru];


        if (bolunenSayi <= 40)
        {
            sorununzorlukSeviyesi = "kolay";
        }

        else if(bolunenSayi>40 && bolunenSayi <= 80)
        {
            sorununzorlukSeviyesi = "orta";
        }
        else
        {
            sorununzorlukSeviyesi = "zor";
        }

        SoruText.text = bolunenSayi.ToString() + " : " + bolenSayi.ToString();

    }
}
