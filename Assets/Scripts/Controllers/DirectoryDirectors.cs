using UnityEngine;

public class DirectoryDirectors : MonoBehaviour
{
    private void Awake() => DontDestroyOnLoad(gameObject);
}
