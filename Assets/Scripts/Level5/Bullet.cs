using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
#region Events

    //This event goes to "ColliderRespawner" to act, like calling an event in that script to make code a little bit shorter
    public static event Action OnBulletTouchedPlayer;

#endregion

#region Unity Callbacks
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            OnBulletTouchedPlayer?.Invoke();

    }

#endregion
}
