using UnityEngine;
using System.Collections;
using System.Linq;

public class Spikes : MonoBehaviour
{
    [SerializeField] GameObject _spike;
    [SerializeField] Rigidbody2D _rbSpike;
    [SerializeField] float _gravityValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            _rbSpike.gravityScale = _gravityValue;

        Destroy(_spike, 10f);
    }
}

