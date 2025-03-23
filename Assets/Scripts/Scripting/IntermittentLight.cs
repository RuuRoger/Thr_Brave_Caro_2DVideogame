using UnityEngine;

[RequireComponent (typeof(Renderer))]

public class IntermittentLight : MonoBehaviour
{
#region Fields

    [Header("Color")]
    [ColorUsage(true)]
    [SerializeField] Color _originalColor;
    private Color _transparentColor;
    [Header("Timing")]
    [SerializeField] float _blinkInterval;
    [Header("Components")]
    [SerializeField] Renderer _objectRender;

    //Back Values
    private bool _isBlinking;

#endregion

#region Methods
    private void Blinking()
    {
        if (_isBlinking)
            _objectRender.material.color = _originalColor;
        else
            _objectRender.material.color = _transparentColor;

        _isBlinking = !_isBlinking;
    }

#endregion
   
#region Unity Callbacks
    private void Start()
    {
        _isBlinking = false;
        _transparentColor =new Color (1,1,1,0);
        InvokeRepeating("Blinking", _blinkInterval, _blinkInterval);
    }
#endregion
}
