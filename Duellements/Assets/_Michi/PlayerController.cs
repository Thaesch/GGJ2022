using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviourPunCallbacks
{
    public float speed = 10;
    public HealthBar healthbar;

    private float _currentSpeed = 0;
    private Rigidbody rigidbody;

    public float CurrentSpeed
    {
        get
        {
            return _currentSpeed;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (PhotonNetwork.IsConnected)
        {
            if (!photonView.IsMine)
            {
                this.enabled = false;
            }
            else
            {
                rigidbody = GetComponent<Rigidbody>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float hinput = Input.GetAxis("Horizontal");
        float vinput = Input.GetAxis("Vertical");

        _currentSpeed = Mathf.Sqrt(hinput * hinput + vinput * vinput); 

        rigidbody.velocity = new Vector3(hinput, 0, vinput) * speed;
        Vector3 mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, LayerMask.GetMask("Ground")))
        {
            //Rotation anpassen.
            Vector3 whereToLook = hit.point - rigidbody.position;
            whereToLook.y = rigidbody.position.y;

            rigidbody.rotation = Quaternion.LookRotation(whereToLook, Vector3.up);
        }
    }
}
