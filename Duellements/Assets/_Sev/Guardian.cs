using System;
using System.Collections;
using System.Collections.Generic;
using _Marco.Scripts;
using UnityEngine;


[RequireComponent(typeof (Shoot))]
public class Guardian : MonoBehaviour
{
    private Shoot weapon;
    
    public Element element = Element.NORMAL;
    public List<Projectile> projectiles = new List<Projectile>();

    // Start is called before the first frame update
    void Start()
    {
        element = ElementManager.GetPlayerElement();
        weapon = GetComponent<Shoot>();

        if (projectiles.Count > (int)element-1 && (int)element >= 0)
        {
            weapon.projectile = projectiles[(int)element-1];
        }
    }
}
