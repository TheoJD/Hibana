using UnityEngine;
using System.Collections;

public class TreeController : MonoBehaviour {

    public GameObject _firePrefab;
    private bool _onFire = false;
    public AudioSource _fireSound;

    void Start()
    {
        GameManager.GetInstance().NewTree();
    }

    public void OnFireShot(float y)
    {
        if (!_onFire)
        {
            Vector3 origin = transform.position;
            origin.y = y;
            origin.z -= 1;
            Instantiate(_firePrefab, origin, transform.rotation);
            _onFire = true;
            GameManager.GetInstance().TreeBurned();
            if (_fireSound != null && _fireSound.volume < 1)
                _fireSound.volume += 0.05f;
        }
    }
}
