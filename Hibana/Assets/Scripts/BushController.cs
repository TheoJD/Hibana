using UnityEngine;
using System.Collections;

public class BushController : MonoBehaviour {
    private const int _damages = 5;
    private const float _timeBetweenDamages = 1.5f;
    private bool _canSting = true;
    private Coroutine _coroutine;
    public GameObject _firePrefab;
    private bool _onFire = false;
    public bool _isPeripheral = false;

    void Start()
    {
        if (!_isPeripheral)
            GameManager.GetInstance().NewTree();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (_canSting && collider.tag == GameManager.GetInstance().GetPlayerTag())
        {
            _coroutine = StartCoroutine(Sting());
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (!_onFire && collider.tag == GameManager.GetInstance().GetPlayerTag())
        {
            StopCoroutine(_coroutine);
            _canSting = true;
        }
    }

    private IEnumerator Sting()
    {
        while (!_onFire)
        {
            _canSting = false;
            GameManager.GetInstance().TakeDamage(_damages);
            yield return new WaitForSeconds(_timeBetweenDamages);
            _canSting = true;
        }
    }

    public void OnFireShot()
    {
        if (!_onFire)
        {
            GameObject fire;
            Vector3 origin = transform.position;
            origin.z -= 1;
            fire = Instantiate(_firePrefab, origin, transform.rotation) as GameObject;
            fire.transform.parent = transform;
            _onFire = true;
            if (_isPeripheral)
                GameManager.GetInstance().NewTree();
            GameManager.GetInstance().TreeBurned();
        }
    }
}
