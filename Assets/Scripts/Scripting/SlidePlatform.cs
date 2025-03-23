using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(PlatformEffector2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class SlidePlatform : MonoBehaviour
{
    #region Fields

    #region Components
    [Header("Components")]
    [SerializeField] private Rigidbody2D _rbSlidePlatform;
    #endregion

    #region Distances
    [Header("Distances (Locals)")]
    [SerializeField] private float _leftDistance;
    [SerializeField] private float _rightDistance;
    
    #endregion

    #region Speed
    [Header("Speed")]
    [SerializeField] private float _speedSlidePlatform;
    #endregion

    #region Time
    [Header("Waiting Time")]
    [SerializeField] private float _timeToWaitSlidePlatform;
    #endregion

    #region Boolean States
    [Header("Bools")]
    private bool _goingRight = true;
    private bool _isWaiting = false;
    #endregion

    #endregion

    #region Unity Callbacks
    private void FixedUpdate()
    {
        if (!_isWaiting)
        {
            if (_goingRight)
            {
                GoRight();
            }
            else
            {
                GoLeft();
            }
        }
        else
        {
            _rbSlidePlatform.linearVelocity = Vector2.zero;
        }
    }

    #endregion

    #region Private Methods

    private void GoRight()
    {
        if (transform.localPosition.x < _rightDistance)
        {
            _rbSlidePlatform.linearVelocityX = _speedSlidePlatform;
        }
        else
        {
            _isWaiting = true;
            Invoke("ChangeDirection", _timeToWaitSlidePlatform);
        }
    }

    private void GoLeft()
    {
        if (transform.localPosition.x > _leftDistance)
        {
            _rbSlidePlatform.linearVelocityX = (-1) * _speedSlidePlatform;
        }
        else
        {
            _isWaiting = true;
            Invoke("ChangeDirection", _timeToWaitSlidePlatform);
        }
    }

    private void ChangeDirection()
    {
        _isWaiting = false;
        _goingRight = !_goingRight;
    }
    #endregion
}
