using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangePlayerName : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textZeug;
    private string playerName = "Thomas";
    // Start is called before the first frame update
    void Start()
    {
        textZeug.text = playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
