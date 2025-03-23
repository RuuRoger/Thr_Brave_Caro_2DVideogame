using UnityEngine;

public class Stone : MonoBehaviour
{
    #region Method
    
    private void DestroyStone() => Destroy(gameObject);

    #endregion

    #region UnityCallbacks

    private void OnEnable()
    {
        #region Origin BombCollisionDetection

        GameManager.OnGameManagerStoneMustDestroyed += DestroyStone;

        #endregion
    }

    private void OnDestroy() 
    {
        #region Origin BombCollisionDetection

        GameManager.OnGameManagerStoneMustDestroyed -= DestroyStone;

        #endregion
    }

    #endregion
}
