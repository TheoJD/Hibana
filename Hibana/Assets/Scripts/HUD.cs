using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    static HUD _instance;
    public Image _healthBar;
    public Text _beastText;
    public Text _treeText;
    void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        GameManager.GetInstance().SetHUD(this);
    }
}
