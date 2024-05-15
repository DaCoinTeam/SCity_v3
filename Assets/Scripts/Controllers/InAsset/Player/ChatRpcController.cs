using Unity.Netcode;

public class ChatRpcController : NetworkBehaviour
{
    [Rpc(SendTo.Server)]
    public void SendMessageRpc(string username, string message)
    {
         ReceiveMessageRpc(username, message);
    }

    [Rpc(SendTo.NotServer)]
    private void ReceiveMessageRpc(string username, string message)
    {
        if (ChatModalController.Instance != null)
        {
            ChatModalController.Instance.CreateChatItem(username, message);
        }
    }
}