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

    [SerializeField]
    private Transform _empty;

    void Start()
    {
        _sendButton.onClick.AddListener(OnSendButtonClick);
        _closeButton.onClick.AddListener(BootstrapModalController.Instance.CloseNearestModal);
    }

    public void CreateChatItem(string username, string message)
    {
        _empty.gameObject.SetActive(false);
        if (_chatContainer.childCount == 5)
        {
            Destroy(_chatContainer.GetChild(0).gameObject);
        }

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
