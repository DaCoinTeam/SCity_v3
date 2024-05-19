using MetaMask.Transports.Unity.UI;
using MetaMask.Unity;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootstrapMetamaskSdkController : SingletonPersistent<BootstrapMetamaskSdkController>
{
    [SerializeField]
    private BlockchainDataScriptableObject _blockchainDataScriptableObject;

    public static bool HasInitialized = false;
    public void Start()
    {
        MetaMaskSDK.Instance.MetaMaskUnityInitialized += OnMetaMaskUnityInitialized;
        MetaMaskSDK.Instance.Initialize();
    }

    private void OnMetaMaskUnityInitialized(object sender, System.EventArgs e)
    {
        MetaMaskSDK.Instance.Wallet.WalletAuthorized += OnWalletAuthorized;
        HasInitialized = true;
    }

    private void OnWalletAuthorized(object sender, System.EventArgs e)
    {
        StartCoroutine(OnWalletAuthorizedCoroutine());
    }

    private IEnumerator OnWalletAuthorizedCoroutine()
    {
        yield return new WaitUntil(() => !string.IsNullOrEmpty(MetaMaskSDK.Instance.Wallet.SelectedAddress));
        MetaMaskUnityUIHandler.Instance.CloseQRCode();
        _blockchainDataScriptableObject.Address = MetaMaskSDK.Instance.Wallet.SelectedAddress;
        BootstrapLoadingSceneManagerController.Instance.LoadScene(SceneName.Game);
    }
}
