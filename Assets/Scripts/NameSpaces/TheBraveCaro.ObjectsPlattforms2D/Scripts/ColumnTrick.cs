using UnityEngine;

namespace TheBraveCaro.ObjectsPlattform2D
{
    [RequireComponent(typeof(BoxCollider2D))]

    public class ColumnTrick : ObjectPlatform2D
    {
    #region Methods

        private void DestroyObject() => Destroy(gameObject);

    #endregion

    #region Unity Callbacks

        private void Awake() => GameManager.OnGameManagerDestroyColumnsLvl4 += DestroyObject;

        private void Update() => ControlState();

        private void OnDestroy() => GameManager.OnGameManagerDestroyColumnsLvl4 -= DestroyObject;

    #endregion

    }

}