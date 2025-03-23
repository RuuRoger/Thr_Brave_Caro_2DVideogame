using System;
using UnityEditor;
using UnityEngine;

public class Grass : MonoBehaviour
{
#region Fields

    [Header("Object")]
    [SerializeField] private GameObject _player;

    [Header("Transparency")]
    [Range(0f,1f)]
    [SerializeField] private float _alphaColor;

    //Back Value
private SpriteRenderer _spriterender;

    #endregion

#region Events

    public static event Action<SpriteRenderer, float> OnGrassStealthStart; //Send a spriterender and float value to AnimationController to reduce the alpha
    public static event Action<SpriteRenderer, float> OnGrassStealthFinish; //Send a spriterender and float value to AnimationController to restart alpha
    public static event Action OnGrassIsInGrass; //Notify to CameraVision that player is in grass
    public static event Action OnGrassOutOfGrass; //Notify to CameraVision that player exit of grass

#endregion

#region Unity Callbacks

    private void Awake() => _spriterender = _player.GetComponent<SpriteRenderer>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
            OnGrassStealthStart?.Invoke(_spriterender, _alphaColor);   
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            OnGrassIsInGrass?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            OnGrassStealthFinish?.Invoke(_spriterender, _alphaColor);
            OnGrassOutOfGrass?.Invoke();
        }     
    }

#endregion
}
