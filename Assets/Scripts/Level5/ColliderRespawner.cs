using System;
using UnityEngine;

public class ColliderRespawner : MonoBehaviour
{
#region Fields

    [Header("Objects")]
    [SerializeField] private GameObject _groundPlayer;
    [SerializeField] private GameObject _player;

    //Back Values
    private SpriteRenderer _spriterendererPlayer;
    private Rigidbody2D _rbPlayer;
    private BoxCollider2D _colliderPlayer;
    
#endregion

#region Events

    //Send paramethers to respawn the _player when enter in trigger with the collider
    public static event Action<GameObject, GameObject, SpriteRenderer, Rigidbody2D, BoxCollider2D> OnColliderRespawnerRespawnPlayer;

#endregion

#region Method

    private void BulletTouchedPlayer() => OnColliderRespawnerRespawnPlayer?.Invoke(_groundPlayer, _player, _spriterendererPlayer, _rbPlayer, _colliderPlayer);

#endregion

#region Unity Callbacks
    private void OnEnable()
    {
        GameManager.OnGameManagerActiveEventInColliderRespawner += BulletTouchedPlayer;
    }

    private void Start()
    {
        _spriterendererPlayer = _player.GetComponent<SpriteRenderer>();
        _rbPlayer = _player.GetComponent<Rigidbody2D>();
        _colliderPlayer = _player.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            OnColliderRespawnerRespawnPlayer?.Invoke(_groundPlayer, _player, _spriterendererPlayer, _rbPlayer, _colliderPlayer);
    }

    private void OnDestroy()
    {
        GameManager.OnGameManagerActiveEventInColliderRespawner -= BulletTouchedPlayer;
    }

    #endregion

}
