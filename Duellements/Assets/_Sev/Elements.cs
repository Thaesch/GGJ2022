using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;


public enum Relation { Disadvantage = -1, None = 0, Advantage = 1 }
public enum Element { NORMAL = 0, WATER, FIRE, GROUND, WIND }

public class Elements
{

    public List<Element> GetMagicElements()
    {
        List<Element> elements = System.Enum.GetValues(typeof(Element)).Cast<Element>().ToList();
        elements.RemoveAt(0);
        return elements;
    }

    public List<Element> GetMagicElementsInRandomOrder()
    {
        List<Element> elements = GetMagicElements();
        return elements.OrderBy(a => Random.value).ToList();
    }

    public static Element fromNumber(int i)
    {
        List<Element> elements = new List<Element>() { Element.NORMAL, Element.WATER, Element.FIRE, Element.GROUND, Element.WIND };
        i = Mathf.Min( Mathf.Max(i, 0), elements.Count) ;
        return elements[i];
    }

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
            case Element.WIND: return Color.white;
            case Element.GROUND: return new Color(156,100,18);
            default: return Color.gray;
        }
    }
}
