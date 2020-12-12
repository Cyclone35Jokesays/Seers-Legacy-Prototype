using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance = null;

    internal Transform Transform()
    {
        throw new NotImplementedException();
    }

    public GameObject player;
    public Vector2 lastCheckPointPos;
    public string sectionName;
    public List<Vector2> coordinates = new List<Vector2>();
    
    public void LoadData()
    {
        sectionName = PlayerPrefs.GetString("SectionName");
        lastCheckPointPos = new Vector2(PlayerPrefs.GetFloat("Player PositionX"), PlayerPrefs.GetFloat("Player PositionY"));
        if (sectionName != "")
        {
            LoadScene();
        }

        else
        {
            Debug.Log("no Save File");
        }
    }

    public void LoadScene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(loading());
    }

    public void WhipeData()
    {
        PlayerPrefs.DeleteAll();
    }

    IEnumerator loading()
    {
        yield return new WaitForSeconds(1f);
        PlayerController myPlayer = player.GetComponent<PlayerController>();
        Health playerHealth = player.GetComponent<Health>();
        Debug.Log(sectionName);
        myPlayer.extraJumpValue = PlayerPrefs.GetInt("doublejumpPOWERUP", 0);
        myPlayer.LightObject.GetComponent<Light2D>().enabled = intToBool(PlayerPrefs.GetInt("flashlightPOWERUP", 0));
        myPlayer.solidHollowObject.turnSolid = intToBool(PlayerPrefs.GetInt("SolidHollowPOWERUP", 0));
        myPlayer.blaster.trip = intToBool(PlayerPrefs.GetInt("triplepowerupPOWERUP", 0));
        playerHealth.numOfHearts = PlayerPrefs.GetInt("healthPickup", 0);

        SceneManager.LoadSceneAsync(sectionName);
        player.transform.position = lastCheckPointPos;
    }

    

    public bool intToBool(int change)
    {
        if (change == 1)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public void SaveData(int doubleJump,bool  flashLight, bool solidHollow,bool triplePowerup, int healthPickups)
    {
        PlayerPrefs.SetInt("healthPickup", healthPickups);
        PlayerPrefs.SetString("SectionName", sectionName);
        PlayerPrefs.SetFloat("Player PositionX", lastCheckPointPos.x);
        PlayerPrefs.SetFloat("Player PositionY", lastCheckPointPos.y);
        PlayerPrefs.SetInt("doublejumpPOWERUP", doubleJump);
        PlayerPrefs.SetInt("flashlightPOWERUP", flashLight ? 1 : 0);
        PlayerPrefs.SetInt("SolidHollowPOWERUP", solidHollow ? 1 : 0);
        PlayerPrefs.SetInt("triplepowerupPOWERUP", triplePowerup ? 1 : 0);
    }


    Dictionary<int, List<GameObject>> _powerUpsByLevel = new Dictionary<int, List<GameObject>>();

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    public List<GameObject> GetLevelPowerUpsRemaining(int levelIndex)
    {
        List<GameObject> results = null;
        if(_powerUpsByLevel.TryGetValue(levelIndex, out results) == false)
        {
            Debug.Log($"Powerups for level {levelIndex} not set yet");
        }
        return results;
    }

    public void SetPowerUpsRemaining(int levelIndex, List<GameObject> powerUps)
    {
        if (_powerUpsByLevel.ContainsKey(levelIndex) == false)
        {
            _powerUpsByLevel.Add(levelIndex, powerUps);
        }
        else
        {
            _powerUpsByLevel[levelIndex] = powerUps;
        }

        // Prevent destroy on scene change.
        foreach(var powerUp in powerUps) 
        {
            powerUp.transform.SetParent(this.gameObject.transform);
        }
    }
}
