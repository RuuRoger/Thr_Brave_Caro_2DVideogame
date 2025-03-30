using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowDoorLvl4 : MonoBehaviour
{
    //Back Values
    private MonoBehaviour _nextlevel;

    #region Methods

    private void ShowDoorFinalLevelLvl4()
    {
        this.gameObject.SetActive(true);
        _nextlevel.enabled = true;
    }

    #endregion

    #region Unity Callbacks

    private void Awake()
    {
        GameManager.OnGameManagerShowDoor += ShowDoorFinalLevelLvl4;
        this.gameObject.SetActive(false);
    }

    private void Start()
    {

        if (SceneManager.GetActiveScene().name == "Level4")
            _nextlevel = gameObject.GetComponent<StartLevel5>();
        if (SceneManager.GetActiveScene().name == "Level5")
            _nextlevel = gameObject.GetComponent<StartLevel6>();

    }

    private void OnDestroy()
    {
        GameManager.OnGameManagerShowDoor -= ShowDoorFinalLevelLvl4;
    }

    #endregion
}
