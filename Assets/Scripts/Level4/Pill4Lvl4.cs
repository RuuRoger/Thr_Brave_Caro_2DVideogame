using System;
using UnityEngine;

public class Pill4Lvl4 : MonoBehaviour
{
    #region Events

    public static event Action OnPill4DidIt; //Notify pill 4 to active

    #endregion

    #region Methods

    private void ActivePill4Lvl4() =>  this.gameObject.SetActive(true);

    private void RespawnCatchPills() => this.gameObject.SetActive(false); //Diseable object to catch pills again

    #endregion

    #region Unity Callbacks

    private void Awake()
    {
        GameManager.OngameManagerActivePill4Lvl4 += ActivePill4Lvl4;
        GameManager.OnGameManagerRespawnPillsLvl4 += RespawnCatchPills;
        this.gameObject.SetActive(false);
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnPill4DidIt?.Invoke();
            this.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        GameManager.OngameManagerActivePill4Lvl4 -= ActivePill4Lvl4;
        GameManager.OnGameManagerRespawnPillsLvl4 -= RespawnCatchPills;       
    }

    #endregion
}
