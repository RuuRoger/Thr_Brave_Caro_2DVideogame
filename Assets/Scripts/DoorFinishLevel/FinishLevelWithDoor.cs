using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevelWithDoor : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Debug.Log("FUnciona");
    }
}
