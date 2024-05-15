using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputMnemonicsModalController : Singleton<InputMnemonicsModalController>
{
    [SerializeField]
    private TMP_InputField _inputField;

    [SerializeField]
    private Button _closeButton;

    [SerializeField]
    private Button _importButton;

    [SerializeField]
    private BlockchainDataScriptableObject _blockchainDataScriptableObject;

    void Start()
    {
        _closeButton.onClick.AddListener(BootstrapModalController.Instance.CloseNearestModal);
        _importButton.onClick.AddListener(OnImportButtonClick);
    }

    private void OnImportButtonClick()
    {
        SuiWallet.RestoreWalletFromMnemonics(_inputField.text);
        var address = SuiWallet.GetActiveAddress();
        _blockchainDataScriptableObject.Address = address;

        BootstrapLoadingSceneManagerController.Instance.LoadScene(SceneName.Game);
    }
}
