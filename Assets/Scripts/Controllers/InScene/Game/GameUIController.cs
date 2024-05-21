using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameUIController : Singleton<GameUIController>
{
    [SerializeField]
    private TMP_Text _usernameText;

    [SerializeField]
    private Button _chatButton;

    [SerializeField]
    private Transform _chatModal;

    [SerializeField]
    private Button _settingsButton;

    [SerializeField]
    private Transform _settingsModal;

    [SerializeField]
    private BlockchainDataScriptableObject _blockchainDataScriptableObject;

    private void Start()
    {
        _chatButton.onClick.AddListener(() => BootstrapModalController.Instance.CreateModal(_chatModal));
        _settingsButton.onClick.AddListener(() => BootstrapModalController.Instance.CreateModal(_settingsModal));
        
        _usernameText.text = AddressUtility.ShortenAddress(_blockchainDataScriptableObject.Address);
    }
}
