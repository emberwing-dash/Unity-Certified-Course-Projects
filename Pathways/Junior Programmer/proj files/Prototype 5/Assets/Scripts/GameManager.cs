
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public bool isGameActive;

    private float spawnRate = 1f;

    int score;
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI gameOverText;

    public Button restartButton;

    void Start()
    {
        isGameActive = true;

        StartCoroutine(SpawnTarget());
        score = 0;
        scoreTxt.text = "Score: " + score;
    }

    // Update is called once per frame
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreTxt.text = "Score: " + score;
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {

            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
