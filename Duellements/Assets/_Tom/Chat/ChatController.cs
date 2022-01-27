using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatController : MonoBehaviour
{

    [SerializeField] private TMPro.TMP_Text chatDisplay;
    [SerializeField] private Scrollbar chatScrollbar;

    public void DisplayChatMessage(string text, string senderName)
    {
        chatDisplay.text += $"{senderName}: {text}\n ";
        chatScrollbar.value = 0;
    }

}
