using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel5 : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (this.isActiveAndEnabled)
            if (collision.gameObject.CompareTag("Player") && Input.GetAxis("Vertical") != 0)
                SceneManager.LoadScene("Level5");
    }
}
