using UnityEngine;
using System.Collections;

public class TreeController : MonoBehaviour {

    public GameObject _firePrefab;
    private bool _onFire = false;

    void Start()
    {
        GameManager.GetInstance().NewTree();
    }

    public void OnFireShot(float y)
    {
        if (!_onFire)
        {
            GameObject fire;
            Vector3 origin = transform.position;
            origin.y = y;
            origin.z -= 1;
            fire = Instantiate(_firePrefab, origin, transform.rotation) as GameObject;
            fire.transform.parent = transform;
            _onFire = true;
            GameManager.GetInstance().TreeBurned();
        }
    }
}
