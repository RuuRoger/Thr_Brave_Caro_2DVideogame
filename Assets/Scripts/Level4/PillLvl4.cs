using System;
using UnityEngine;

public class PillLvl4 : MonoBehaviour
{
    #region Events

    public static event Action OnPill1DidIt; //Notify to Pill2 to active

    #endregion

    #region Methods

    private void StartPillAgain() => this.gameObject.SetActive(true); // If _player die, respawn pill

    #endregion

    #region Unity Callbacks

    private void Awake() => GameManager.OnGameManagerRespawnPillsLvl4 += StartPillAgain;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            OnPill1DidIt?.Invoke();
        }
    }

    private void OnDestroy() => GameManager.OnGameManagerRespawnPillsLvl4 -= StartPillAgain;

    #endregion
}
