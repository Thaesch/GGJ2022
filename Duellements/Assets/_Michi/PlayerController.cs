using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviourPunCallbacks
{
    public float speed = 10;
    public Healthbar healthbar;

    // Start is called before the first frame update
    void Awake()
    {
        if(PhotonNetwork.IsConnected && !photonView.IsMine)
        {
            Destroy(this);
        }
        healthbar.setMaxHealth(100);
    }

    // Update is called once per frame
    void Update()
    {
        float hinput = Input.GetAxis("Horizontal");
        float vinput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(hinput, 0, vinput) * speed * Time.deltaTime, Space.World);
        Vector3 mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, LayerMask.GetMask("Ground")))
        {
            //Rotation anpassen.
            Vector3 whereToLook = hit.point - transform.position;
            whereToLook.y = transform.position.y;

            transform.rotation = Quaternion.LookRotation(whereToLook, Vector3.up);
        }
            
    }
}
