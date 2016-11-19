using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSelection : MonoBehaviour {
    public string _beginScene = "scene1";

	public void LoadGame()
    {
        GameManager.GetInstance().Load();
    }

    public void LoadBegin()
    {
        GameManager.GetInstance().Save(_beginScene);
        GameManager.GetInstance().Load();
    }

    public void LoadTutorial()
    {
//        SceneManager.LoadScene("tuto");
    }

    public void LoadSynopsis()
    {
//        SceneManager.LoadScene("synopsis");
    }

    public void LoadCredits()
    {
//        SceneManager.LoadScene("credits");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        
    }
}
