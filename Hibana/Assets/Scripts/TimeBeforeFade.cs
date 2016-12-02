using UnityEngine;
using System.Collections;

public class TimeBeforeFade : MonoBehaviour {
    public float _timeBeforeFade=0;
	private ScreenFader _fader;
    private int _fadeDirection = -1;
    // Use this for initialization
    void Start()
    {
		_fader = GetComponent<ScreenFader> ();
        StartCoroutine(waitingBeforeFading(_timeBeforeFade));
    }

    public IEnumerator waitingBeforeFading(float time)
    {
        yield return new WaitForSeconds(time);
        _fader.Fade(_fadeDirection);
        _fadeDirection *= -1;
    }
}
