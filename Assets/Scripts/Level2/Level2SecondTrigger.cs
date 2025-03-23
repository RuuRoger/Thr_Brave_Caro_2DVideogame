using System;
using UnityEngine;

public class Level2SecondTrigger : MonoBehaviour
{

    public static event Action ActiveSpikeRock2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            ActiveSpikeRock2?.Invoke();
    }
}
