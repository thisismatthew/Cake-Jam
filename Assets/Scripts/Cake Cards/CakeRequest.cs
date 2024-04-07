using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CakeCardType
{
    AussieRulesField,
    BeautifulButterfly,
    BrownBear,
    CricketBat,
    CuddlyKoala,
    Echidna,
    Football,
    FriendlyGhost,
    GeorgeGiraffe,
    GingerNeville,
    GingerbreadMan,
    GoodWitch,
    HeyDiddleDiddle,
    LeonardTheLion,
    LittlePiggy,
    LucyLadybird,
    PussInBoots,
    Pussycat,
    RacingTrack,
    RubberDucky,
    SammySnail,
    SoccerBall,
    TennisRacquet,
    TimothyTiger,
    TommyTurtle,
    WackyWabbit,
    WiseOldOwl
}

[CreateAssetMenu(fileName = "CakeRequest", menuName = "ScriptableObjects/CakeRequest", order = 1)]
public class CakeRequest : ScriptableObject
{
    public string RequestText;
    public CakeCardType type;
}
