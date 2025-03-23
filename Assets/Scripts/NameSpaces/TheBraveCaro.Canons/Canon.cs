using UnityEngine;

namespace TheBraveCaro.Canons
{
    public class Canon : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefabCanon;
        [SerializeField] private GameObject _canon;
        [SerializeField] private Transform _bulletPoint;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private float _velocityBullet;
        [SerializeField] private float _shotInterval;
        [Range(0f, 360f)][SerializeField] private float _angleAdjustment;
        [SerializeField] private float _timeToStartToShot;
        [SerializeField] private float _timeToDestroyBullet;

        private Vector2 _direction;

        private void Start()
        {
            InvokeRepeating("Shot", _timeToStartToShot, _shotInterval);

        }

        private void Update()
        {
            LookAt();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(_bulletPoint.position, _playerTransform.position);

        }

        private void LookAt()
        {
            _direction = _playerTransform.position - _bulletPoint.transform.position;
            float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            _canon.transform.rotation = Quaternion.Euler(0, 0, angle - _angleAdjustment);
        }

        private void Shot()
        {
            GameObject _prefabObject = Instantiate(_bulletPrefabCanon, _bulletPoint.position, Quaternion.identity);
            Rigidbody2D _rbBulletPrefab = _prefabObject.GetComponent<Rigidbody2D>();
            _rbBulletPrefab.linearVelocity = _direction.normalized * _velocityBullet;
            Destroy(_prefabObject, _timeToDestroyBullet);
        }
    }

}
