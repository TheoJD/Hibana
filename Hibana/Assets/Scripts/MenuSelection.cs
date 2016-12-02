using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSelection : MonoBehaviour {
    [SerializeField] private string _beginScene = "introduction";
    private float _wait = 2f;
	public void LoadGame()
    {
        StartCoroutine(WaitLoadGame());
    }

    private IEnumerator WaitLoadGame()
    {
        GetComponent<ScreenFader>().Fade(1);
        yield return new WaitForSeconds(_wait);
        GameManager.GetInstance().LoadGame();
    }

    public void LoadBegin()
    {
        StartCoroutine(WaitBegin());
    }

    private IEnumerator WaitBegin()
    {
        GetComponent<ScreenFader>().Fade(1);
        yield return new WaitForSeconds(_wait);
        GameManager.GetInstance().SaveAndLoadNextScene(_beginScene);
    }

    public void Quit()
    {
        StartCoroutine(WaitQuit());
    }

    private IEnumerator WaitQuit()
    {
        GetComponent<ScreenFader>().Fade(1);
        yield return new WaitForSeconds(_wait);
        GameManager.GetInstance().Quit();
    }

    public void LoadScene(string scene)
    {
        StartCoroutine(WaitScene(scene));
    }

    private IEnumerator WaitScene(string scene)
    {
        GetComponent<ScreenFader>().Fade(1);
        yield return new WaitForSeconds(_wait);
        GameManager.GetInstance().LoadScene(scene);
    }
}
