using UnityEngine;
using System.Collections;

public class AudioFader : MonoBehaviour {
    private AudioSource _audioSource;
    public const float _fadeSpeed = 0.25f;
    private float _actualSpeed = _fadeSpeed;
    private float _volume = 0.0f;
    private int _fadeDirection = 0; // direction to fade : in = -1, out = 1

    // Use this for initialization
    void Start () {
        _audioSource = GetComponent<AudioSource>();
        Fade(1);
	}

    public float Fade(int direction, float speed = _fadeSpeed)
    {
        _fadeDirection = direction;
        _actualSpeed = speed;
        return (speed);
    }

    void Update()
    {
        if ((_fadeDirection == -1 && _volume == 0) || _fadeDirection == 1 && _volume == 1)
            return;
        float fadeValue = _fadeDirection * _actualSpeed * Time.deltaTime;
        _volume += fadeValue;
        _volume = Mathf.Clamp01(_volume);
        _audioSource.volume = _volume;
    }
}
