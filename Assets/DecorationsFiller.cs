using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationsFiller : MonoBehaviour
{
    
    public GameObject[] decorations;
    public string[] decorationNames;    
    
    
    // Start is called before the first frame update
    void Start()
    {
        //setTestDecorations();
        decorations[0] = Resources.Load<GameObject>("Decorations/ChocFinger");
        decorations[1] = Resources.Load<GameObject>("Decorations/Freckle");
        decorations[2] = Resources.Load<GameObject>("Decorations/LicoriceAllSort");
        decorations[3] = Resources.Load<GameObject>("Decorations/Snake");
        decorations[4] = Resources.Load<GameObject>("Decorations/SpearmintLeaf");
        decorations[5] = Resources.Load<GameObject>("Decorations/Teeth");
    }

    // Update is called once per frame
    void Update()
    {
        
        //check if spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetDecorationsInChildBowls(decorations);
        }
        //if number key is pressed add decoration to the bowl
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            addDecoration(decorations[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            addDecoration(decorations[1]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            addDecoration(decorations[2]);
        }
        
        //if e is pressed empty all the bowls
        if (Input.GetKeyDown(KeyCode.E))
        {
            EmptyBowls();
        }
    }
    
    //TESTING
    private void setTestDecorations(){
        decorations[0] = Resources.Load<GameObject>("Decorations/ChocFinger");
        decorations[1] = Resources.Load<GameObject>("Decorations/Freckle");
        decorations[2] = Resources.Load<GameObject>("Decorations/LicoriceAllSort");
        decorations[3] = Resources.Load<GameObject>("Decorations/Snake");
        decorations[4] = Resources.Load<GameObject>("Decorations/SpearmintLeaf");
        decorations[5] = Resources.Load<GameObject>("Decorations/Teeth");
    }
    

    private void SetDecorationsInChildBowls(GameObject[] decorations){
        int i =0;
        foreach (GameObject bowl in GetChildBowlsList())
        {
            bowl.GetComponent<DecorationBowl>().setBowlDecoration(decorations[i]);
            i++;
        }
    }

    public void addDecoration(GameObject decoration){
        for (int i = 0; i < decorations.Length; i++)
        {
            if (decorations[i] == null)
            {
                decorations[i] = decoration;
                return;
            }
        }
    }
    
    public void addDecorations(GameObject[] decorations){
        for (int i = 0; i < decorations.Length; i++)
        {
            addDecoration(decorations[i]);
        }
    }
    
    public void EmptyBowls(){
        foreach (Transform child in transform)
        {
            child.GetComponent<DecorationBowl>().EmptyBowl();


        }
    }
    
    private GameObject[] GetChildBowlsList(){
        GameObject[] childBowls = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            childBowls[i] = transform.GetChild(i).gameObject;
        }
        return childBowls;
    }

    private void loadDecorationsByNames(string[] decorationNames)
    {
        for (int i = 0; i < decorationNames.Length; i++)
        {
            decorations[i] = Resources.Load<GameObject>(decorationNames[i]);
        }
    }
    
    


}
