using System;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class ChatItemController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _usernameText;

    [SerializeField]
    private TMP_Text _messsageText;

    [SerializeField]
    private TMP_Text _timeText;

    public void Initialize(string username, string message)
    {
        _usernameText.text = username;
        _messsageText.text = message;
        _timeText.text = DateTime.Now.ToString("hh:mm");
    }
}