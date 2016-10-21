using UnityEngine;
using System.Collections;

public class TreeController : MonoBehaviour {

    public GameObject _firePrefab;
    private bool _onFire = false;

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
        }
    }
}
