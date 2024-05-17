using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

public class ServerNetworkController : SingletonPersistent<ServerNetworkController>
{
    [SerializeField]
    private bool _isProduction = false;

    private void Start()
    {
        var unityTransport = FindObjectOfType<UnityTransport>();

        if (_isProduction)
        {
            var certTxt = (TextAsset)Resources.Load(Constants.Resources.Secrets.CERT);
            var privateKeyTxt = (TextAsset)Resources.Load(Constants.Resources.Secrets.PRIVATE_KEY);

            unityTransport.ConnectionData = new ()
            {
                Address = Constants.VPS.IPV4,
                Port = Constants.VPS.PORT
            };

            unityTransport.UseWebSockets = true;
            unityTransport.UseEncryption = true;

            unityTransport.SetServerSecrets(
                certTxt.text,
                privateKeyTxt.text
                );
        }

        NetworkManager.Singleton.StartServer();
        NetworkManager.Singleton.OnClientConnectedCallback += (id) =>
        {
            Debug.Log($"Client with ID {id} connected.");
        };
    }
}