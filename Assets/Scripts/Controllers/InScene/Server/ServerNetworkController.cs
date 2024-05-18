using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

public class ServerNetworkController : SingletonPersistent<ServerNetworkController>
{
    [SerializeField]
    private bool _isProduction;

    private void Start()
    {
        var unityTransport = FindObjectOfType<UnityTransport>();

        if (_isProduction)
        {
            var certTxt = (TextAsset) Resources.Load(Constants.Resources.Secrets.CertPath);
            var privateKeyTxt = (TextAsset) Resources.Load(Constants.Resources.Secrets.PrivateKeyPath);

            unityTransport.ConnectionData = new ()
            {
                Address = Constants.Environment.Production.IpV4,
                Port = Constants.Environment.Production.Port
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