using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct CakeCardData
{
    public Image img;
    public CakeCardType type;
}
public class CardManager : MonoBehaviour
{
    private CakeCardType currentType;
    public Image ActiveCardImage;
    public GameObject CardSelector;
    public Grabber grabberRef;
    public void SetActiveCard(Sprite img, CakeCardType type)
    {
        ActiveCardImage.transform.parent.gameObject.SetActive(true);
        ActiveCardImage.sprite = img;
        currentType = type;
    }

    public void OpenCardScroller()
    {
        CardSelector.SetActive(true);
        grabberRef.gameObject.SetActive(false);
        FindObjectOfType<MouseMovesCamNearScreenEdge>().enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        grabberRef = FindObjectOfType<Grabber>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
