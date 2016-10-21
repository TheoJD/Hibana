using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(UnityStandardAssets._2D.PlatformerCharacter2D))]
public class LoadFire : MonoBehaviour {
    private int _loadCapacity = 1;
    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.tag == GameManager.GetInstance().GetPlayerTag())
        {
            GameManager.GetInstance().LoadMunition(_loadCapacity);
            Destroy(gameObject);
        }
    }
}
