using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public string _sceneToLoad = "menu";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == GameManager.GetInstance().GetPlayerTag())
        {
            GameManager.GetInstance().Save();
            SceneManager.LoadScene(_sceneToLoad);
        }
    }
}
