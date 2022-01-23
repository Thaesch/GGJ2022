using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostReleaseFX : MonoBehaviour
{

    [SerializeField]
    private Vector3 direction = new Vector3(0, 1, 0);

    [SerializeField]
    private float speed = 1;

    private const float destroy_y = 100;

    public void Update()
    {
        transform.position += direction * Time.deltaTime * speed;
        if(transform.position.y > destroy_y)
        {
            Remove();
        }
    }

    private void Remove()
    {
        Destroy(this);
    }

}
