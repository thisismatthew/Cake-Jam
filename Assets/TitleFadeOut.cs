using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TitleFadeOut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartGame", 2f);
    }

    public void StartGame()
    {
        GetComponent<Image>().DOFade(0, .5f);
        FindObjectOfType<FaxMachineManager>().NewTask();
    }
    
}
