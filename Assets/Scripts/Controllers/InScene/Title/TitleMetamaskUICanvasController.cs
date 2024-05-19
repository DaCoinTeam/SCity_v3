using MetaMask.Unity;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TitleMetamaskUICanvasController: Singleton<TitleMetamaskUICanvasController>
{
    [SerializeField]
    private Button _connectWalletButton;

    [SerializeField]
    private BlockchainDataScriptableObject _blockchainDataScriptableObject;

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => BootstrapMetamaskSdkController.HasInitialized);
        _connectWalletButton.onClick.AddListener(() =>
        {
            MetaMaskUnity.Instance.Connect();
        }
        );
    }
}