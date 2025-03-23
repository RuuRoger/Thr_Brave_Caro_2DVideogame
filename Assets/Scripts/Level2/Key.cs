using System;
using UnityEngine;

public class Key : MonoBehaviour
{
    #region Events

    public static event Action OnKeyCatched; //Notify to WoodDoor that it's possible "open" the door

    #endregion

    #region Unity Callbacks

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Diseable object when this touch _player

        if (collision.gameObject.CompareTag("Player"))
        {
            OnKeyCatched?.Invoke();
            this.gameObject.SetActive(false);
        }
            
    }

    #endregion
}
