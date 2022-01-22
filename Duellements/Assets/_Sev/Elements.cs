using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum Relation { Advantage = -1, None = 0, Disadvantage = 1 }
public enum Element { NORMAL, WATER, FIRE, GROUND, WIND }

public class Elements
{

    public static Relation RelationOf(Element A, Element B)
    {
        switch (A)
        {
            case Element.FIRE:
                switch (B) {
                    case Element.WATER: return Relation.Disadvantage;
                    case Element.WIND: return Relation.Advantage;
                    default: return Relation.None;
                }
            case Element.WATER:
                switch (B)
                {
                    case Element.GROUND: return Relation.Disadvantage;
                    case Element.FIRE: return Relation.Advantage;
                    default: return Relation.None;
                }
            case Element.GROUND:
                switch (B)
                {
                    case Element.WIND: return Relation.Disadvantage;
                    case Element.WATER: return Relation.Advantage;
                    default: return Relation.None;
                }
            case Element.WIND:
                switch (B)
                {
                    case Element.GROUND: return Relation.Disadvantage;
                    case Element.FIRE: return Relation.Advantage;
                    default: return Relation.None;
                }
            default: return Relation.None;
        }
    }


    public static Color GetColorOf(Element element)
    {
        switch (element)
        {
            case Element.FIRE: return Color.red;
            case Element.WATER: return Color.blue;
            case Element.WIND: return Color.yellow;
            case Element.GROUND: return Color.black;
            default: return Color.gray;
        }
    }
}
