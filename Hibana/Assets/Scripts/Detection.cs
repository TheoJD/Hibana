using UnityEngine;
using System.Collections;

public class Detection : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == GameManager.GetInstance().GetPlayerTag())
        {
            this.SendMessageUpwards("PlayerDetected", true);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == GameManager.GetInstance().GetPlayerTag())
        {
            this.SendMessageUpwards("PlayerDetected", false);
        }
    }
}
