using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BombToCatch : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject _stone;

    #endregion

    #region Events

    public static event Action OnPlayerCatchTheBomb; //Notify to ThrowBomb that bomb touched the _player
    public static event Action OnPlayerSoundReactiveBomb; //Notify to AudioController to make respawn's bomb sound

    #endregion

    #region Methods

    private void MakeInvokeWithTimeForTheSetActiveBomb() => Invoke("ReactiveBomb", 5f); //Call the method waiting 5 seconds to start

    private void ReactiveBomb() //The idea is if stone isn't destroyed, active again the bomb
    {
        if(_stone != null)
        {
            OnPlayerSoundReactiveBomb?.Invoke();
            this.gameObject.SetActive(true);
        }
    }

    #endregion

    #region Unity Callbacks

    private void OnEnable()
    {
        #region Origin TrhowBomb

        GameManager.OnGameManagerBombWasExploted += MakeInvokeWithTimeForTheSetActiveBomb;

        #endregion
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) //When the object is touched by the _player, disenable the object and notify that _player "catched" the bomb
        {
            this.gameObject.SetActive(false);
            OnPlayerCatchTheBomb?.Invoke();
        }
    }

    private void OnDestroy()
    {
        #region Origin TrhowBomb

        GameManager.OnGameManagerBombWasExploted -= MakeInvokeWithTimeForTheSetActiveBomb;

        #endregion        
    }
    #endregion
}
