using UnityEngine;
using System.Collections;

public class PlayerCloseness : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == GameManager.GetInstance().GetPlayerTag())
        {
            this.SendMessageUpwards("PlayerClosed", true);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == GameManager.GetInstance().GetPlayerTag())
        {
            this.SendMessageUpwards("PlayerClosed", false);
        }
    }
}
