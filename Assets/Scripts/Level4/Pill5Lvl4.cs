using System;
using UnityEngine;

public class Pill5Lvl4 : MonoBehaviour
{
    #region Events

    public static event Action OnPill5DestroyColums;
    public static event Action OnPill5ShowDoorFinalLevel;

    #endregion

    #region Methods

    private void ActivePill5() => this.gameObject.SetActive(true);

    private void RespawnCatchPills() => this.gameObject.SetActive(false); //Diseable object to catch pills again

    #endregion

    #region Unity Callbacks

    private void Awake()
    {
        GameManager.OnGameManagerActivePill5Lvl4 += ActivePill5;
        GameManager.OnGameManagerRespawnPillsLvl4 += RespawnCatchPills;
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);

            OnPill5DestroyColums?.Invoke();
            OnPill5ShowDoorFinalLevel?.Invoke();

            
        }
    }

    private void OnDestroy()
    {
        GameManager.OnGameManagerActivePill5Lvl4 -= ActivePill5;
        GameManager.OnGameManagerRespawnPillsLvl4 -= RespawnCatchPills;
    }

    #endregion
}
