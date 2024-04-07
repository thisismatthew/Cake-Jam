using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Collider2D>().enabled = false;
        other.transform.parent = this.transform;
    }

    public void ClearPlate()
    {
        while( transform.childCount != 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
