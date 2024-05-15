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
        _createNewWalletButton.onClick.AddListener(() =>
        {
            var mnemonics = SuiWallet.CreateNewWallet();
            PlayerPrefs.SetString(Constants.PlayersPref.SUI_MNEMONICS, mnemonics);

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
