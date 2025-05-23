using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
#region Fields
    #region General Components      
        [Header("General Components")]
        [SerializeField] private Transform _groundChild;
        [SerializeField] private Transform _bombInstationPosition;
        [SerializeField] private float _positionBombInstantionObject;
        private RaycastHit2D _hitGround;
        private Rigidbody2D _rbPlayer;
        private Animator _aniamtorPlayer;
        private SpriteRenderer _spriteRendererPlayer;
    #endregion

    #region Fields to Move to Left And Right    
        [Header("Horizontal OnPlayerControllerMovement")]
        [SerializeField] private float _speedPlayer;
    #endregion

    #region Movement To Jump
        [Header("For Vertical OnPlayerControllerMovement")]
        [SerializeField] private float _currentJumpForce;
        [SerializeField] private int _currentJumpCounter;
        private int _jumpCounter;
        private float _jumpForce;
    #endregion

    #region Using in OnDrawGizmos
            [Header("Gizmo and Raycast Size")]
            [SerializeField] private float _gizmoSizeJump;
        #endregion

    //Back Values
    private bool _usingFlip;
#endregion

#region Events
    public static event Action<Animator> OnPlayerControllerMovement; //Send an animator and notify to "AnimatorController" the _player is moving
    public static event Action<Animator> OnPlayerControllerNotMovement; //Send an animator adn notify to "AnimatorController the playes is stop
    public static event Action<SpriteRenderer> OnPlayerControllerFlipOn; //Send an spriterender and notify to "AniamtorController" the _player use flip
    public static event Action<SpriteRenderer> OnPLayerControllerFlipOff; //Send an spriterender and notify to "AniamtorController" the _player don't use flip
#endregion

#region Private Methods
    #region Animations
        private void MovementAnimation()
        {
            //This method notify if _player is moving or not

            if (Input.GetAxis("Horizontal") != 0)
                OnPlayerControllerMovement?.Invoke(_aniamtorPlayer);
            else
                OnPlayerControllerNotMovement?.Invoke(_aniamtorPlayer);
        }

        private void CheckFlipAndInstantionBomb()
        {
            //Notify if _player use flip or not and translate the object to instantiate bombs

            if (Input.GetAxis("Horizontal") > 0)
            {
                OnPLayerControllerFlipOff?.Invoke(_spriteRendererPlayer);
                _bombInstationPosition.localPosition = new Vector3(_positionBombInstantionObject, 0f, 0f);
                _usingFlip = false;
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                OnPlayerControllerFlipOn?.Invoke(_spriteRendererPlayer);
                _bombInstationPosition.localPosition = new Vector3(-_positionBombInstantionObject, 0f, 0f);
                _usingFlip = true;
            }
        }
    #endregion

    #region Movement
    private void MoveInAxisX()
        {
            //Let move the _player and run only if is touching ground

            if ((Input.GetKey(KeyCode.M)|| Input.GetKey(KeyCode.JoystickButton0)) && _hitGround.collider != null)
                _rbPlayer.linearVelocityX = Input.GetAxis("Horizontal") * _speedPlayer * 2;
            else
                _rbPlayer.linearVelocityX = Input.GetAxis("Horizontal") * _speedPlayer;
        }

    private void MoveInAxisY()
    {
    // Method to control the jump logic. Includes a counter for double jump.

        if (_hitGround.collider != null) // Evaluate if the player is on the ground
        {
            _jumpForce = _currentJumpForce;
            _jumpCounter = _currentJumpCounter;
        }

        if ((Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.JoystickButton1))) // Jump
        {
            if (_jumpCounter > 0) // Ensure jumpCounter allows jumps
            {
                _rbPlayer.AddForce(Vector2.up * Mathf.Clamp(_jumpForce, 0, _currentJumpForce), ForceMode2D.Impulse);
                _jumpCounter--;
            }

            if (_jumpCounter <= 0)
            {
             _jumpForce = 0; // Reset jump force if no jumps remain
            }
        }
    }


    private void RayCastForJump() => _hitGround = Physics2D.Raycast(_groundChild.position, Vector2.down, _gizmoSizeJump);

    #endregion
#endregion

#region Unity Callbacks
    private void Awake()
    {
        _rbPlayer = gameObject.GetComponent<Rigidbody2D>();
        _aniamtorPlayer = gameObject.GetComponent<Animator>();
        _spriteRendererPlayer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        //Jump Actions
        _jumpForce = _currentJumpForce;
        _jumpCounter = _currentJumpCounter;

        //State of boolean at first
        _usingFlip = false;
    }

    private void FixedUpdate() => MoveInAxisX();

    private void Update()
    {
        MoveInAxisY(); //Jump
        RayCastForJump(); //Just a raycast
        MovementAnimation(); //Notify animations
        CheckFlipAndInstantionBomb(); //Control flips annd bomb instation position too
    }

    private void OnDrawGizmos()
    {
        //Look the ground if can jump the _player or not (to help developer & designer)
        Gizmos.color = Color.black;
        Gizmos.DrawRay(_groundChild.position, Vector3.down * _gizmoSizeJump);
    }
#endregion

}
