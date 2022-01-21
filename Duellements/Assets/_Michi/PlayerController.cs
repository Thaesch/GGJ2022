using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("TEST");
    }

    // Update is called once per frame
    void Update()
    {
        float hinput = Input.GetAxis("Horizontal");
        float vinput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(hinput, 0, vinput) * speed * Time.deltaTime);
        
    }
}
