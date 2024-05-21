using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;

public enum SupportedBlockchains
{
    BinanceSmartChain,
    Sui
}

public class BootstrapBrowserController : SingletonPersistent<BootstrapBrowserController>
{
    [SerializeField]
    private SupportedBlockchains _supportedBlockchains = SupportedBlockchains.Sui;

    [SerializeField]
    private BlockchainDataScriptableObject _blockchainDataScriptableObject;

    public void SetAddress(string address)
    {   
        _blockchainDataScriptableObject.Address = address;
    }
}
