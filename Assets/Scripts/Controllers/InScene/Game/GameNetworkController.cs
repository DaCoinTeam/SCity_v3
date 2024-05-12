using Unity.Netcode;
using UnityEngine;

public class GameNetworkController : SingletonPersistent<GameNetworkController>
{
    private void Start()
    {
        NetworkManager.Singleton.StartClient();
        NetworkManager.Singleton.OnClientConnectedCallback += (id) =>
        {
            Debug.Log($"Client with ID {id} connected.");
        };
    }
}