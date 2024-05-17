using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

public class GameNetworkController : SingletonPersistent<GameNetworkController>
{
    private void Start()
    {
        var unityTransport = FindObjectOfType<UnityTransport>();
        unityTransport.SetClientSecrets("wssscity.longphu.dev");

        NetworkManager.Singleton.StartClient();
        NetworkManager.Singleton.OnClientConnectedCallback += (id) =>
        {
            Debug.Log($"Client with ID {id} connected.");
        };
    }
}