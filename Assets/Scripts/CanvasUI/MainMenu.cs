using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
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
}
