using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Spawner : MonoBehaviour
{
    [SerializeField] private bool Level1Active;

    [Header("Power up functions")]
    [SerializeField] GameObject[] powerUps;
    [SerializeField] private float spawnMinSecPowerUps;
    [SerializeField] private float spawnMaxSecPowerUps;

    [Header("Level Objects to spawn")]
    [SerializeField] GameObject[] enemyObjects;
    [SerializeField] private float spawnMinSecEnemy;
    [SerializeField] private float spawnMaxSecEnemy;

    // Start is called before the first frame update
    void Start()
    {
        LevelActivate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LevelActivate()
    {
        Level1Active = true;
        StartCoroutine(PowerUps());
        StartCoroutine(EnemyStart());
    }

    IEnumerator PowerUps()
    {
        while (Level1Active)
        {
            int PowerUpRange = Random.Range(0, 3);
            float RandonOnX = Random.Range(-9, 9);
            Vector3 spawnLocation = new Vector3(RandonOnX, 9, 0);
            float RandomSec = Random.Range(spawnMinSecPowerUps, spawnMaxSecPowerUps);

            yield return new WaitForSeconds(RandomSec);

            Instantiate(powerUps[PowerUpRange], spawnLocation, Quaternion.identity);

            yield return new WaitForSeconds(0.5f);
        }

    }
    IEnumerator EnemyStart()
    {
        while (Level1Active)
        {
            int Enemy = Random.Range(0, 3);
            float RandonOnX = Random.Range(-9, 9);
            Vector3 spawnLocation = new Vector3(RandonOnX, 9, 0);
            float RandomSec = Random.Range(spawnMinSecEnemy, spawnMaxSecEnemy);

            yield return new WaitForSeconds(RandomSec);

            Instantiate(enemyObjects[Enemy], spawnLocation, Quaternion.identity);

            yield return new WaitForSeconds(0.5f);
        }

    }
}
