using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public bool active = true;
    public GameObject HeldItem;
    private Vector2 offsetPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!active) return;

        if(Input.GetMouseButtonDown(0))
        {
            if (HeldItem != null)
            {
                HeldItem.GetComponent<Collider2D>().enabled = true;
                HeldItem = null;
                return;
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null)
            {
                HeldItem = hit.transform.gameObject;
                // Calculate the offset at the moment of grabbing
                offsetPos = (Vector2)HeldItem.transform.position - (Vector2)ray.origin;
                HeldItem.GetComponent<Collider2D>().enabled = false;
            }
        }

        if (HeldItem != null)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Apply the offset when setting the position
            HeldItem.transform.position = pos + offsetPos;
        }
    }
}
