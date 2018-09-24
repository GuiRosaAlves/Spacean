using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlDifficulty : MonoBehaviour {

    GameObject player;
	public GameObject boss;
    public GameObject[] FireEnemy;
	public float cdBoss = 30f;
	public float timer;
	public float addTime = 5f;
    public float cdRanged = 15f;
	float baseTime = 10f;
	float timerBoss = 0f;
    float timerRanged = 0f;
    public float achouHard = 3f;

	void Start()
	{
		player = GameObject.FindWithTag ("Player");
	}

	void Update()
	{
		timer += Time.deltaTime;

        if (!Spawner.bossAlive)
            timerBoss += Time.deltaTime;

        if (!Spawner.rangedSpawned)
            timerRanged += Time.deltaTime;

		if (timer >= 5f && timer < 10f) {
			Spawner.canSpawn = true;
			Spawner.diff = achouHard;
		}

        if (timerRanged >= cdRanged && !Spawner.rangedSpawned)
        {
            Spawner.rangedSpawned = true;
            timerRanged = 0f;
            int nsei = Random.Range(0, 4);
            int cor = Random.Range(0, FireEnemy.Length);
            switch (nsei)
            {
                case 0:
                    ProjEnemy.go = Instantiate(FireEnemy[cor], new Vector3(player.transform.position.x,
    player.transform.position.y - 13, 0), Quaternion.identity) as GameObject;
                    break;
                case 1:
                    ProjEnemy.go = Instantiate(FireEnemy[cor], new Vector3(player.transform.position.x,
    player.transform.position.y + 13, 0), Quaternion.identity) as GameObject;
                    break;
                case 2:
                    ProjEnemy.go = Instantiate(FireEnemy[cor], new Vector3(player.transform.position.x - 17,
    player.transform.position.y, 0), Quaternion.identity) as GameObject;
                    break;
                case 3:
                    ProjEnemy.go = Instantiate(FireEnemy[cor], new Vector3(player.transform.position.x + 17,
    player.transform.position.y, 0), Quaternion.identity) as GameObject;
                    break;
                default:
                    break;
            }

        }

		if (timerBoss >= cdBoss && !Spawner.bossAlive) {
			timerBoss = 0f;
			Instantiate (boss, new Vector3 (player.transform.position.x, 
				player.transform.position.y + 13, 0), Quaternion.identity);
		}

		if (Spawner.diff <= 0.5f) {
			Spawner.diff = 0.5f;
			return;
		}

		if (timer >= baseTime + addTime) {
			baseTime += addTime;
			Spawner.diff -= 0.1f;
		}
	}

}
