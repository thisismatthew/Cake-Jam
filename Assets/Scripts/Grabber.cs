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
                HeldItem = null;
                return;
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null)
            {
                HeldItem = hit.transform.gameObject;
                offsetPos = HeldItem.transform.position;
            }
        }

        if (HeldItem != null)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 center = HeldItem.GetComponent<PolygonCollider2D>().bounds.center;
            Debug.DrawLine(center, pos, Color.red);
            Debug.Log("Items Actual Pos:" + HeldItem.transform.position + " | center of it:" + center + " | mouseposition: " +pos);
            HeldItem.transform.position = pos;
            
        }
    }
}
