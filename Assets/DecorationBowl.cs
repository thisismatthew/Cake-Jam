using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationBowl : MonoBehaviour
{
    
    [SerializeField] public GameObject currentDecoration;
    private bool curentDecorationSet = false;
    // Start is called before the first frame update
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (curentDecorationSet)
        {
            if (transform.childCount < 7)
            {
                TopUpBowl();
            }
        }
    }

    private void TopUpBowl()
    {
        //places decoration in random positions in the bowl
        Vector3 position = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0);
        GameObject decoration = Instantiate(currentDecoration, transform.position + position, Quaternion.identity);
        decoration.transform.SetParent(transform);
    }

    public void setBowlDecoration(GameObject decoration)
    {
        currentDecoration = decoration;
        curentDecorationSet = true;
    }
    
    //empties the bowl, sets the current decoration to null, and sets the current decoration set to false
    public void EmptyBowl()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        currentDecoration = null;
        curentDecorationSet = false;
        
    }
    
}
