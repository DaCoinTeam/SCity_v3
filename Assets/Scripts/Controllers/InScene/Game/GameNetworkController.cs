using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

public class GameNetworkController : SingletonPersistent<GameNetworkController>
{
    [SerializeField]
    private bool _isProduction;
    private void Start()
    {
        if (_isProduction)
        {
            var unityTransport = FindObjectOfType<UnityTransport>();
            unityTransport.UseWebSockets = true;
            unityTransport.UseEncryption = true;

            unityTransport.ConnectionData = new()
            {
                Address = Constants.Environment.Production.IpV4,
                Port = Constants.Environment.Production.Port,
            };
            unityTransport.SetClientSecrets(Constants.Environment.Production.MappingUrl);
        }
       

        NetworkManager.Singleton.StartClient();
        NetworkManager.Singleton.OnClientConnectedCallback += (id) =>
        {
            Debug.Log($"Client with ID {id} connected.");
        };
    }
}