using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {
    private bool _inPause = false;
    private bool _canPause = false;
    public Transform canvas;
	// Use this for initialization
	void Start () {
        StartCoroutine(EnablePause());
	}

    IEnumerator EnablePause()
    {
        yield return new WaitForSeconds(2.0f);
        _canPause = true;

    }
	
	// Update is called once per frame
	void Update () {
	    if (_canPause && Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
	}
    
    public void Pause()
    {
        GameManager.GetInstance().EnableControl(_inPause);
        _inPause = !_inPause;
        canvas.gameObject.SetActive(_inPause);
        Time.timeScale = _inPause ? 0 : 1;
    }
}
