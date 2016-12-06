using UnityEngine;
using System.Collections;

public class Detection : MonoBehaviour {
    private AudioSource _detectionSound;

    void Start()
    {
        _detectionSound = GetComponent<AudioSource>();
    }

	void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == GameManager.GetInstance().GetPlayerTag())
        {
            this.SendMessageUpwards("PlayerDetected", collider.gameObject.transform);
            _detectionSound.Play();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == GameManager.GetInstance().GetPlayerTag())
        {
            this.SendMessageUpwards("PlayerRunAway");
        }
    }
}
