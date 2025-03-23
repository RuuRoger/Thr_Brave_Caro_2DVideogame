using System.Collections;
using UnityEngine;

public class SpikeRock2 : MonoBehaviour
{
    #region Fields

    [Header("Spike Rock Speed")]
    [SerializeField] private float _speed;
    private bool _shouldMove;

    #endregion

    #region Methods

    private void ActiveMovement() => _shouldMove = true;
    private void NotActiveMovement() => _shouldMove = false;

    private void VerifyMovement()
    {
        //Evaluate if the spikerock can move or not and what happens

        if (_shouldMove)
            StartCoroutine(MoveToRight());
        else
        {
            StopCoroutine(MoveToRight());
            RestartSpikeRock();     
        }
    }

    IEnumerator MoveToRight()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
        yield return null;
    }
    private void RestartSpikeRock() => transform.position = new Vector3(-105.52f, -5.18f, 0f); //Respawn spikerock

    #endregion

    #region Unity Callbacks

    private void OnEnable()
    {
        #region Origin Level2SecondTrigger

        GameManager.PlayerTouchedTheTrigger1 += ActiveMovement;

        #endregion

        #region Origin CinematicLvl2

        GameManager.OnGameManagerFinishCinematic += NotActiveMovement;

        #endregion

        #region Origin SpikeCollider

        GameManager.OnGameManagerStopSpikeRock2 += NotActiveMovement;

        #endregion
    }

    private void Start()
    {
        //First values
        _shouldMove = false;
      
    }

    private void Update() => VerifyMovement();

    private void OnDestroy()
    {
        #region Origin Level2SecondTrigger

        GameManager.PlayerTouchedTheTrigger1 -= ActiveMovement;

        #endregion

        #region Origin CinematicLvl2

        GameManager.OnGameManagerFinishCinematic -= NotActiveMovement;

        #endregion

        #region Origin SpikeCollider

        GameManager.OnGameManagerStopSpikeRock2 -= NotActiveMovement;

        #endregion
    }

    #endregion

}
