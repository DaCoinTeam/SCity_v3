using Cinemachine;
using StarterAssets;
using System.Collections;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class SettingsModalController : Singleton<SettingsModalController>
{
    [SerializeField]
    private Scrollbar _cameraSensitivityScrollbar;

    [SerializeField]
    private Scrollbar _fovScrollbar;

    [SerializeField]
    private Scrollbar _volumeScrollbar;

    [SerializeField]
    private Button _resetButton;

    [SerializeField]
    private Button _applyButton;

    [SerializeField]
    private Button _closeButton;

    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private ModifiedThirdPersonController modifiedThirdPersonController;

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => NetworkManager.Singleton.LocalClient.PlayerObject != null);
        cinemachineVirtualCamera = GameObject.Find("Virtual Main Camera").GetComponent<CinemachineVirtualCamera>();
        modifiedThirdPersonController = NetworkManager.Singleton.LocalClient.PlayerObject.GetComponent<ModifiedThirdPersonController>();

        _resetButton.onClick.AddListener(() =>
        {
            cinemachineVirtualCamera.m_Lens.FieldOfView = Constants.DefaultValues.Scrollbar;
            //volumeValue = Constants.DefaultValues.Scrollbar;
        });

        _applyButton.onClick.AddListener(UpdateSettings);
        _closeButton.onClick.AddListener(BootstrapModalController.Instance.CloseNearestModal);
    }

    private void UpdateSettings()
    {
        cinemachineVirtualCamera.m_Lens.FieldOfView = _fovScrollbar.value * 150f;
        modifiedThirdPersonController.CameraSensitivity = _cameraSensitivityScrollbar.value * 10;
    }
}
