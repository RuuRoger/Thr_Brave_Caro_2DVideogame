using System;
using System.Collections;
using UnityEngine;

public class CinematicExplosionToPlayer : MonoBehaviour
{
    #region Fields

    [Header("Objects")]
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _groundForJump; //If this object is active, the _player can't fall
    [SerializeField] Camera _camera;

    //Back values
    private PlayerController _scriptPlayer;
    private CameraPlayerFollow _scriptCamera;

    #endregion

    #region Events

    public static event Action OnCinematicExplotionMakeHitSoundPlayer; // Notfy to AudicoController to active the hit sound betwen camera and _player 
    public static event Action<GameObject, GameObject, SpriteRenderer, Rigidbody2D, BoxCollider2D> OnCinematicCallRespawnPlayerLevel; //Send some variables to start _player respawn

    #endregion

    #region Private Methods
    private void Cinematic()
    {
        _scriptPlayer.enabled = false;

        //First, i get the components of the object
        Rigidbody2D _playerRB = _player.GetComponent<Rigidbody2D>();
        BoxCollider2D _playerCollider = _player.GetComponent<BoxCollider2D>();
        SpriteRenderer _playerSprRender = _player.GetComponent<SpriteRenderer>();

        //I desactive the _player to simulated the _player blow up
        _player.SetActive(false);
        StartCoroutine(SequenceOfCinematic(_player, _playerRB, _playerCollider, _playerSprRender));

    }

    IEnumerator SequenceOfCinematic(GameObject _object, Rigidbody2D _rigidbody, BoxCollider2D _collider, SpriteRenderer _spriteRender)
    {
        //Look if the camera gets the script in the scene
        if (_scriptCamera != null)
            _scriptCamera.enabled = false;

        yield return new WaitForSeconds(0.9f);
        //Put the player in the middle of the camera and make it bigger
        _object.transform.position = new Vector3(_camera.transform.position.x, _camera.transform.position.y, 1f);
        _object.transform.localScale = new Vector3(80f, 80f, 1f);

        //Some values about player when this hit the camera
        _spriteRender.flipY = true;
        _spriteRender.sortingOrder = 1;
        _rigidbody.simulated = false;
        _collider.isTrigger = true;
        _object.SetActive(true);
        //make a sound
        OnCinematicExplotionMakeHitSoundPlayer?.Invoke();

        //Values to make a shake in camera
        float _elapsedTime = 0f;
        float _shakeDuartion = 1f;
        float _shakeMagnitud = 0.6f;
        Vector3 _originalPositionCamera = _camera.transform.localPosition;

        //Make a shake
        while (_elapsedTime < _shakeDuartion)
        {
            Vector3 _randomOffset = UnityEngine.Random.insideUnitSphere * _shakeMagnitud;
            _camera.transform.localPosition = _originalPositionCamera + new Vector3(_randomOffset.x, _randomOffset.y, _originalPositionCamera.z);
            _elapsedTime += Time.deltaTime;

            yield return null;
        }

        yield return new WaitForSeconds(0.2f);

        //Restart origina values to player to let it fall
        _rigidbody.simulated = true;
        _rigidbody.gravityScale = 80f;
        _groundForJump.SetActive(false);

        yield return new WaitForSeconds(1f);
        //Respawn player
        OnCinematicCallRespawnPlayerLevel?.Invoke(_groundForJump, _player, _spriteRender, _rigidbody, _collider);
        
        //If camera get the script, let it works (following the player. I do this because i could do it well with unity editor...)
        if (_scriptCamera != null)
            _scriptCamera.enabled = true;

    }

    #endregion

    #region Unity Callbacks

    private void OnEnable()
    {
        #region Origin BombCollisionDetection

        GameManager.OnGameManagerKillPlayerByExplotion += Cinematic;

        #endregion
    }
    private void Start()
    {
        _scriptPlayer = _player.GetComponent<PlayerController>();
        _scriptCamera = _camera.GetComponent<CameraPlayerFollow>();
    }

    private void OnDestroy()
    {
        #region Origin BombCollisionDetection

        GameManager.OnGameManagerKillPlayerByExplotion -= Cinematic;

        #endregion
    }

    #endregion
}
