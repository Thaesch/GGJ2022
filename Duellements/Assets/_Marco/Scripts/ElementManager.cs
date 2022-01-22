using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Marco.Scripts
{
    public class ElementManager : MonoBehaviour
    {
        private static List<Element> Elements;

        private void Awake()
        {
            Elements = Enum.GetValues(typeof(Element)).Cast<Element>().ToList();
            Elements.RemoveAt(0);

            Elements = Elements.OrderBy(a => Random.value).ToList();
        }

        public static Element GetPlayerElement()
        {
            if (!Elements.Any())
            {
                Debug.LogError("Elements is empty. Are there more than four players?" );
                return Element.NORMAL;
            }
            Element elem = Elements.First();
            Elements.RemoveAt(0);
            return elem;
        }
    }
}