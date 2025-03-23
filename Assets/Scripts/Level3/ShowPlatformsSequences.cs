using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class ShowPlatformsSequences : MonoBehaviour
{
    #region Fields

    [Header("Objects")]
    [SerializeField] private GameObject[] _platfmors;
    [SerializeField] private SpriteRenderer[] _platformsSpriteRender;
    [SerializeField] private GameObject _key;
    private SpriteRenderer _keySpriteRender;

    [Header("Timings")]
    [SerializeField] private float _timeToStartBlinkink;
    [SerializeField] private float _timeWithBlink;
    [SerializeField] private int _blinkTimes;

    [Header("Sprites")]
    [SerializeField] Sprite _nullSprite;
    [SerializeField] private Sprite _keySprite;

    //Back values
    private bool _playerCatchedTheKey;

    #endregion

    #region Events

    public static event Action OnShowPlatformSequencesReactivePill; //Notify StartShowPlatforms that the sequences finish to active pill again

    #endregion

    #region Methods
    private void KeyCatchedOrNot() => _playerCatchedTheKey = true;

    private void Sequences() => StartCoroutine(SequencesPlatform());

    IEnumerator SequencesPlatform()
    {
        if (_playerCatchedTheKey) //blinking the platforms without key
        {

            foreach (var platform in _platfmors)
                platform.SetActive(true);

            yield return new WaitForSeconds(_timeToStartBlinkink);

            // Blinking Sequences
            for (int i = 0; i < _blinkTimes; i++)
            {
                yield return new WaitForSeconds(_timeWithBlink);

                foreach (var platform in _platformsSpriteRender)
                    platform.enabled = false;

                yield return new WaitForSeconds(_timeWithBlink);

                foreach (var platform in _platformsSpriteRender)
                    platform.enabled = true;

                i++;

            }

            //Diseable objects
            foreach (var platform in _platfmors)
                platform.SetActive(false);

            yield return null;

        }
        else //blinking the platforms with
        {
            _key.SetActive(true);

            foreach (var platform in _platfmors)
                platform.SetActive(true);

            yield return new WaitForSeconds(_timeToStartBlinkink);

            #region Blinking Sequences

            for (int i = 0; i < _blinkTimes; i++)
            {

                yield return new WaitForSeconds(_timeWithBlink);
                _keySpriteRender.sprite = _nullSprite;

                foreach (var platform in _platformsSpriteRender)
                    platform.enabled = false;

                yield return new WaitForSeconds(_timeWithBlink);
                _keySpriteRender.sprite = _keySprite;

                foreach (var platform in _platformsSpriteRender)
                    platform.enabled = true;

                i++;

            }

            #endregion

            //Desactivar
            _key.SetActive(false);

            foreach (var platform in _platfmors)
                platform.SetActive(false);

            yield return null;


        }

        OnShowPlatformSequencesReactivePill?.Invoke();

    }

    #endregion

    #region UnityCallbacks

    private void OnEnable()
    {
        #region Origin Key

        GameManager.OnGameManagerLetOpenWoodDoor += KeyCatchedOrNot;

        #endregion

        #region Origin StartShowPlatform

        GameManager.OnGameManagerStartShowPlatfomr += Sequences;

        #endregion
    }

    private void Start()
    {
        _playerCatchedTheKey = false;
        _keySpriteRender = _key.GetComponent<SpriteRenderer>();

    }

    private void OnDestroy()
    {
        #region Origin Key

        GameManager.OnGameManagerLetOpenWoodDoor -= KeyCatchedOrNot;

        #endregion

        #region Origin StartShowPlatform

        GameManager.OnGameManagerStartShowPlatfomr -= Sequences;

        #endregion
    }

    #endregion


}
