using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerRpcController : NetworkBehaviour
{   
    [SerializeField]
    private KeyCode _sendMessageKeyCode = KeyCode.Escape;
    private void Update()
    {
        if (IsOwner)
        {
            ExecuteSendMessageRpc();
        }
    }

    [Rpc(SendTo.Server)]
    private void ExecuteSendMessageRpc()
    {
        SendMessageRpc();
    }

    [Rpc(SendTo.NotServer)]
    private void SendMessageRpc()
    {
        Debug.Log(OwnerClientId.ToString());
    }
}