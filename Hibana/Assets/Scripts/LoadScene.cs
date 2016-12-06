using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public GameObject _camera;
    public string _sceneToLoad = "menu";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == GameManager.GetInstance().GetPlayerTag())
        {
            StartCoroutine(NextScene());
        }
    }

    private IEnumerator NextScene()
    {
        GameManager.GetInstance().EnableControl(false);
        _camera.GetComponent<ScreenFader>().Fade(1);
        _camera.GetComponent<AudioFader>().Fade(-1);
        yield return new WaitForSeconds(2f);
        GameManager.GetInstance().SaveAndLoadNextScene(_sceneToLoad);
    }
}
