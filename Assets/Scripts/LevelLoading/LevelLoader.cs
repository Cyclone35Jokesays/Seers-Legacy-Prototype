using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    private float transitionTime = 0.6f;

    private GameMaster gm;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
       // StartCoroutine("ReloadLevel");
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
        yield return new WaitForSeconds(transitionTime + 0.3f);
        transform.position = gm.lastCheckPointPos;
    }

   /* IEnumerator ReloadLevel(bool setLoad)
    {
        yield return new WaitForSeconds(transitionTime + 0.7f);
        setLoad = false;
        transform.position = gm.lastCheckPointPos;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        setLoad = true;
    } */
}
