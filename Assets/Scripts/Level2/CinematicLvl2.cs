using System;
using System.Collections;
using UnityEngine;

public class CinematicLvl2 : MonoBehaviour
{
    #region Fields

    [Header("Objects")]
    [SerializeField] private GameObject _bridge;
    [SerializeField] private GameObject _key;
    [SerializeField] private GameObject _spikeRock2;
    [SerializeField] private GameObject _pointToRespawnPlayer;
    [SerializeField] private GameObject _auxiliarCollider;

    [Header("Speed")]
    [SerializeField] float _speedSpikeRock2;

    #endregion

    #region Events

    public static event Action OnFinishCinematic; //Notify SpikeRock2 that can turn on initial position

    #endregion

    #region Methods
    private void Cinematic() => StartCoroutine(SequencesCinematic());
    
    IEnumerator SequencesCinematic()
    {
        //Freeze the time and move the spikerock to a concret position. Then, let the _player continous destroying the briedge and showing the key
        //Also, it change the respawn _player position and don't let the _player turn back with a invisible collider

        Time.timeScale = 0f;

        while(_spikeRock2.transform.position.x > -105)
        {
            _spikeRock2.transform.Translate(Vector2.left * _speedSpikeRock2 * Time.unscaledDeltaTime);
            yield return null;
        }

        Destroy(_bridge);
        _key.SetActive(true);
        OnFinishCinematic?.Invoke();
        _pointToRespawnPlayer.transform.position = new Vector3(30.86f, -6.99f, 0f);
        _auxiliarCollider.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }

    #endregion

    #region Unity Callbacks

    private void OnEnable()
    {
        #region Oirigin StopAndDestroyBridge

        GameManager.OnStartCinematicLevel2 += Cinematic;

        #endregion
    }

    private void OnDestroy()
    {
        #region Oirigin StopAndDestroyBridge

        GameManager.OnStartCinematicLevel2 -= Cinematic;

        #endregion
    }

    #endregion

}
