using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(UnityStandardAssets._2D.PlatformerCharacter2D))]
public class LoadFire : MonoBehaviour {
    private int _loadCapacity = 1;
    private AudioSource  _audioSource;
    private SpriteRenderer _spriteRenderer;
    private bool _pickedUp = false;
    public GameObject _fire;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (!_pickedUp && collider.tag == GameManager.GetInstance().GetPlayerTag())
        {
            _audioSource.Play();
            GameManager.GetInstance().LoadMunition(_loadCapacity);
            _spriteRenderer.enabled = false;
            _fire.SetActive(false);
            _pickedUp = true;
            Destroy(gameObject, 2.0f);
        }
    }
}
