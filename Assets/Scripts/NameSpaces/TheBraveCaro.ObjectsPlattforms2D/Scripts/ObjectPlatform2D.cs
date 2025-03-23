using UnityEngine;

namespace TheBraveCaro.ObjectsPlattform2D
{
    //This is an object that makes moves up and down.Used by columntricks and a elevator.
    //With a method "Wcontroller state", call to go up or go down

    public class ObjectPlatform2D : MonoBehaviour
    {
        #region Fields

        #region Highs
        [Header("Highs (Locals)")]
        [SerializeField] protected float _maxHigh;
        [SerializeField] protected float _minHigh;
        #endregion

        #region Speeed
        [Header("Speed")]
        [SerializeField] protected float _speedPlatform;
        #endregion

        #region Time
        [Header("Waiting Time")]
        [SerializeField] protected float _timeToChangeDirection;
        #endregion

        #region Boolean States
        [Header("Bools")]
        protected bool _isGoingUp = true;
        protected bool _isWaiting = false;
        #endregion

        #endregion

        #region Methods

        protected virtual void ControlState()
        {
            if (!_isWaiting)
            {
                if (_isGoingUp)
                {
                    GoUp();
                }
                else
                {
                    GoDown();
                }
            }
        }

        protected void GoUp()
        {
            if (transform.localPosition.y < _maxHigh)
            {
                transform.Translate(Vector3.up * _speedPlatform * Time.deltaTime);
            }
            else
            {
                _isWaiting = true;
                Invoke("ChangeDirection", _timeToChangeDirection);
            }
        }

        protected void GoDown()
        {
            if (transform.localPosition.y > _minHigh)
            {
                transform.Translate(Vector3.down * _speedPlatform * Time.deltaTime);
            }
            else
            {
                _isWaiting = true;
                Invoke("ChangeDirection", _timeToChangeDirection);
            }
        }

        protected void ChangeDirection()
        {
            _isWaiting = false;
            _isGoingUp = !_isGoingUp;
        }
        #endregion
    }
}