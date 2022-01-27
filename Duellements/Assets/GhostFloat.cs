using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFloat : MonoBehaviour
{
    [SerializeField] private float effctStrength = 0.5f;

    // Update is called once per frame
    void Update()
    {
        float currentOffsetX = Mathf.Sin(Time.realtimeSinceStartup) * effctStrength;
        float currentOffsetY = Mathf.Cos(Time.realtimeSinceStartup) * effctStrength;

        transform.Translate(new Vector3(currentOffsetX , currentOffsetY, currentOffsetX));
    }
}
