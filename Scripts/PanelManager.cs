using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PanelManager : MonoBehaviour
{

    [SerializeField]
    private GameObject panel;
    [SerializeField]

    // Start is called before the first frame update
    void Start()
    {
        FadeOut();
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FadeOut()
    {
        panel.GetComponent<CanvasGroup>().DOFade(0, 0.8f);
       
    }
}
