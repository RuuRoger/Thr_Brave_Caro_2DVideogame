using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    #region Methods Related With Player

    private void Movement(Animator _animator) => _animator.SetBool("Movement", true); //Active movement animation
    private void NotMovement(Animator _animator) => _animator.SetBool("Movement", false); //Stop movement animation
    private void PlayerFlip(SpriteRenderer _spriteRender) => _spriteRender.flipX = true; //Active flip in X
    private void NotPlayerFlip(SpriteRenderer _spriteRender) => _spriteRender.flipX= false; //Uncheck flip in x
    
    private void StealthModeIn(SpriteRenderer _spirteRender, float _alpha) => _spirteRender.color = new Color(1f, 1f, 1f, _alpha); //Player transparence is doing   
    private void StealthModeOut(SpriteRenderer _spirteRender, float _alpha) => _spirteRender.color = new Color(1f, 1f, 1f, 1f); //Player transparence is normal

    #endregion

    #region Methods Related With Bomb

    private void ActiveBombAnimation(Animator _animator) => _animator.SetBool("Explosion", true); //Active explotion animation

    #endregion

    #region Unity Callbacks

    private void OnEnable()
    {
        #region Origin "PlayerController"

        GameManager.OnGameManagerPlayerMove += Movement;
        GameManager.OnGameManagerNotPlayerMove += NotMovement;
        GameManager.OnGameManagerPlayerFlipOn += PlayerFlip;
        GameManager.OnGameManagerPlayerFlipOff += NotPlayerFlip;

        #endregion

        #region Origin "ThrowBomb"

        GameManager.OnGameManagerBombAnimation += ActiveBombAnimation;

        #endregion

        #region Origin "Grass"

        GameManager.OnGameManagerStartStealth += StealthModeIn;
        GameManager.OnGameManagerFinishStealth += StealthModeOut;

        #endregion

    }

    private void OnDestroy()
    {
        #region Origin "PlayerController"

        GameManager.OnGameManagerPlayerMove -= Movement;
        GameManager.OnGameManagerNotPlayerMove -= NotMovement;
        GameManager.OnGameManagerPlayerFlipOn -= PlayerFlip;
        GameManager.OnGameManagerPlayerFlipOff -= NotPlayerFlip;

        #endregion
    
        #region Origin "ThrowBomb"

        GameManager.OnGameManagerBombAnimation -= ActiveBombAnimation;

        #endregion

        #region Origin "Grass"

        GameManager.OnGameManagerStartStealth -= StealthModeIn;
        GameManager.OnGameManagerFinishStealth -= StealthModeOut;

        #endregion
    }

    #endregion

}
