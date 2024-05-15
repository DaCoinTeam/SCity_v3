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
    private BlockchainDataScriptableObject _blockchainDataScriptableObject;

    private void Start()
    {
        Debug.Log(AddressUtility.ShortenAddress(_blockchainDataScriptableObject.Address));
        _chatButton.onClick.AddListener(() => BootstrapModalController.Instance.CreateModal(_chatModal));

        _usernameText.text = AddressUtility.ShortenAddress(_blockchainDataScriptableObject.Address);
    }
}
