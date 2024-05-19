using Cinemachine;
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
    private UIVirtualJoystick uiVirtualJoystick;

    void Start()
    {
        cinemachineVirtualCamera = GameObject.Find("Virtual Main Camera").GetComponent<CinemachineVirtualCamera>();
        uiVirtualJoystick = FindObjectOfType<UIVirtualJoystick>();

        _resetButton.onClick.AddListener(() =>
        {
            cinemachineVirtualCamera.m_Lens.FieldOfView = Constants.DefaultValues.Scrollbar;
            uiVirtualJoystick.magnitudeMultiplier = Constants.DefaultValues.Scrollbar;
            //volumeValue = Constants.DefaultValues.Scrollbar;
        });

        _applyButton.onClick.AddListener(UpdateSettings);
        _closeButton.onClick.AddListener(BootstrapModalController.Instance.CloseNearestModal);

        UpdateSettings();
    }

    private void UpdateSettings()
    {
        cinemachineVirtualCamera.m_Lens.FieldOfView = _fovScrollbar.value * 150f;
        uiVirtualJoystick.magnitudeMultiplier = _cameraSensitivityScrollbar.value * 30f;
    }
}
