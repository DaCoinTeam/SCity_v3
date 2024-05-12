using Unity.Netcode;
using UnityEngine;

public class ServerNetworkController : SingletonPersistent<ServerNetworkController>
{
    private void Start()
    {
        NetworkManager.Singleton.StartServer();
        NetworkManager.Singleton.OnClientConnectedCallback += (id) =>
        {
            Debug.Log($"Client with ID {id} connected.");
        };
    }
}