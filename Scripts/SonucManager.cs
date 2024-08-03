using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SonucManager : MonoBehaviour
{

    public void OyunaYenidenBasla()
    {
        SceneManager.LoadScene("gameLevel");
        DataManager.Instance.SaveData();
    }

    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("startschene");
        DataManager.Instance.SaveData();
    }

}
