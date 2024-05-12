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

    private void Start()
    {
        _createNewWalletButton.onClick.AddListener(() =>
        {
            var mnemonics = SuiWallet.CreateNewWallet();
            PlayerPrefs.SetString(Constants.PlayersPref.SUI_MNEMONICS, mnemonics);

            BootstrapLoadingSceneManagerController.Instance.LoadScene(SceneName.Game);
        });
    }
}
