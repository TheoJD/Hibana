using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour {

    // [Header("Fading In & Out")]
    public Texture2D Texture;
    public const float fadeSpeed = 0.25f;

    private float actualSpeed = fadeSpeed;
    private int drawDepth = -1000;
    private float alpha = 1.0f;
    //private float volume = 0.0f;
    private int fadeDir = 0;               // direction to fade : in = -1, out = 1
    /*[SerializeField] private AudioClip _introOutroMusic;
    [SerializeField] private AudioClip _sceneMusic;
    private AudioSource _audioSource;*/

    /*public void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }*/

    public float Fade(int direction, float speed = fadeSpeed)
    {
        /*if (GameManager.GetInstance().GetCurrentScene() == "introduction" || GameManager.GetInstance().GetCurrentScene() == "final")
            _audioSource.clip = _introOutroMusic;
        else if (GameManager.GetInstance().GetCurrentScene().Contains("scene"))
            _audioSource.clip = _sceneMusic;
        else
            _audioSource.clip = null;*/
        fadeDir = direction;
        actualSpeed = speed;
        return (speed);
    }


    void OnGUI()
    {
        float fadeValue = fadeDir * actualSpeed * Time.deltaTime;
        alpha += fadeValue;
        //volume -= fadeValue;
        alpha = Mathf.Clamp01(alpha);
        //volume = Mathf.Clamp01(volume);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Texture);
    }
}
