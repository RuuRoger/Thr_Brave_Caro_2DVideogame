using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UISettingsMenu : MonoBehaviour
{
    //Fields
    [SerializeField] private Button _closeButton;
    [SerializeField] private TMP_Dropdown _qualityDrop;
    [SerializeField] private Toggle _vyncToggle;
    [SerializeField] private Toggle _fullScreenToggle;
    [SerializeField] private Toggle _noShadows;
    [SerializeField] private Toggle _softShadows;
    [SerializeField] private Toggle _shadowHardShadow;
    [SerializeField] private Slider _particleResolutionSlider;
}
