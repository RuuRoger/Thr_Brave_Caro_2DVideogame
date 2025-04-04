using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowDoorLvl4 : MonoBehaviour
{
    //Back Values
    private MonoBehaviour _nextlevel;

    #region Methods

    private void ShowDoorFinalLevelLvl4() => this.gameObject.SetActive(true);

    #endregion

    #region Unity Callbacks

    private void Awake()
    {
        GameManager.OnGameManagerShowDoor += ShowDoorFinalLevelLvl4;
        this.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        GameManager.OnGameManagerShowDoor -= ShowDoorFinalLevelLvl4;
    }

    #endregion
}
