using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterAnimatorMiddleman : MonoBehaviour
{

    public Animator animator;

    // Start is called before the first frame update
    public void Shoot()
    {
        if (PhotonNetwork.IsConnected)
        {

        }
        else
        {
            animator.SetBool("shoot", true);
        }
    }

    private void Update()
    {
        if (PhotonNetwork.IsConnected)
        {

        }else
        {
            float speed = GetComponent<PlayerController>().CurrentSpeed;
            Debug.Log(speed);
            animator.SetFloat("Speed", speed);
        }

    }
}
