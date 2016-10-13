using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSelection : MonoBehaviour {


	public void LoadGame()
    {
//        SceneManager.LoadScene("scene1");
    }

    public void LoadBegin()
    {
        SceneManager.LoadScene("scene1");
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
