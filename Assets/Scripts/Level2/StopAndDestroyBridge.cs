using System;
using UnityEngine;

public class StopAndDestroyBridge : MonoBehaviour
{
    //The pill has got this script
    //The object start the cinematic and finish the cinematic too.

    #region Events

    public static event Action ONStartCinematic;

    #endregion

    #region Methods

    private void DestroyByFinishCinematic() => Destroy(gameObject);

    #endregion

    #region Unity Calbacks

    private void OnEnable()
    {
        #region Origin CinematicLvl2

        GameManager.OnGameManagerFinishCinematic += DestroyByFinishCinematic;

        #endregion
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            ONStartCinematic?.Invoke();
    }

    private void OnDestroy()
    {
        #region Origin CinematicLvl2

        GameManager.OnGameManagerFinishCinematic -= DestroyByFinishCinematic;

        #endregion
    }

    #endregion
}
