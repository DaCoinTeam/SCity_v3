//using System.Collections;
//using UnityEngine;
//using System.Runtime.InteropServices;
//using UnityEngine.UI;

//public class TitleMetamaskUICanvasController : Singleton<TitleMetamaskUICanvasController>
//{
//    [SerializeField]
//    private Button _connectWalletButton;

//    [SerializeField]
//    private BlockchainDataScriptableObject _blockchainDataScriptableObject;
//    // gọi hàm helloworld ở browser
//    [DllImport("__Internal")]
//    private static extern void HelloWorld();

//    public void CallHelloWorld()
//    {
//#if UNITY_WEBGL && !UNITY_EDITOR
//    HelloWorld();
//#endif
//    }

//    private IEnumerator Start()
//    {
//        yield return new WaitUntil(() => BootstrapMetamaskSdkController.HasInitialized);
//        _connectWalletButton.onClick.AddListener(() =>
//        {
//            CallHelloWorld();
//            //MetaMaskUnity.Instance.Connect();
//        }
//        );
//    }
//}