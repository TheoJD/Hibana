using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    static GameManager _instance;
    [SerializeField] private int _numberOfTrees = 0;
    [SerializeField] private int _numberOfTreesBurned = 0;
    [SerializeField] private int _numberOfBeasts = 0;
    [SerializeField] private int _numberOfBeastsKilled = 0;
    [SerializeField] private const int _maxHealth = 100;
    [SerializeField] private int _currentHealth = _maxHealth;
    [SerializeField] private const int _maxLoads = 5;
    [SerializeField] private int _loads = 5;
    [SerializeField] private string _currentScene = "scene1";
    [SerializeField] private const string _playerTag = "Player";
    [SerializeField] private const string _treeTag = "Tree";
    [SerializeField] private const string _beastTag = "Enemy";
    [SerializeField] private const string _fireTag = "Fire";
    [SerializeField] private const string _groundTag = "Ground";
    private HUD _hud;

    void Awake ()
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

    static public GameManager GetInstance()
    {
        return _instance;
    }

    public void NewTree()
    {
        ++_numberOfTrees;
    }
	
    public void TreeBurned()
    {
        ++_numberOfTreesBurned;
        if (_hud != null)
            _hud._treeText.text = _numberOfTreesBurned.ToString();
    }

    public void NewBeast()
    {
        ++_numberOfBeasts;
    }

    public void BeastKilled()
    {
        ++_numberOfBeastsKilled;
        if (_hud != null)
            _hud._beastText.text = _numberOfBeastsKilled.ToString();
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        _hud._healthBar.fillAmount = (float)_currentHealth / (float)_maxHealth;
        if (_currentHealth <= 0)
        {
            Load();
        }
    }

    public void LoadMunition(int munitions)
    {
        _loads += munitions;
        if (_loads > _maxLoads)
        {
            _loads = _maxLoads;
        }
        else if (_loads < 0 )
        {
            _loads = 0;
        }
        if (_hud != null)
        {
            _hud._loadsBar.fillAmount = (float)_loads / (float)_maxLoads;
        }
    }

    public int getLoads()
    {
        return _loads;
    }

    public string GetCurrentScene()
    {
        return _currentScene;
    }

    public string GetPlayerTag()
    {
        return _playerTag;
    }

    public string GetTreeTag()
    {
        return _treeTag;
    }

    public string GetBeastTag()
    {
        return _beastTag;
    }

    public void SetHUD(HUD hud)
    {
        _hud = hud;
        if (_hud != null)
        {
            _hud._loadsBar.fillAmount = (float)_loads / (float)_maxLoads;
            _hud._healthBar.fillAmount = (float)_currentHealth / (float)_maxHealth;
            _hud._treeText.text = _numberOfTreesBurned.ToString();
            _hud._beastText.text = _numberOfBeastsKilled.ToString();
        }
    }

    public void SetHUDLoadWait(float amount)
    {
        _hud._loadsWait.fillAmount = amount;
    }

    public void Save(string scene)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.gd");
        Debug.Log("Arbres : " + _numberOfTrees);
        Debug.Log("Betes : " + _numberOfBeasts);
        PlayerData playerData = new PlayerData();
        playerData.numberOfTrees = _numberOfTrees;
        playerData.numberOfTreesBurned = _numberOfTreesBurned;
        playerData.numberOfBeasts = _numberOfBeasts;
        playerData.numberOfBeastsKilled = _numberOfBeastsKilled;
        playerData.currentHealth = _currentHealth;
        playerData.currentScene = scene;
        playerData.loads = _loads;

        bf.Serialize(file, playerData);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/gameInfo.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.gd", FileMode.Open);
            PlayerData playerData = (PlayerData)bf.Deserialize(file);
            if (playerData != null)
            {
                _numberOfTrees = playerData.numberOfTrees;
                _numberOfTreesBurned = playerData.numberOfTreesBurned;
                _numberOfBeasts = playerData.numberOfBeasts;
                _numberOfBeastsKilled = playerData.numberOfBeastsKilled;
                _currentHealth = playerData.currentHealth;
                _currentScene = playerData.currentScene;
                _loads = playerData.loads;
            }
            SetHUD(_hud);
            SceneManager.LoadScene(_currentScene);
        }
    }
}

[System.Serializable]
class PlayerData
{
    public int numberOfTrees;
    public int numberOfTreesBurned;
    public int numberOfBeasts;
    public int numberOfBeastsKilled;
    public int currentHealth;
    public string currentScene;
    public int loads;
}