using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] float spawnDelay = 5f;
    [SerializeField] EnemyMovement enemyPrefab;


	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnEnemies());
	}
	
	IEnumerator SpawnEnemies()
    {
        while (true) // forever
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }    
    }
}
