using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour {

    // [Header("Fading In & Out")]
    public Texture2D blackTexture;
    public const float fadeSpeed = 0.1f;

    private float actualSpeed = fadeSpeed;
    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = 0;               // direction to fade : in = -1, out = 1


    public float Fade(int direction, float speed = fadeSpeed)
    {
        fadeDir = direction;
        actualSpeed = speed;
        return (speed);
    }


    void OnGUI()
    {
        // Debug.Log("braou");
        alpha += fadeDir * actualSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackTexture);
    }
}
