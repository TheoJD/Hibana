using UnityEngine;
using System.Collections;

public class FireShot : MonoBehaviour {
    private const string _enemyTag = "Enemy";
    private const string _treeTag = "Tree";
    public int _damage = 2;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == _enemyTag)
        {
            var hit = collider.gameObject;
            var health = hit.GetComponent<BeastHealth>();
            if (health != null)
            {
                health.TakeDamage(_damage);
            }
            Destroy(gameObject);
        }
        else if (collider.tag == _treeTag)
        {
            var hit = collider.gameObject;
            var onFire = hit.GetComponent<OnFire>();
            if (onFire != null)
            {
                onFire.OnFireShot(transform.position.y);
            }
        }
    }
}