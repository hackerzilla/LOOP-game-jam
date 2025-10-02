using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region EnemyVariables
    public EnemyData[] allEnemies;
    [SerializeField] public int enemiesPerWave = 5;
    #endregion

    #region GameState
    int score = 0;
    [SerializeField] public int totalWaves = 1;
    private int currentWave = 1;
    [SerializeField] public Text gameover;
    #endregion
    
    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
        gameover.text = "Your final score is" + score;
    }
}
