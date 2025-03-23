using System.Collections;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    #region Fields

    [Header("Objects")]
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _respawnPosition;

    [Header("Timing to Blink")]
    [SerializeField] private float _blinkingTimingRespawn;

    //Back values
    private PlayerController _script;

    #endregion

    #region  Method Respawn Player

    private void Respawn(GameObject _objectGround, GameObject _player, SpriteRenderer _spriterender, Rigidbody2D _rb, BoxCollider2D _boxCollider)
    {
        //All sequences for respawn the _player

        //Make possible acces _player script
        _script = _player.GetComponent<PlayerController>();

        //First, i active the child to let evaluate if the _player is touching ground
        _objectGround.SetActive(true);

        //The original scale
        _player.transform.localScale = new Vector3(15f, 15f, 0f);

        //The original values in the components
        _rb.gravityScale = 9f;
        _boxCollider.isTrigger = false;
        _spriterender.sortingOrder = 0;
        _spriterender.flipX = false;
        _spriterender.flipY = false;

        //Translate the position and start blinking mode. I put all the components of the vector becuase in lvl4, the hit of the column change position in z
        _player.transform.position = new Vector3(_respawnPosition.transform.position.x, _respawnPosition.transform.position.y, 0f);

        StartCoroutine(BlinkerPlayer(_player));

    }
    IEnumerator BlinkerPlayer(GameObject _object)
    {
        _object.gameObject.SetActive(true);

        yield return new WaitForSeconds(_blinkingTimingRespawn);
        _object.gameObject.SetActive(false);

        yield return new WaitForSeconds(_blinkingTimingRespawn);
        _object.gameObject.SetActive(true);

        yield return new WaitForSeconds(_blinkingTimingRespawn);
        _object.gameObject.SetActive(false);

        yield return new WaitForSeconds(_blinkingTimingRespawn);
        _object.gameObject.SetActive(true);

        _script.enabled = true;
    }

    #endregion

    #region Unity Callbacks

    private void OnEnable()
    {
        #region Origin CinematicExplosionToPlayer

        GameManager.OnGameManagerStartRewspawnPlayerLv1 += Respawn;

        #endregion

        #region Origin SpikeCollider

        GameManager.OnGameManagerGotoRespawnlv2 += Respawn;

        #endregion

        #region Origin AuxColliderColumTrick

        GameManager.OnGameManagerPlayerdRespawnlv4 += Respawn;

        #endregion

        #region Origin ColliderRespawner

        GameManager.OnGameManagerRespawnPlayerLvl5 += Respawn;

        #endregion

        #region Origin CameraVision

        GameManager.OnGameManagerRespawnPlayerLvl6 += Respawn;

        #endregion
    }

    private void OnDestroy()
    {
         #region Origin CinematicExplosionToPlayer

        GameManager.OnGameManagerStartRewspawnPlayerLv1 -= Respawn;

        #endregion

        #region Origin SpikeCollider

        GameManager.OnGameManagerGotoRespawnlv2 -= Respawn;

        #endregion

        #region Origin AuxColliderColumTrick

        GameManager.OnGameManagerPlayerdRespawnlv4 -= Respawn;

        #endregion

        #region Origin ColliderRespawner

        GameManager.OnGameManagerRespawnPlayerLvl5 -= Respawn;

        #endregion

        #region Origin CameraVision

        GameManager.OnGameManagerRespawnPlayerLvl6 -= Respawn;

        #endregion
    }

    #endregion
}
