using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CakeRefresh : MonoBehaviour
{
    public GameObject CakePrefab;
    [SerializeField] private Vector3 cakeStartPos;
    

    public void RefreshCake()
    {
        GameObject[] oldCake = GameObject.FindGameObjectsWithTag("Cake");
        foreach (GameObject cake in oldCake)
        {
            Destroy(cake);
        }
        GameObject newCake = Instantiate(CakePrefab);
        newCake.transform.parent = transform;
        newCake.transform.localPosition = cakeStartPos;
        newCake.transform.DOScale(4f, .1f);
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.A))
        {
            RefreshCake();
        }*/
    }
}
