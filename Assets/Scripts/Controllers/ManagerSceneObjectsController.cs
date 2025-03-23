using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerSceneObjectsController : MonoBehaviour
{
#region Fields

    [SerializeField] private GameObject _stonePrefab;

    //Back values

    private string _currentScene;

    #endregion

    #region Unity Callbacks

    private void Start()
    {
        _currentScene = SceneManager.GetActiveScene().name;

        {
            if (_currentScene == "Level2")
            {
                
            }
        }
    }

    #endregion
}
