using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cubeSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform[] spawnerManager;
    public float spawnTime;
    private float timer;
    
    public int cubeNumberToWin;
    private int cubeNumberSpawned = 0;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = cubeNumberSpawned.ToString() + " / " + cubeNumberToWin;
        timer += Time.deltaTime;
        
        if (cubeNumberSpawned >= cubeNumberToWin)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (timer >= spawnTime)
        {
            cubeNumberSpawned++;
            int randomized = UnityEngine.Random.Range(0, spawnerManager.Length - 1);
            Vector2 pos = spawnerManager[randomized].transform.position;
            Instantiate(prefab, pos, Quaternion.identity);
            timer = 0;
        }
    }
}
