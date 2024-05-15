using TMPro;
using Unity.Netcode;
using UnityEngine;

public class ChatItemController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _usernameText;

    [SerializeField]
    private TMP_Text _messsageText;

    public void Initialize(string username, string message)
    {
        _usernameText.text = username;
        _messsageText.text = message;
    }
}