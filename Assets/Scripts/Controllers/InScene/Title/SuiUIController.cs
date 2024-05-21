using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class SuiUIController : Singleton<SuiUIController>
{
    [SerializeField]
    private Button _connectSuietButton;

    [SerializeField]
    private Button _signInWithGoogleButton;

    [SerializeField]
    private Button _signInWithFacebookButton;

    [SerializeField]
    private BlockchainDataScriptableObject _blockchainDataScriptableObject;

    [DllImport("__Internal")]
    private static extern void HandleConnectSuietButtonClick();

    private void OnConnectSuietButtonClick()
    {
#if (UNITY_WEBGL && !UNITY_EDITOR)
        HandleConnectSuietButtonClick();
#endif
    }

    [DllImport("__Internal")]
    private static extern void HandleSignInWithGoogleButtonClick();
    private void OnSignInWithGoogleButtonClick()
    {
#if (UNITY_WEBGL && !UNITY_EDITOR)
        HandleSignInWithGoogleButtonClick();
#else 
        //return string.Empty;
#endif
    }

    [DllImport("__Internal")]
    private static extern void HandleSignInWithFacebookButtonClick();
    private void OnSignInWithFacebookButtonClick()
    {
#if (UNITY_WEBGL && !UNITY_EDITOR)
        HandleSignInWithFacebookButtonClick();
#endif
    }

    private void Start()
    {
        _connectSuietButton.onClick.AddListener(OnConnectSuietButtonClick);
        _signInWithGoogleButton.onClick.AddListener(OnSignInWithGoogleButtonClick);
        _signInWithFacebookButton.onClick.AddListener(OnSignInWithFacebookButtonClick);
    }
}
