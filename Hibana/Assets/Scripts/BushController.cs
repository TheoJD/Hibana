using UnityEngine;
using System.Collections;

public class BushController : MonoBehaviour {
    private const int _damages = 5;
    private const float _timeBetweenDamages = 1.5f;
    private bool _canSting = true;
    private Coroutine _coroutine;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (_canSting && collider.tag == GameManager.GetInstance().GetPlayerTag())
        {
            _coroutine = StartCoroutine(Sting());
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == GameManager.GetInstance().GetPlayerTag())
        {
            StopCoroutine(_coroutine);
            _canSting = true;
        }
    }

    private IEnumerator Sting()
    {
        while (true)
        {
            _canSting = false;
            GameManager.GetInstance().TakeDamage(_damages);
            yield return new WaitForSeconds(_timeBetweenDamages);
            _canSting = true;
        }
    }
}
