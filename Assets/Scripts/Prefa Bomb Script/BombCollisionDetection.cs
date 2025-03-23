using System;
using Unity.VisualScripting;
using UnityEngine;

public class BombCollisionDetection : MonoBehaviour
{

    #region Events

    public static event Action OnBombCollisionStoneWasTouchedByTheBomb; //Notify to script "Stone" to destroy the stone
    public static event Action OnKillPlayerWithExplotion; //Notify to start cinematic when explotion hit the _player

    #endregion

    #region Methods

    private void HitWithOutTriggerAboutBombAndStone() => OnBombCollisionStoneWasTouchedByTheBomb?.Invoke();

    #endregion

    #region Patch, Read the comment to understand it
    //When the tirgger collider detected the stone, all works BUT, if at first the bomb collider touch the stone first of the bomb animation, doesen't works the stone detection
    //With this new method, "OnCollisionEnter2D", i simulated a solution in this cases
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stone"))
            Invoke("HitWithOutTriggerAboutBombAndStone", 3f);
    }

    #endregion

    #region Unity Callbacks

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stone")) 
            OnBombCollisionStoneWasTouchedByTheBomb?.Invoke();

        if (collision.gameObject.CompareTag("Player"))
            OnKillPlayerWithExplotion?.Invoke();
    }

    #endregion
}
