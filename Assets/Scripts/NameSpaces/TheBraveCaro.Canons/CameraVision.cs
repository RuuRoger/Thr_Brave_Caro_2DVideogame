using System;
using System.Collections;
using UnityEngine;

public class CameraVision : MonoBehaviour
{
    #region Fields

    [Header("Current Color")]
    [ColorUsage(true)]
    [SerializeField] private Color _lightColor;

    [Header("Alarm Color")]
    [ColorUsage(true)]
    [SerializeField] private Color _alarmLight;
    [SerializeField] private Renderer _lightRenderer;

    [Header("Objects to Respawn")]
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _groundPlayer;

    //Back Values
    private bool _isInGrass;
    private SpriteRenderer _spriteRender;
    private Rigidbody2D _rb;
    private BoxCollider2D _boxCollider;

    #endregion

    #region Events

    public static event Action<GameObject, GameObject, SpriteRenderer, Rigidbody2D, BoxCollider2D> OnCameraVisionRespawnPlayerLv6;

    #endregion

    #region Methods

    private void PlayerInGrass() => _isInGrass = true;

    private void PlayerOutOfGrass() => _isInGrass = false;

    IEnumerator RedLight()
    {
        _lightRenderer.material.color = _alarmLight;

        yield return new WaitForSeconds(0.5f);
        OnCameraVisionRespawnPlayerLv6?.Invoke(_groundPlayer, _player, _spriteRender, _rb, _boxCollider);

        yield return new WaitForSeconds(1.5f);
        _lightRenderer.material.color = new Color(155f/255f, 186f/255f, 11f/255f, 1f); //Doesen't works if i use the field "_lightColor" ...

    }

    #endregion

    #region Unity Callbacks

    private void Awake()
    {
        _isInGrass = false;
        _spriteRender = _player.GetComponent<SpriteRenderer>();
        _rb = _player.GetComponent<Rigidbody2D>();
        _boxCollider = _player.GetComponent<BoxCollider2D>();
    } 

    private void OnEnable()
    {
        #region Origin Grass

        GameManager.OnGameManagerPlayerInGrass += PlayerInGrass;
        GameManager.OnGameManagerPlayerOutOfGrass += PlayerOutOfGrass;

        #endregion
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && _isInGrass == false)
            StartCoroutine(RedLight());
    }

    private void OnDestroy()
    {
        #region Origin Grass

        GameManager.OnGameManagerPlayerInGrass -= PlayerInGrass;
        GameManager.OnGameManagerPlayerOutOfGrass -= PlayerOutOfGrass;

        #endregion
    }

    #endregion
}
