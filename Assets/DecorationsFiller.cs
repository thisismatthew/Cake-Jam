using System;
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
        // //setTestDecorations();
        // decorations[0] = Resources.Load<GameObject>("Decorations/ChocFinger");
        // decorations[1] = Resources.Load<GameObject>("Decorations/Freckle");
        // decorations[2] = Resources.Load<GameObject>("Decorations/LicoriceAllSort");
        // decorations[3] = Resources.Load<GameObject>("Decorations/Snake");
        // decorations[4] = Resources.Load<GameObject>("Decorations/SpearmintLeaf");
        // decorations[5] = Resources.Load<GameObject>("Decorations/Teeth");
    }

    // Update is called once per frame
    void Update()
    {
        
        //check if spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetDecorationsInChildBowls(decorations);
        }

        //if e is pressed empty all the bowls
        if (Input.GetKeyDown(KeyCode.E))
        {
            EmptyBowls();
        }
    }
    
    //TESTING
    // private void setTestDecorations(){
    //     decorations[0] = Resources.Load<GameObject>("Decorations/ChocFinger");
    //     decorations[1] = Resources.Load<GameObject>("Decorations/Freckle");
    //     decorations[2] = Resources.Load<GameObject>("Decorations/LicoriceAllSort");
    //     decorations[3] = Resources.Load<GameObject>("Decorations/Snake");
    //     decorations[4] = Resources.Load<GameObject>("Decorations/SpearmintLeaf");
    //     decorations[5] = Resources.Load<GameObject>("Decorations/Teeth");
    // }
    

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
    
    // ReSharper disable Unity.PerformanceAnalysis
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

    private void loadDecorationsByNames(string[] list)
    {
        string path = "Decorations/";        //decorations path
        decorations = new GameObject[list.Length];    //initialize decorations array
        for (int i = 0; i < list.Length; i++)
        {
            addDecoration(Resources.Load<GameObject>(path + list[i]));    //load decoration and add it to the decorations array
        }   
    }


    //TODO: Fill decorations based on the cake type
    private string[] RetrieveDecorations(CakeCardType type)
    {
        switch (type)
        {
            case CakeCardType.AussieRulesField:
            return new string[] { "ShreddedCoconut", "Clinkers", "Smarties", "Bullets", "Marshmallow", "MuskStick" };
        case CakeCardType.BeautifulButterfly:
            return new string[] { "Smarties", "Licorice", "Freckles", "Jellybeans", "Popcorn", "Teeth" };
        case CakeCardType.BrownBear:
            return new string[] { "ChocBiscuit", "ShreddedCoconut", "Smarties", "Jubes", "JellyBeans", "Licorice" };
        case CakeCardType.CricketBat:
            return new string[] { "ChocSprinkles", "Jaffa", "Licorice", "Smarties", "Popcorn", "Jellybeans" };
        case CakeCardType.CuddlyKoala:
            return new string[] { "ShreddedCoconut", "Licorice", "Lifesavers", "Smarties", "ChocBiscuit", "SpearmintLeaves" };
        case CakeCardType.Echidna:
            return new string[] { "ChocFingers", "Smarties", "Teeth", "Jaffas", "JellyBeans", "MuskSticks" };
        case CakeCardType.Football:
            return new string[] { "Licorice", "Lifesavers", "Bullets", "Smarties", "ChocSprinkles", "HundredsAndThousands" };
        case CakeCardType.FriendlyGhost:
            return new string[] { "Smarties", "Eggshell", "Licorice", "Jubes", "Teeth", "Snake" };
        case CakeCardType.GeorgeGiraffe:
            return new string[] { "ChocSprinkles", "Licorice", "Smarties", "Jaffas", "Teeth", "Chips" };
        case CakeCardType.GingerNeville:
            return new string[] { "Licorice", "Smarties", "Lifesavers", "Teeth", "HundredsAndThousands", "Snakes" };
        case CakeCardType.GingerbreadMan:
            return new string[] { "Smarties", "Licorice", "JellyBeans", "Marshmallow", "LifeSavers", "MuskSticks" };
        case CakeCardType.GoodWitch:
            return new string[] { "PotatoStraws", "Smarties", "Licorice", "Jubes", "Chips", "Teeth" };
        case CakeCardType.HeyDiddleDiddle:
            return new string[] { "Licorice", "Smarties", "Teeth", "Wafer", "Marshmallow", "HundredsAndThousands" };
        case CakeCardType.LeonardTheLion:
            return new string[] { "Jubes", "Licorice", "Smarties", "ChocSprinkles", "JellyBeans", "Chips" };
        case CakeCardType.LittlePiggy:
            return new string[] { "Jubes", "Licorice", "Smarties", "Freckles", "ShreddedCoconut", "Teeth" };
        case CakeCardType.LucyLadybird:
            return new string[] { "Smarties", "Licorice", "MuskStick", "Teeth", "Snakes", "HundredsAndThousands" };
        case CakeCardType.PussInBoots:
            return new string[] { "Smarties", "Licorice", "Jaffas", "Teeth", "Freckles", "ChocSprinkles" };
        case CakeCardType.Pussycat:
            return new string[] { "ShreddedCoconut", "JellyBeans", "Marshmallows", "Licorice", "Jubes", "Teeth" };
        case CakeCardType.RacingTrack:
            return new string[] { "Bullets", "Jubes", "Smarties", "Snakes", "Wafer", "Chips" };
        case CakeCardType.RubberDucky:
            return new string[] { "Popcorn", "Chips", "Smarties", "Jubes", "MuskStick", "Snakes" };
        case CakeCardType.SammySnail:
            return new string[] { "HundredsAndThousands", "ChocSprinkles", "Smarties", "Jubes", "MuskStick", "JellyBeans" };
        case CakeCardType.SoccerBall:
            return new string[] { "ShreddedCoconut", "Licorice", "LifeSavers", "Smarties", "ChocSprinkles", "PotatoStraws" };
        case CakeCardType.TennisRacquet:
            return new string[] { "Smarties", "Bullets", "MuskStick", "Licorice", "Jubes", "PotatoStraws" };
        case CakeCardType.TimothyTiger:
            return new string[] { "Licorice", "Jubes", "Smarties", "SpearmintLeaves", "Teeth", "Snakes" };
        case CakeCardType.TommyTurtle:
            return new string[] { "Smarties", "Licorice", "Cones", "Wafer", "JellyBeans", "Teeth" };
        case CakeCardType.WackyWabbit:
            return new string[] { "Marshmallow", "Licorice", "Smarties", "MuskStick", "Teeth", "ShreddedCoconut" };
        case CakeCardType.WiseOldOwl:
            return new string[] { "Licorice", "LifeSavers", "ShreddedCoconut", "Wafer", "Smarties", "JellyBeans" };
            default:
                throw new ArgumentException("Unknown CakeCardType");
        }

    }

    public void FillDecorations(CakeCardType type)
    {
        
        loadDecorationsByNames(RetrieveDecorations(type));
        SetDecorationsInChildBowls(decorations);
    }
}
