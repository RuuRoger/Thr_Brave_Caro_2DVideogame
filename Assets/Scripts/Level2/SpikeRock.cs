using System.Collections;
using UnityEngine;

public class SpikeRock : MonoBehaviour
{
    #region Fields

    [Header("Spike Rock speed")]
    [SerializeField] private float _speed;
    private bool _shouldMove;

    #endregion

    #region Methods
    private void ActiveMovement() => _shouldMove = true;
    private void NotActiveMovement() => _shouldMove = false;

    private void VerifyMovement()
    {
        //Verify the boolean logical to start the corrutines events or stop it and respawn the spikerock.

        if (_shouldMove)
        {
            StartCoroutine(MoveToLeft());
           
        }
        else
        {
            StopCoroutine(MoveToLeft());
            RestartSpikeRock();
        }
    }

    IEnumerator MoveToLeft()
    {
        //Make the spikesrocks move to a concret position when is active

        if (this.transform.position.x > 5)
        {
           
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
        }
        else
        {
            _speed = 0;

        }

        yield return null;
    }

    private void RestartSpikeRock() => transform.position = new Vector3(112.47f, 11.82f, 0f); //SpickeRoc respawn

    #endregion

    #region Unity Callbacks

    private void OnEnable()
    {
        #region Origin Level2FirstTrigger

        GameManager.OnGameManagerPlayerTouchedTheTrigger0 +=  ActiveMovement;

        #endregion

        #region Origin SpikesCollider

        GameManager.OnGameManagerStopSpikeRcok1 += NotActiveMovement;

        #endregion        
    }

    private void Start()
    {
        //Values at first
        _shouldMove = false;

    }

    private void Update() => VerifyMovement();

    private void OnDestroy()
    {
        #region Origin Level2FirstTrigger

        GameManager.OnGameManagerPlayerTouchedTheTrigger0 -=  ActiveMovement;

        #endregion

        #region Origin SpikesCollider

        GameManager.OnGameManagerStopSpikeRcok1 -= NotActiveMovement;

        #endregion 
    }

    #endregion

}


