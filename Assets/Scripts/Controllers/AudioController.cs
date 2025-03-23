using UnityEngine;

public class AudioController : MonoBehaviour
{
    #region Fields

    [SerializeField] AudioClip _respawnBombSound;
    [SerializeField] AudioClip _explotionBombSound;
    [SerializeField] AudioClip _hitWithCamera;
    
    //Back Values
    private AudioSource _audioSource;

    #endregion

    #region Related about the bomb

    private void MakeAudioRespawnBomb()
    {
        _audioSource.clip = _respawnBombSound;
        _audioSource.Play();
    }

    private void MakeBombExplotionSound()
    {
        _audioSource.clip = _explotionBombSound;
        _audioSource.Play();
    }

    #endregion

    #region Related about the camera

    private void HitCamera()
    {
        _audioSource.clip = _hitWithCamera;
        _audioSource.Play();
    }

    #endregion

    #region Unity Callbacks

    private void OnEnable()
    {
        #region Origin BombToCatch

        GameManager.OnGameManagerMakeSoundReactiveBomb += MakeAudioRespawnBomb;

        #endregion

        #region Origin TrhowBomb

        GameManager.OnGameManagerSoundBombExploted += MakeBombExplotionSound;

        #endregion

        #region Origin CinematicExplosionToPlayer

        GameManager.OnGameManagerMakeSoundForTheHitWithCamera += HitCamera;

        #endregion
    }

    private void OnDestroy()
    {
        #region Origin BombToCatch

        GameManager.OnGameManagerMakeSoundReactiveBomb -= MakeAudioRespawnBomb;

        #endregion

        #region Origin TrhowBomb

        GameManager.OnGameManagerSoundBombExploted -= MakeBombExplotionSound;

        #endregion

        #region Origin CinematicExplosionToPlayer

        GameManager.OnGameManagerMakeSoundForTheHitWithCamera -= HitCamera;

        #endregion
    }

    private void Start() => _audioSource = GetComponent<AudioSource>();

    #endregion
}
