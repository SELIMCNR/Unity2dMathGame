using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startBtn, exitBtn,panel;

    [SerializeField]
    private Text doðru, yanlýþ, puan;
    // Start is called before the first frame update
    void Start()
    {
        FadeOut();
        DataManager.Instance.LoadData();
        DataManager.Instance.SaveData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FadeOut()
    {
        startBtn.GetComponent<CanvasGroup>().DOFade(1,0.8f);
        exitBtn.GetComponent<CanvasGroup>().DOFade(1, 0.8f).SetDelay(0.5f);
        DataManager.Instance.LoadData();
    }

    public void exit()
    {
        Application.Quit();
    }

    public void startGameLevel()
    {
        SceneManager.LoadScene("gameLevel");
        DataManager.Instance.LoadData();
    }

    public void Sonuc()
    {
        panel.SetActive(true);
        startBtn.SetActive(false);
        exitBtn.SetActive(false);

        doðru.text = "Toplam doðru :" + DataManager.Instance.totaldoðru.ToString();
        yanlýþ.text = "Toplam yanlýþ : " + DataManager.Instance.totalyanlýþ.ToString();
        puan.text = "Toplam puan : " + DataManager.Instance.totalcoin.ToString() ;

    }

  public  void exitBtnpnl()
    {
        panel.SetActive(false);
        startBtn.SetActive(true);
        exitBtn.SetActive(true);
    }
}
