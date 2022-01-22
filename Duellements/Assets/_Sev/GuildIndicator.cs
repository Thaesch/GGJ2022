using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Renderer))]
public class GuildIndicator : MonoBehaviour
{

    public Guardian player;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Elements.GetColorOf(player.element);
    }
}
