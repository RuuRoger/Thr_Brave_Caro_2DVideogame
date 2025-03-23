using TheBraveCaro.Canons;
using UnityEngine;

namespace TheBraveCaro.Canons
{
    public class PatrolCanon : MonoBehaviour
    {
        [SerializeField] private float _minRotation;
        [SerializeField] private float _maxRotation;
        [SerializeField] private float _speedMovement;
        [SerializeField] private float _waitTime;
        private float _direction;
        private bool _isWaiting;

        private void Patrol()
        {
            float currentRotation = transform.eulerAngles.z;
            if (currentRotation > 180) currentRotation -= 360; // Range in -180 to 180

            float newRotation = currentRotation + _direction * _speedMovement * Time.deltaTime;

            if (newRotation > _maxRotation || newRotation < _minRotation)
            {
                _direction *= -1;
                newRotation = Mathf.Clamp(newRotation, _minRotation, _maxRotation);
                _isWaiting = true;
                Invoke(nameof(ResumePatrol), _waitTime);
            }

            transform.rotation = Quaternion.Euler(0f, 0f, newRotation);
        }

        private void ResumePatrol()
        {
            _isWaiting = false;
        }
        private void Start()
        {
            _direction = 1f;
            _isWaiting = false;
        }

        private void Update()
        {
            if (!_isWaiting)
            {
                Patrol();
            }
        }

    }
}

