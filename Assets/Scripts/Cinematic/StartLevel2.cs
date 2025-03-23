using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel2 : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetAxis("Vertical")!= 0)
            SceneManager.LoadScene("Level2");
    }
}
