using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSelection : MonoBehaviour {
    public string _beginScene = "introduction";

	public void LoadGame()
    {
        GameManager.GetInstance().Load();
    }

    public void LoadBegin()
    {
        GameManager.GetInstance().SaveAndLoadNextScene(_beginScene);
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
