using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CakeCardType
{
    GeorgeGirraffe,
    SammySnail,
    No3,
    LittlePiggy,
    AussieRules,
    Butterfly,
    Bear,
    Cricket,
    Koala,
    Echidna,
    CursedEchidna,
    Football,
    FriendlyGhost,
    GingerNeville,
    GingerbreadMan,
    TheGoodWitch,
    Moon,
    Lion,
    LucyLadybird,
    PussInBoots,
    Pussycat,
    RacingTrack,
    RubberDuck,
    SoccerBall,
    Tennis,
    TimothyTiger,
    TommyTurtle,
    WackyWabbit,
    WiseOldOwl,
    Fingers,
}

[CreateAssetMenu(fileName = "CakeRequest", menuName = "ScriptableObjects/CakeRequest", order = 1)]
public class CakeRequest : ScriptableObject
{
    public string RequestText;
    public CakeCardType type;
}
