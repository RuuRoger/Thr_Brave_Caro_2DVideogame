using System;
using System.Collections;
using UnityEngine;

public class StartShowPlatforms : MonoBehaviour
{
    public static event Action OnStartShowPlatformTouchPill; //Notify ShowPlatformSequences to start corrutine

    private void ReactivePill() => this.gameObject.SetActive(true);

    private void OnEnable()
    {
        GameManager.GameManagerReactivePillToShowAgainPlatformsLvl3 += ReactivePill;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnStartShowPlatformTouchPill?.Invoke();
            this.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        GameManager.GameManagerReactivePillToShowAgainPlatformsLvl3 -= ReactivePill;
    }
}
