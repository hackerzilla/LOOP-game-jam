using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region PlayerVariables
    //[SerializeField] public int numberOfTries = 5;
    #endregion

    #region EnemyVariables
    public EnemyData[] allEnemies;
    [SerializeField] public int enemiesPerWave = 5;
    #endregion

    #region GameState
    //int score = 0;
    private int currentWave = 0;
    [SerializeField] public Text textDisplayed;
    private bool waveInProgress = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //Assert.IsTrue(SaveManager.Instance.numberOfTries >= enemiesPerWave, "Number of tries must be at least the number of enemies!");
        StartCoroutine(StartNextWave());
    }

    IEnumerator StartNextWave()
    {
        waveInProgress = true;

        currentWave += 1;
        textDisplayed.text = "Wave: " + currentWave;
        textDisplayed.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        textDisplayed.gameObject.SetActive(false);

        SpawnEnemies(allEnemies, enemiesPerWave);

        waveInProgress = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!waveInProgress && FindObjectsOfType<Enemy>().Length == 0)
        {
            StartCoroutine(StartNextWave());
        }

        if (Input.GetKeyDown(KeyCode.R) && SaveManager.Instance.numberOfTries > 0)
        {
            SaveManager.Instance.numberOfTries--;
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void SpawnEnemies(EnemyData[] allEnemies, int enemiesPerWave)
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            int enemyIndex = Random.Range(0, allEnemies.Length);
            if (allEnemies[enemyIndex] != null)
            {
                Instantiate(allEnemies[enemyIndex].prefab);
            }
        }
    }

    public void GameOver()
    {
        textDisplayed.text = "Final Score: " + SaveManager.Instance.score;
    }



    public void AddScore()
    {
        SaveManager.Instance.score += 1;
        Debug.Log("Current Score: " + SaveManager.Instance.score);
    }
}

