using UnityEngine;
using System.Collections;

public class TimeBeforeFade : MonoBehaviour {
    public float timeBeforeFade;
	private ScreenFader fader;
    // Use this for initialization
    void Start()
    {
		fader = GetComponent<ScreenFader> ();
        StartCoroutine(waitingBeforeFading(timeBeforeFade));
    }

    IEnumerator waitingBeforeFading(float time)
    {
        yield return new WaitForSeconds(time);
        fader.Fade(-1);
    }
}
