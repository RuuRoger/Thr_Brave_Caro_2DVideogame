using UnityEngine;

public class WoodDoor : MonoBehaviour
{
#region Fields
    //Back Values
    private bool _getKey;
#endregion

#region Method
    private void LetOpentheDoor() => _getKey = true;
#endregion

#region Unity Callbacks

    private void OnEnable()
    {
        //Origin Key
        GameManager.OnGameManagerLetOpenWoodDoor += LetOpentheDoor;
    }

    private void Start() => _getKey = false;

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (_getKey && collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        //Origin Key
        GameManager.OnGameManagerLetOpenWoodDoor -= LetOpentheDoor;
    }

#endregion

}
