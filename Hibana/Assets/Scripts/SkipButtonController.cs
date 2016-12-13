using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkipButtonController : MonoBehaviour {
    public GameObject _skipButton;
    private bool _canSkip = false;
	// Use this for initialization
	void Start ()
    {
        StartCoroutine(EnableSkip());
    }

    void Update()
    {
        if (_canSkip && (Input.GetKeyDown(KeyCode.Escape)|| Input.GetMouseButtonUp(0)))
        {
            _skipButton.SetActive(true);
        }
    }

    private IEnumerator EnableSkip()
    {
        yield return new WaitForSeconds(2.0f);
        _canSkip = true;
    }
}
