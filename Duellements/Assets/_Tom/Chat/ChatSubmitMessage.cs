using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TMPro.TMP_InputField))]
public class ChatSubmitMessage : MonoBehaviour
{

    [SerializeField] private bool trimWhiteSpace = true;
    [SerializeField] private UnityEvent<string> submitMessage;

    private TMPro.TMP_InputField inputField;

    private void Awake()
    {
        inputField = GetComponent<TMPro.TMP_InputField>();
    }

    private void Start()
    {
        inputField.onSubmit.AddListener(text =>
        {
            HandleChatMessage(text);
        });
    }


    private void HandleChatMessage(string text)
    {
        if (trimWhiteSpace)
            SubmitChatMessage(text.Trim('\n', '\r', ' '));
        else
            SubmitChatMessage(text);

        inputField.text = "";
        inputField.ActivateInputField();
    }

    private void SubmitChatMessage(string text)
    {
        if (AcceptMessage(text))
        {
            submitMessage?.Invoke(text);
        }
    }

    private bool AcceptMessage(string text)
    {
        return !string.IsNullOrEmpty(text);
    }


    public void SubmitChatMessageViaButton()
    {
        HandleChatMessage(inputField.text);
    }
}
