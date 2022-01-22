using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum Element { NORMAL, WATER, FIRE, GROUND, WIND }

public class Elements
{

    //public static RelationOf(Element A, Element B)
    //{
    //    if(A.WATER)
    //}


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
