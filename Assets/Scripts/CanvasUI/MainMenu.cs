using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Cams;
    private Animator camAnimation;

    private void Start()
    {
        camAnimation = Cams.GetComponent<Animator>();
    }

    public void PlayGame()
    {
        camAnimation.SetBool("See", true);
        StartCoroutine(addCoroutine());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadGame()
    {
        GameManager.Instance.LoadData();
    }

    public void DeleteData()
    {
        GameManager.Instance.WhipeData();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator addCoroutine()
    {
        yield return new WaitForSeconds(2);
    }
}
