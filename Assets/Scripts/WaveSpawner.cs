using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public static int EnemiesAlive = 0;
    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 3f;
    private float countdown = 2f;

    public Text waveCountdownText;
    public Text levelCompleteText;

    void Update()
    {
        waveCountdownText.text = EnemiesAlive.ToString();

        if (EnemiesAlive > 0)
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            levelCompleteText.enabled = false;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        if (PlayerStats.Rounds > 1)
        {
            levelCompleteText.enabled = true;
        }
    }

    IEnumerator SpawnWave()
    {

        PlayerStats.Rounds++;

        Wave wave = waves[UnityEngine.Random.Range(0, waves.Length)];

        int enemyCount = wave.count + PlayerStats.Rounds;

        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }

}
