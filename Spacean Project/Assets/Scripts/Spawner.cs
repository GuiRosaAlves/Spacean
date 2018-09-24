using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public static int numberEnemies;
	public static float diff;
	public static bool canSpawn;
	public static bool bossAlive;
    public static bool rangedSpawned = false;

    public GameObject[] batteries;
    public GameObject[] enemies;
	public GameObject bomb;

	public int maxNumberEnemies;
	public float minTime, maxTime;
	public float minX, maxX, minY, maxY;

	float timer;
	float rand;
	int spawn;

	void Start()
	{
		canSpawn = false;
		bossAlive = false;
		numberEnemies = 0;
		timer = 0f;
		rand = Random.Range (minTime, maxTime);
	}

	void Update()
	{
		timer += Time.deltaTime;
		if (timer > rand && numberEnemies < maxNumberEnemies && canSpawn) {
			spawn = Random.Range (0, enemies.Length);
			Instantiate (enemies [spawn], new Vector3 (
				Random.Range (transform.position.x + minX, transform.position.x + maxX),
				Random.Range (transform.position.y + minY, transform.position.y + maxY), 0f), 
				Quaternion.identity);
			if (Random.Range (0, 10) == 0) {
                Instantiate(batteries[Random.Range(0, batteries.Length)], transform.position, Quaternion.identity);
			}
			timer = 0f;
			if (!bossAlive)
				rand = Random.Range (minTime * diff, maxTime * diff);
			else
				rand = Random.Range (minTime * 7, maxTime * 7);
		}
	}

}
