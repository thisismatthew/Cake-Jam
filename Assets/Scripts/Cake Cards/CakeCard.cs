using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class CakeCard : MonoBehaviour
{
    public CakeCardType cakeType;
    private CardManager _manager;
    private void Start()
    {
        _manager = FindObjectOfType<CardManager>();
    }
    public void SelectCard()
    {
        _manager.SetActiveCard(transform.GetChild(0).GetComponent<Image>().sprite, cakeType);
        _manager.CardSelector.SetActive(false);
        _manager.grabberRef.gameObject.SetActive(true);
        FindObjectOfType<MouseMovesCamNearScreenEdge>().enabled = true;


    }
}

