using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSelection : MonoBehaviour {
    [SerializeField] private string _beginScene = "introduction";
    [SerializeField] private bool _change = false;
    private AudioFader _audioFader = null;
    private ScreenFader _screenFader = null;
    private float _wait = 2f;

    void Start()
    {
        _audioFader = GetComponent<AudioFader>();
        _screenFader = GetComponent<ScreenFader>();
    }

	public void LoadGame()
    {
        StartCoroutine(WaitLoadGame());
    }

    private IEnumerator WaitLoadGame()
    {
        _screenFader.Fade(1);
        yield return new WaitForSeconds(_wait);
        GameManager.GetInstance().LoadGame();
    }

    public void LoadBegin()
    {
        StartCoroutine(WaitBegin());
    }

    private IEnumerator WaitBegin()
    {
        _screenFader.Fade(1);
        yield return new WaitForSeconds(_wait);
        GameManager.GetInstance().SaveAndLoadNextScene(_beginScene);
    }

    public void Quit()
    {
        StartCoroutine(WaitQuit());
    }

    private IEnumerator WaitQuit()
    {
        _screenFader.Fade(1);
        yield return new WaitForSeconds(_wait);
        GameManager.GetInstance().Quit();
    }

    public void LoadScene(string scene)
    {
        Time.timeScale = 1;
        StartCoroutine(WaitScene(scene));
    }

    private IEnumerator WaitScene(string scene)
    {
        _screenFader.Fade(1, _change);
        if (_audioFader != null)
            _audioFader.Fade(-1);
        yield return new WaitForSeconds(_wait);
        GameManager.GetInstance().EnableControl(true);
        GameManager.GetInstance().LoadScene(scene);
    }

    private IEnumerator WaitSceneAndLoad(string scene)
    {
        _screenFader.Fade(1, _change);
        if (_audioFader != null)
            _audioFader.Fade(-1);
        yield return new WaitForSeconds(2f);
        GameManager.GetInstance().EnableControl(true);
        GameManager.GetInstance().SaveAndLoadNextScene(scene);
    }

    public void SaveAndLoadScene(string scene)
    {
        StartCoroutine(WaitSceneAndLoad(scene));
    }
}
