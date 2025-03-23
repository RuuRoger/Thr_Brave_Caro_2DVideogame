using System;
using UnityEngine;

public class AuxColliderColumTrick : MonoBehaviour
{
    #region Fields

    [Header("Objects")]
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _groundPlayer;

    //Back Values
    private SpriteRenderer _Spriterenderer;
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _collider;

    #endregion

    #region Events

    public static event Action<GameObject, GameObject, SpriteRenderer, Rigidbody2D, BoxCollider2D> PlayerCollisionRespawn;
    public static event Action OnAuxCollTrickRestartPillsLvl4; //Notify Diseable pills to catch them all again

    #endregion

    #region Unity Callbacks

    private void Start()
    {
        _Spriterenderer = _player.GetComponent<SpriteRenderer>();
        _rigidbody = _player.GetComponent<Rigidbody2D>();
        _collider = _player.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerCollisionRespawn?.Invoke(_groundPlayer, _player, _Spriterenderer, _rigidbody, _collider);
            OnAuxCollTrickRestartPillsLvl4?.Invoke();
        }
    }

    #endregion
}
