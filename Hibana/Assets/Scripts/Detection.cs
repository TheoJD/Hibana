using UnityEngine;
using System.Collections;

public class Detection : MonoBehaviour {

    const string _playerTag = "Player";

	void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == _playerTag)
        {
 //           Debug.Log("Detected");
            this.SendMessageUpwards("PlayerDetected", true);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == _playerTag)
        {
            this.SendMessageUpwards("PlayerDetected", false);
        }
    }
}
