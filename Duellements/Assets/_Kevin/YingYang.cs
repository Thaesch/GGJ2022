using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YingYang : MonoBehaviour
{
    [SerializeField]
    private Timer timer;

    [SerializeField]
    private Animation animation;

    // Start is called before the first frame update
    void Start()
    {
        timer.OnTimeout += PlayAnimation;
    }

    private void PlayAnimation()
    {
        animation.Play();
    }

}
