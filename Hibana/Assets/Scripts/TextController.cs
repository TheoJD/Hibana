using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour {
    public Text[] _script;
    public float _fadeSpeed = 2.5f;
    public float _timeBetweenParagraphs = 2.5f;
    public string _nextScene = "menu";
    private Color _invisible = new Color(1.0f, 1.0f, 1.0f, 0.0f); // Invisible white color
   // private Color _visible = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    private float _fadeValue;
    private int _currenParagraphIndex = 0;
    private bool _fadingIn = true;
    private bool _fadingOut = true;
    private bool _fadeAllowed = false;
    private bool _waitHasBegun = false;

    void Start ()
    {
        _fadingIn = _fadingOut = (_script.Length > 0); // If there are no paragraph, we load directly the next scene
        _fadeValue = Time.fixedDeltaTime / _fadeSpeed; // Difference of transparency wished between two frames
        // We make sure every paragraph is invisible at the beginning
        foreach (Text paragraph in _script)
        {
            paragraph.color = _invisible;
        }
        StartCoroutine(NextScene());
    }

    void FixedUpdate()
    {
        // First step : the paragraphs appear one after another
        if (_fadingIn)
        {
            FadeIn();
        }
        // Second step : the paragraphs disappear one after another
        else if (_fadingOut)
        {
            FadeOut();
        }
    }
	
    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(39f);
        GetComponent<ScreenFader>().Fade(1);
        yield return new WaitForSeconds(2f);
        GameManager.GetInstance().SaveAndLoadNextScene(_nextScene);
    }

    IEnumerator WaitBetweenParagraphs()
    {
        yield return new WaitForSeconds(_timeBetweenParagraphs);
        _fadeAllowed = true;
        _waitHasBegun = false;
    }

    void FadeIn()
    {
        // If we are not waiting between two apperances
        if (_fadeAllowed)
        {
            float newAlpha = _script[_currenParagraphIndex].color.a + _fadeValue;
            _script[_currenParagraphIndex].color = new Color(1.0f, 1.0f, 1.0f, newAlpha); // current paragraph becomes more visible
            // If the paragraph has fully appeared
            if (newAlpha >= 1.0f)
            {
                _fadeAllowed = false;
                ++_currenParagraphIndex;
                // If all paragraphs have appeared, first step is over
                if (_currenParagraphIndex == _script.Length)
                {
                    _currenParagraphIndex = 0;
                    _fadingIn = false;
                }
            }
        }
        // If the Coroutine for the wait between two appearances has not been launched yet
        else if (!_waitHasBegun)
        {
            _waitHasBegun = true;
            StartCoroutine(WaitBetweenParagraphs());
        }
    }

    void FadeOut()
    {
        if (_fadeAllowed)
        {
            float newAlpha = _script[_currenParagraphIndex].color.a - _fadeValue;
            _script[_currenParagraphIndex].color = new Color(1.0f, 1.0f, 1.0f, newAlpha); // current paragraph becomes less visible
            // If the paragraph has fully disappeared
            if (newAlpha <= 0.0f)
            {
                _fadeAllowed = false;
                ++_currenParagraphIndex;
                // If all paragraphs have disappeared, second step is over
                if (_currenParagraphIndex == _script.Length)
                {
                    _currenParagraphIndex = 0;
                    _fadingOut = false;
                }
            }
        }
        else if (!_waitHasBegun)
        {
            _waitHasBegun = true;
            StartCoroutine(WaitBetweenParagraphs());
        }
    }

    public void ChangeParagraph(int index, string newParagraph)
    {
        if (index >= 0 && index < _script.Length)
            _script[index].text = newParagraph;
    }
}
