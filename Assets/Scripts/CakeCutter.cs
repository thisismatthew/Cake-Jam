using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CakeCutter : MonoBehaviour
{
    [SerializeField] private GameObject CutterPrefabShape;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null)
            {
                //We've clicked on a a bit of cake! Cut OUt a chunk by giving it a duplicate of a sprite mask
                Debug.Log("CLICKED " + hit.collider.name);
                GameObject c = Instantiate(CutterPrefabShape, transform.position, Quaternion.identity);
                c.transform.SetParent(hit.collider.transform.parent);

                GameObject newSlice = Instantiate(hit.transform.parent.gameObject, hit.transform.position, Quaternion.identity);
                newSlice.AddComponent<SortingGroup>();
                SpriteRenderer newRenderer = newSlice.GetComponentInChildren<SpriteRenderer>();
                newSlice.transform.position = hit.transform.parent.position;
                newRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                
                //remove its collider and give it a new collider of the type of the cutter
                //also find and remove all its other sprite masks
                
            }
        }
    }
}


