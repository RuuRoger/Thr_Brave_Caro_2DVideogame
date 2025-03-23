using UnityEngine;

namespace TheBraveCaro.ObjectsPlattform2D
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(PlatformEffector2D))]
    [RequireComponent(typeof(Rigidbody2D))]

    public class Elevator : ColumnTrick
    {
        #region Fields

        #region Components
        [Header("Components")]
        [SerializeField] private Rigidbody2D _rbElevator;
        #endregion


        #endregion

        #region Methods
        protected override void ControlState()
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
            else
            {
                _rbElevator.linearVelocity = Vector2.zero;
            }
        }
        #endregion

        #region Unity Callbacks
        private void FixedUpdate()
        {
            ControlState();
        }
        #endregion

    }
}