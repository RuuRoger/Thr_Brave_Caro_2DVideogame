using System;
using UnityEngine;

public class SpikesCollider : MonoBehaviour
{
    #region Fields

    [Header("Objects")]
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _groundForJump;

    #endregion

    #region Events

    public static event Action<GameObject, GameObject, SpriteRenderer, Rigidbody2D, BoxCollider2D> GotoRespawnPoint; //Send some variables to start _player respawn 
    public static event Action OnStopSpikeRcok1; //Notify to "SpikeRock" to stop and respawn it
    public static event Action OnStopSpikeRcok2; //Notify to "SpikeRock2" to stop and respawn it

    #endregion

    #region Unity Callbacks

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //First, get the components object
            SpriteRenderer _spriteRender = _player.GetComponent<SpriteRenderer>();
            Rigidbody2D _rb = _player.GetComponent<Rigidbody2D>();
            BoxCollider2D _collider = _player.GetComponent<BoxCollider2D>();

            GotoRespawnPoint?.Invoke(_groundForJump, _player, _spriteRender, _rb, _collider);
            OnStopSpikeRcok1?.Invoke();
            OnStopSpikeRcok2?.Invoke();

        }
    }

    #endregion
}
