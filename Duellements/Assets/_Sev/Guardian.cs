using System;
using System.Collections;
using System.Collections.Generic;
using _Marco.Scripts;
using UnityEngine;


[RequireComponent(typeof (PlayerController))]
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

        Debug.Log($"projectiles: {projectiles.Count} elements: {(int)element-1}");
        if (projectiles.Count > (int)element-1 && (int)element >= 0)
        {
            weapon.projectile = projectiles[(int)element-1];
            Debug.Log("Set Projectile: " + projectiles[(int)element-1].name);
        }
    }
}
