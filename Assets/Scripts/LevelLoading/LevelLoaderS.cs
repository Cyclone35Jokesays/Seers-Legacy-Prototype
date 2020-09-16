using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelLoaderS : MonoBehaviour
{
    [SerializeField] private int LevelIndex = 0;
    public Animator transition;
    private float transitionTime = 0.2f;

    [Serializable]
    public class LevelPowerupData
    {
        public GameObject powerUpPrefab = null;
        public Vector2 spawnLocation = Vector2.zero;
    }
    public List<LevelPowerupData> levelPowerUps = new List<LevelPowerupData>();

    private List<GameObject> spawnedPowerUps = new List<GameObject>();

    private void Awake()
    {
        Debug.Log($"Loading Level {LevelIndex}");

        // Get the power ups remaining from the GameManager
        // If the list is null then we haven't loaded this level yet
        var powerUpsRemaining = GameManager.Instance.GetLevelPowerUpsRemaining(LevelIndex);
        if (powerUpsRemaining == null)
        {
            Debug.Log($"Loading All Powerups for Level {LevelIndex}");
            foreach (var powerUp in levelPowerUps)
            {
                var loc = powerUp.spawnLocation;
                var pu = Instantiate(powerUp.powerUpPrefab, new Vector3(loc.x, loc.y, 0.0f), Quaternion.identity);
                spawnedPowerUps.Add(pu);
                ICollectible collectible = pu.GetComponent<ICollectible>();

                if (collectible != null)
                {
                    collectible.OnCollected += OnPowerUpCollected;
                }
            }
            GameManager.Instance.SetPowerUpsRemaining(LevelIndex, spawnedPowerUps);
        }
        else if (powerUpsRemaining.Count <= 0)
        {
            // All power ups have been collected
            Debug.Log("All power ups for level {LevelIndex} have been collected");
        }
        else
        {
            Debug.Log($"Loading Remaining Powerups for Level {LevelIndex}");
            foreach (var powerUp in powerUpsRemaining)
            {
                if (powerUp != null)
                {
                    powerUp.SetActive(true);
                }
            }
        }
    }

    private void OnDisable()
    {
        foreach (var powerUp in spawnedPowerUps)
        {
            if (powerUp != null)
            {
                powerUp.SetActive(false);
            }
        }
    }

    private void OnPowerUpCollected(GameObject obj)
    {
        int instanceId = obj.GetInstanceID();
        Debug.Log($"PowerUp Collected. GO Id: {obj.GetInstanceID()}");
        for (int i = spawnedPowerUps.Count - 1; i >= 0; i--)
        {
            if (spawnedPowerUps[i].GetInstanceID() == instanceId)
            {
                Debug.Log($"Remvoing PowerUp {obj.name}");
                spawnedPowerUps.RemoveAt(i);
            }
        }
        GameManager.Instance.SetPowerUpsRemaining(LevelIndex, spawnedPowerUps);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 2));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
