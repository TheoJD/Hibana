using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {
    private bool inPause;
    public Transform canvas;
	// Use this for initialization
	void Start () {
        inPause = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
	}
    
    public void Pause()
    {
        inPause = !inPause;
        canvas.gameObject.SetActive(inPause);
        Time.timeScale = inPause ? 0 : 1;
    }
}
