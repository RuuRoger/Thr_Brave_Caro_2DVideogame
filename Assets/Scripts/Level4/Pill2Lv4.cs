using System;
using UnityEngine;

public class Pill2Lv4 : MonoBehaviour
{

    #region Events

    public static event Action Onpill2DidIt; //Notify to pill3 to active

    #endregion

    #region Methods

    private void ActivePill2Lvl4() => this.gameObject.SetActive(true); //Show object

    private void RespawnCatchPills() => this.gameObject.SetActive(false); //Diseable object to catch pills again

    #endregion

    #region Unity Callbacks

    private void Awake()
    {
        GameManager.OnGameManagerActivePill2Lvl4 += ActivePill2Lvl4;
        GameManager.OnGameManagerRespawnPillsLvl4 += RespawnCatchPills;
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Onpill2DidIt?.Invoke();
            this.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        GameManager.OnGameManagerActivePill2Lvl4 -= ActivePill2Lvl4;
        GameManager.OnGameManagerRespawnPillsLvl4 -= RespawnCatchPills;     
    }

    #endregion

}
