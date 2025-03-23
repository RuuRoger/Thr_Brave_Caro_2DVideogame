using System;
using System.Collections;
using UnityEngine;

public class TrhowBomb : MonoBehaviour
{
    #region Fields

    [Header("Prefab")]
    [SerializeField] GameObject _bombPrefab;

    [Header("Values of Force to Throw the Bomb")]
    [SerializeField] float _throwForceInX;
    [SerializeField] float _throwForceInY;

    [Header("Times to Start Animations")]
    [SerializeField] float _timeToStartExplosionAnimation;
    [SerializeField] float _timeToDestroyBombAnimation;

    [Header("Spirte for the Explotion")]
    [SerializeField] Sprite _explosionSprite;

    //Back Values
    private Vector2 _forceDirection;
    private Vector2 _oppositeForceDirection;
    private bool _playerCatchedTheBomb;
    private bool _playerUseNotFlip;
    private bool _playerUseFlip;

    #endregion

    #region Events

    public static event Action<Animator> OnThrowBombAnimation; //Send an animator and notify "AnimatorController" the bomb is throwed, to start animation's bomb
    public static event Action OnThrowBombBombExploted; // Notify "AnimatorController" to start explotion for the animation
    public static event Action OnThrowBombSoundBombSequence; //Notify "AudioController" to active sound explotion

    #endregion

    #region Methods Boolean States Control

    private void PlayerGetTheBomb() => _playerCatchedTheBomb = true;

    private void PlayerIsWithoutFlip(SpriteRenderer _spriteRender) //It's a void method. I only use a parameter because the delegate use it and demands
    {
        _playerUseNotFlip = true;
        _playerUseFlip = false;
    }

    private void PlayerIsWithFlipActive(SpriteRenderer _spriteRender) //It's a void method. I only use a parameter because the delegate use it and demands
    {
        _playerUseNotFlip = false;
        _playerUseFlip = true;
    }

    #endregion

    #region Methods Process Bomb

    private void ThrowTheBomb()
    {
        if (_playerUseNotFlip)
        {
            //At first, i create the instance's bomb
            GameObject _newBomb = Instantiate(_bombPrefab, this.transform.position, this.transform.rotation);

            //I get some components by the object
            Rigidbody2D _newBombRb = _newBomb.GetComponent<Rigidbody2D>();
            CircleCollider2D _newBombCollider = _newBomb.GetComponent<CircleCollider2D>();
            Animator _newBombAnimator = _newBomb.GetComponent<Animator>();
            SpriteRenderer _newBombSpriteRender = _newBomb.GetComponent<SpriteRenderer>();

            //Make possible to throw the bomb
            _newBombRb.AddForce(_forceDirection, ForceMode2D.Impulse);

            //This is a stack of corutines. With this, i can make a sequence actions controlling the times that i could change in the editor
            StartCoroutine(ActiveBombAnimation(_newBombAnimator));
            StartCoroutine(ChangeRenderBombExplosion(_newBombAnimator,_newBombSpriteRender));
            StartCoroutine(LookWhatIsInColliderTrigger(_newBombCollider));

            //Destroy bomb
            Destroy(_newBomb, _timeToDestroyBombAnimation + 0.5f);

        }
        else //This is the same, but change de force directon
        {
            //At first, i create the instance's bomb
            GameObject _newBomb = Instantiate(_bombPrefab, this.transform.position, this.transform.rotation);

            //I get some components by the object
            Rigidbody2D _newBombRb = _newBomb.GetComponent<Rigidbody2D>();
            CircleCollider2D _newBombCollider = _newBomb.GetComponent<CircleCollider2D>();
            Animator _newBombAnimator = _newBomb.GetComponent<Animator>();
            SpriteRenderer _newBombSpriteRender = _newBomb.GetComponent<SpriteRenderer>();

            //Make possible to throw the bomb
            _newBombRb.AddForce(_oppositeForceDirection, ForceMode2D.Impulse);

            //This is a stack of corutines. With this, i can make a sequence actions controlling the times that i could change in the editor
            StartCoroutine(ActiveBombAnimation(_newBombAnimator));
            StartCoroutine(ChangeRenderBombExplosion(_newBombAnimator, _newBombSpriteRender));
            StartCoroutine(LookWhatIsInColliderTrigger(_newBombCollider));

            //Destroy bomb
            Destroy(_newBomb, _timeToDestroyBombAnimation + 0.5f);

        }

        //Noty that bomb is exploted
        OnThrowBombBombExploted?.Invoke();

    }

    IEnumerator ActiveBombAnimation(Animator _animator)
    {
        yield return new WaitForSeconds(_timeToStartExplosionAnimation);
        OnThrowBombAnimation?.Invoke(_animator); 
    }

    IEnumerator ChangeRenderBombExplosion(Animator _animator, SpriteRenderer _spriteRender)
    {
        yield return new WaitForSeconds(_timeToDestroyBombAnimation);
        _animator.enabled = false;
        _spriteRender.sprite = _explosionSprite;
        OnThrowBombSoundBombSequence?.Invoke();

    }

    IEnumerator LookWhatIsInColliderTrigger(CircleCollider2D _collider)
    {
        yield return new WaitForSeconds(_timeToDestroyBombAnimation + 0.4f);
        _collider.isTrigger = true;
        _collider.radius = 0.9f;
    }

    #endregion

    #region Unity Callbacks

    private void OnEnable()
    {
        #region Origin BombToCatch

        GameManager.OnGameManagerInformThatPlayerGetTheBomb += PlayerGetTheBomb;

        #endregion

        #region Origin PlayerController

        GameManager.OnGameManagerPlayerFlipOff += PlayerIsWithoutFlip;
        GameManager.OnGameManagerPlayerFlipOn += PlayerIsWithFlipActive;

        #endregion
    }

    private void Start()
    {
        //Boolean states at first
        _playerCatchedTheBomb = false;

        //Vectors2 values at first
        _forceDirection = new Vector2(_throwForceInX, _throwForceInY);
        _oppositeForceDirection = new Vector2(_throwForceInX * (-1f), _throwForceInY);

    }

    private void Update()
    {
        //Let throw the bomb if before was "catched" using intro, "reteurn"

        if (_playerCatchedTheBomb && (Input.GetKeyUp(KeyCode.Return) || Input.GetKey(KeyCode.JoystickButton2)))
        {
            _playerCatchedTheBomb = false;
            ThrowTheBomb();
        }
           
    }

    private void OnDestroy()
    {
        #region Origin BombToCatch

        GameManager.OnGameManagerInformThatPlayerGetTheBomb -= PlayerGetTheBomb;

        #endregion

        #region Origin PlayerController

        GameManager.OnGameManagerPlayerFlipOff -= PlayerIsWithoutFlip;
        GameManager.OnGameManagerPlayerFlipOn += PlayerIsWithFlipActive;

        #endregion        
    }

    #endregion
}
