using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public GameObject scoreText;
    public int theScore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        theScore += 1;
        scoreText.GetComponent<Text>().text = "SCORE: " + theScore;
        Destroy(gameObject);
    }

}
