using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance = null;

    public GameObject player;
    public Vector2 lastCheckPointPos;
    public List<Vector2> coordinates = new List<Vector2>();

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
