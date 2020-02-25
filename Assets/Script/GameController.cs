using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float startDelay; //Start game prep
    public float enemyDelay; //How long between each shark spawn
    public float waveDelay; //How long between each wave

    public int sharksInWave; //# of sharks in each wave
    public int waveNumber; //How many waves before boss
    public int waveMulti; //Stores a number to multiply the next wave by
    int totalWave; //Takes the total # of sharks after its multiplied

    public GameObject[] enemyPrefabs;
    public GameObject[] potionPrefabs;

    public float potionDelay;
    public int potionNumber;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PotionSpawn());
        StartCoroutine(WaveSpawner());
    }

        IEnumerator WaveSpawner()
        {

            yield return new WaitForSeconds(startDelay);
            while (waveNumber > 0) //Spawn a Wave as long as Number of waves is > 0
            {
                //Adds more sharks per wave
                totalWave = waveMulti * sharksInWave;
                sharksInWave = totalWave;

                for (int i = 0; i < totalWave; i++)
                {
                    Vector2 spawnPosition = new Vector2(6, Random.Range(-1, -4)); //Spawns sharks on the right side of the screen Y-axis
                    Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], spawnPosition, Quaternion.identity);
                    yield return new WaitForSeconds(enemyDelay);
                }
                yield return new WaitForSeconds(waveDelay);
                waveNumber--;
            }
            Debug.Log("Boss");
            SceneManager.LoadScene("Boss_Scene");
        }

        IEnumerator PotionSpawn()
        {
            yield return new WaitForSeconds(potionDelay);
            while (potionNumber > 0) //Spawn a Wave as long as Number of waves is > 0
            {

                for (int i = 0; i < potionNumber; i++)
                {
                    Vector2 spawnPosition = new Vector2(6, Random.Range(-1, -4)); //Spawns sharks on the right side of the screen Y-axis
                    Instantiate(potionPrefabs[Random.Range(0, potionPrefabs.Length)], spawnPosition, Quaternion.identity);
                    yield return new WaitForSeconds(potionDelay);
                    potionNumber--;
                }

            }
        }
}
