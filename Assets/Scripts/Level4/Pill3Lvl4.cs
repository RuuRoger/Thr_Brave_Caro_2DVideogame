using System;
using UnityEngine;

public class Pill3Lvl4 : MonoBehaviour
{
    #region Events

    public static event Action OnPill3DidIt; //Notify pill 4 to active

    #endregion

    #region Methods

    private void ActivePill3Lvl4() => this.gameObject.SetActive(true); //Show object

    private void RespawnCatchPills() => this.gameObject.SetActive(false); //Diseable object to catch pills again

    #endregion

    #region Unity Callbacks

    private void Awake()
    {
        GameManager.OnGameManagerActivePill3lvl4 += ActivePill3Lvl4;
        GameManager.OnGameManagerRespawnPillsLvl4 += RespawnCatchPills;
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            OnPill3DidIt?.Invoke();
            this.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        GameManager.OnGameManagerActivePill3lvl4 -= ActivePill3Lvl4;
        GameManager.OnGameManagerRespawnPillsLvl4 -= RespawnCatchPills;       
    }

    #endregion

}
