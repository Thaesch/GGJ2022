using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class LifeIllustration : MonoBehaviour, IPunObservable
{

    [SerializeField]
    private FountainOfLife fountainOfLife;

    public Slider slider;

    private void Start()
    {
        fountainOfLife.OnGhostReleased += DecreaseLife;
        slider.maxValue = fountainOfLife.LifeLeft;
    }
        
    // sets max health and also sets current health to max health
    public void setMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // sets health
    public void DecreaseLife()
    {
        slider.value -= 1;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(slider.value);
        }
        else
        {
            slider.value = (float)stream.ReceiveNext();
        }
    }

}
