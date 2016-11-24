using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSelection : MonoBehaviour {
    [SerializeField] private string _beginScene = "introduction";

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

    public void LoadCredits()
    {
        SceneManager.LoadScene("credits");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
