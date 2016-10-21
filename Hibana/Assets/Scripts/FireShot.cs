using UnityEngine;
using System.Collections;

public class FireShot : MonoBehaviour {
    public int _damage = 2;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == GameManager.GetInstance().GetBeastTag())
        {
            var health = collider.gameObject.GetComponent<BeastHealth>();
            if (health != null)
            {
                health.TakeDamage(_damage);
            }
            Destroy(gameObject);
        }
        else if (collider.tag == GameManager.GetInstance().GetTreeTag())
        {
            var controller = collider.gameObject.GetComponent<TreeController>();
            if (controller != null)
            {
                controller.OnFireShot(transform.position.y);
            }
        }
    }
}