using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] itemPrefab;

    
    private float spawnRange = 3.5f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    public static int score = 0;
    public float targetTime = 60.0f;
    
   
   
    // Start is called before the first frame update
    void Start()
    {
      InvokeRepeating("SpawnRandomItem", 2.0f, 2.0f);
      score = 0;
      UpdateScore(0);

    }

     public void UpdateScore(int scoreToAdd)
     {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
     }






     private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 10, spawnPosZ);

        return randomPos;
    }

    void SpawnRandomItem()
    {
        int itemIndex = Random.Range(0, itemPrefab.Length);
        Instantiate(itemPrefab[itemIndex], GenerateSpawnPosition(), itemPrefab[itemIndex].transform.rotation);

    }

    


    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
        timerText.text = "Time: " + targetTime.ToString();

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }

    }

    void timerEnded()
    {
    
        SceneManager.LoadScene("GameOver");
    }
}
