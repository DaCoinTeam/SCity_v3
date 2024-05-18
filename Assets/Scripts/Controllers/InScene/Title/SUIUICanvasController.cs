using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SUIUICanvasController : Singleton<SUIUICanvasController>
{
    [SerializeField]
    private Button _createNewWalletButton;

    [SerializeField]
    private Button _importAWalletButton;

    [SerializeField]
    private BlockchainDataScriptableObject _blockchainDataScriptableObject;

    [SerializeField]
    private Transform _inputMnemonicsModal;

    private void Start()
    {
        var mnemonics = PlayerPrefs.GetString(Constants.PlayerPrefs.SuiMnemonics);
        if (mnemonics != null)
        {
            SuiWallet.RestoreWalletFromMnemonics(mnemonics);
            var address = SuiWallet.GetActiveAddress();
            _blockchainDataScriptableObject.Address = address;

            BootstrapLoadingSceneManagerController.Instance.LoadScene(SceneName.Game);
        }

        _createNewWalletButton.onClick.AddListener(() =>
        {
            var mnemonics = SuiWallet.CreateNewWallet();
            PlayerPrefs.SetString(Constants.PlayerPrefs.SuiMnemonics, mnemonics);


            var address = SuiWallet.GetActiveAddress();
            _blockchainDataScriptableObject.Address = address;

            BootstrapLoadingSceneManagerController.Instance.LoadScene(SceneName.Game);
        });

        _importAWalletButton.onClick.AddListener(() =>
        {
            BootstrapModalController.Instance.CreateModal(_inputMnemonicsModal);
        });
    }
}
