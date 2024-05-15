using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class ChatModalController : Singleton<ChatModalController>
{
    [SerializeField]
    private TMP_InputField _chatInputField;

    [SerializeField]
    private Transform _chatContainer;

    [SerializeField]
    private Transform _chatItem;

    [SerializeField]
    private Button _sendButton;

    [SerializeField]
    private Button _closeButton;

    void Start()
    {
        _sendButton.onClick.AddListener(OnSendButtonClick);
    }

    public void CreateChatItem(string username, string message)
    {
        var chatItem = Instantiate(_chatItem, _chatContainer);
        chatItem.GetComponent<ChatItemController>().Initialize(
            username,
            message
            );
    }

    private void OnSendButtonClick()
    {
        NetworkManager.Singleton.LocalClient.PlayerObject.
            GetComponent<ChatRpcController>().
            SendMessageRpc(
            NetworkManager.Singleton.LocalClientId.ToString(),
            _chatInputField.text
            );
    }
}
