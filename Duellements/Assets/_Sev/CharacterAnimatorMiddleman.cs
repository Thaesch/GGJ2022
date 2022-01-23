using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
public class CharacterAnimatorMiddleman : MonoBehaviour
{

    public Animator animator;

    // Start is called before the first frame update
    public void Shoot()
    {
        if (PhotonNetwork.IsConnected)
        {
            if (GetComponent<PhotonView>().IsMine)
            {
                float speed = GetComponent<PlayerController>().CurrentSpeed;
                animator.SetFloat("Speed", speed);
            }
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
            if (GetComponent<PhotonView>().IsMine)
            {
                float speed = GetComponent<PlayerController>().CurrentSpeed;
                animator.SetFloat("Speed", speed);
            }

        }else
        {
            float speed = GetComponent<PlayerController>().CurrentSpeed;
            animator.SetFloat("Speed", speed);
        }

    }
}
