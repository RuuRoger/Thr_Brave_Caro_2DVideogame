using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class UIMenuContrller : MonoBehaviour
{
    #region Fields

    [SerializeField] private Button _startButtonObjcet;
    [SerializeField] private Button _exitButtonObject;
    [SerializeField] private Button _cancelButtonObject;
    [SerializeField] private GameObject _seettingsPanel;
    [SerializeField] private TMP_Dropdown _qualityDrop;

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
        QualitySettings();

        //Diseable button options
        gameObject.SetActive(false);
    }

    private void CloseSettingPanel()
    {
        //Eable buttons in menu
        _startButtonObjcet.gameObject.SetActive(true);
        _exitButtonObject.gameObject.SetActive(true);
        gameObject.SetActive(true);

        //Diseable settings panel
        _seettingsPanel.gameObject.SetActive(false);
    }

    private void QualitySettings()
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

    #endregion

    #region Unity Callbacks
    private void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(ClickOptionsButton);
        _qualityDrop.onValueChanged.AddListener(SetQuality);
        _cancelButtonObject.onClick.AddListener(CloseSettingPanel);
    }

    #endregion

}
