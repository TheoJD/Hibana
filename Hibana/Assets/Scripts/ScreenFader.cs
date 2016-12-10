using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour {

    // [Header("Fading In & Out")]
    [SerializeField] private Texture2D _whiteTexture;
    [SerializeField] private Texture2D _blackTexture;
    [SerializeField] private bool _fadeInWhite = true;
    [SerializeField] private bool _fadeOutWhite = true;
    public const float _fadeSpeed = 0.25f;

    private Texture2D _currentTexture;
    private float _actualSpeed = _fadeSpeed;
    private const int _drawDepth = -1000;
    private float _alpha = 1.0f;
    private int _fadeDirection = 0;               // direction to fade : in = -1, out = 1

    void Start()
    {
        if (_fadeOutWhite)
            _currentTexture = _whiteTexture;
        else
            _currentTexture = _blackTexture;
    }

    public float Fade(int direction, bool change = false, float speed = _fadeSpeed)
    {
        _fadeDirection = direction;
        _actualSpeed = speed;
        if (_fadeDirection == -1)
        {
            if ((_fadeOutWhite && !change) || (!_fadeOutWhite && change))
                _currentTexture = _whiteTexture;
            else
                _currentTexture = _blackTexture;
        }
        else if (direction == 1)
        {
            if ((_fadeInWhite && !change) || (!_fadeInWhite && change))
                _currentTexture = _whiteTexture;
            else
                _currentTexture = _blackTexture;
        }
        return (speed);
    }


    void OnGUI()
    {
        float fadeValue = _fadeDirection * _actualSpeed * Time.deltaTime;
        _alpha += fadeValue;
        _alpha = Mathf.Clamp01(_alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, _alpha);
        GUI.depth = _drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _currentTexture);
    }
}
