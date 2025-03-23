using System;
using UnityEngine;

public class Level2FirstTrigger : MonoBehaviour
{
    #region Events

    public static event Action ActiveSpikeRock; //Notify to SpikeRock that must to start

    #endregion

    #region Unity Callbacks

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            ActiveSpikeRock?.Invoke();
    }

    #endregion
}
