using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using UnityEngine.Rendering;

public class UIMenuContrller : MonoBehaviour
{
    #region Fields

    [SerializeField] private Button _startButtonObjcet;
    [SerializeField] private Button _exitButtonObject;
    [SerializeField] private Button _cancelButtonObject;
    [SerializeField] private GameObject _seettingsPanel;
    [SerializeField] private TMP_Dropdown _qualityDrop;
    [SerializeField] private Toggle _vSyncToggle;
    [SerializeField] private Toggle _fullScreenToggle;
    [SerializeField] private Toggle _noShadowToggle;
    [SerializeField] private Toggle _softShadowToggle;
    [SerializeField] private Toggle _hardShadowToggle;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioSource _audioSource;

    #endregion

    #region Method
    private void ClickOptionsButton()
    {
        //Diseable buttons in menu
        _startButtonObjcet.gameObject.SetActive(false);
        _exitButtonObject.gameObject.SetActive(false);
        
        //Active settings panel
        _seettingsPanel.gameObject.SetActive(true);

        //Active quality drop
        QualitySettingsDrop();

        //Diseable button options
        gameObject.SetActive(false);
    }

    private void ExitGame() => Application.Quit();

    private void CloseSettingPanel()
    {
        //Eable buttons in menu
        _startButtonObjcet.gameObject.SetActive(true);
        _exitButtonObject.gameObject.SetActive(true);
        gameObject.SetActive(true);

        //Diseable settings panel
        _seettingsPanel.gameObject.SetActive(false);
    }

    private void QualitySettingsDrop()
    {
        //Take vaues for quality settings
        _qualityDrop.ClearOptions();
        List<string> options = new List<string>(UnityEngine.QualitySettings.names);
        _qualityDrop.AddOptions(options);

        //Actual quality
        _qualityDrop.value = UnityEngine.QualitySettings.GetQualityLevel();
        _qualityDrop.RefreshShownValue();
    }

    private void SetQuality(int arg0)
    {
        //Let set the drop value
        UnityEngine.QualitySettings.SetQualityLevel(arg0, true);
    }

    private void SetVSync(bool on)
    {
        if (on)
            QualitySettings.vSyncCount = 1;
        else
            QualitySettings.vSyncCount = 0;
    }

    private void SetFullScreen(bool on) => Screen.fullScreen = !Screen.fullScreen;

    private void SetVolume(float value) => _audioSource.volume = value;

    private void SetNoShadows(bool on)
    {
        if (on)
            QualitySettings.shadows = ShadowQuality.Disable;
    }

    private void SetSoftShadows(bool on)
    {
        if (on)
           QualitySettings.shadows  = ShadowQuality.All;        
    }

    private void SetHardShadows(bool on)
    {
        if (on)
            QualitySettings.shadows = ShadowQuality.HardOnly;
    }

    #endregion

    #region Unity Callbacks
    private void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(ClickOptionsButton);
        _exitButtonObject.GetComponent<Button>().onClick.AddListener(ExitGame);
        _qualityDrop.onValueChanged.AddListener(SetQuality);
        _cancelButtonObject.onClick.AddListener(CloseSettingPanel);
        _vSyncToggle.onValueChanged.AddListener(SetVSync);
        _fullScreenToggle.onValueChanged.AddListener(SetFullScreen);
        _noShadowToggle.onValueChanged.AddListener(SetNoShadows);
        _softShadowToggle.onValueChanged.AddListener(SetSoftShadows);
        _hardShadowToggle.onValueChanged.AddListener(SetHardShadows);

        volumeSlider.value = _audioSource.volume;
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    #endregion

}
