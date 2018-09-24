using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour {
	
	public enum States
	{
		walking,
		attacking,
		doidao,
		chase
	};

    public Boss2 red;
    public Boss2 green;
    public Boss2 blue;
    Animator anim;

	GameObject wps;
	public float speedRotWalk = 200f;
	public float speedRotAtk = 60f;
	public float speed = 5f;
	public List<Transform> waypoints = new List<Transform> ();
	public States state;
	float timer = 0f;
	float randTime;
	int rand;
	int counter = 0;
	public float minDist = 2f;
	Vector3 dir;
	float timerAtk = 0f;
	public GameObject[] shoots;
	public Transform[] shootSpawn;
	float dist;
	GameObject player;
	bool done = false;

	void Start()
	{
        anim = GetComponent<Animator>();
		Spawner.bossAlive = true;
		player = GameObject.FindWithTag ("Player");
		wps = GameObject.FindWithTag ("Waypoints");
		waypoints = wps.GetComponent<Waypoints> ().wpBoss;
		rand = -1;
		randTime = 5f;
		state = States.chase;
	}

	void Update()
	{
        if(red.damaged && green.damaged && blue.damaged)
        {
            AudioSource.PlayClipAtPoint(Sounds.Instance.explosion, Vector3.zero);
            Destroy(gameObject);
        }

		timer += Time.deltaTime;

		dist = Vector2.Distance (transform.position, player.transform.position);

		if (dist > 17f) {
			state = States.chase;
		} else {
			if (done) {
				if (rand < 2) {
					state = States.walking;
					randTime = Random.Range (2f, 3f);
				}
				if (rand >= 2 && rand < 6) {
					state = States.attacking;
					randTime = Random.Range (2f, 5f);
				}
				if (rand >= 6 && rand < 8) {
					state = States.doidao;
					randTime = Random.Range (2f, 3f);
				}
			}
		}

		switch (state) {
		case States.walking:
                anim.SetBool("Encolher", false);
			dir = Vector3.zero;
			transform.Rotate (Vector3.forward * speedRotWalk * Time.deltaTime);
			dir = waypoints [counter].position - transform.position;
			if (dir.magnitude < minDist) {
				if (counter < waypoints.Count - 1)
					counter++;
				else
					counter = 0;
			}
			dir = dir.normalized;
			transform.position += dir * speed * Time.deltaTime;

			if (timer > randTime) {
				timer = 0f;
				rand = Random.Range (0, 8);
				break;
			}
			break;

		case States.attacking:
                anim.SetBool("Encolher", true);
			transform.Rotate (Vector3.forward * speedRotAtk * Time.deltaTime);
			timerAtk += Time.deltaTime;
			if (timerAtk > 0.95f) {
				timerAtk = 0f;
                    AudioSource.PlayClipAtPoint(Sounds.Instance.bossShoot, Vector3.zero);
                    if (!red.damaged)
                {
                    GameObject s = Instantiate(shoots[0], shootSpawn[0].position, Quaternion.identity) as GameObject;
                    Vector3 dirRot = shootSpawn[0].transform.position - transform.position;
                    float angleRot = Mathf.Atan2(dirRot.y, dirRot.x) * Mathf.Rad2Deg;
                    s.transform.rotation = Quaternion.AngleAxis(angleRot, Vector3.forward);
                    s.GetComponent<Rigidbody2D>().AddForce(dirRot.normalized * 10f, ForceMode2D.Impulse);
                }
                if (!green.damaged)
                {
                    GameObject s = Instantiate(shoots[1], shootSpawn[1].position, Quaternion.identity) as GameObject;
                    Vector3 dirRot = shootSpawn[1].transform.position - transform.position;
                    float angleRot = Mathf.Atan2(dirRot.y, dirRot.x) * Mathf.Rad2Deg;
                    s.transform.rotation = Quaternion.AngleAxis(angleRot, Vector3.forward);
                    s.GetComponent<Rigidbody2D>().AddForce(dirRot.normalized * 10f, ForceMode2D.Impulse);
                }
                if (!blue.damaged)
                {
                    GameObject s = Instantiate(shoots[2], shootSpawn[2].position, Quaternion.identity) as GameObject;
                    Vector3 dirRot = shootSpawn[2].transform.position - transform.position;
                    float angleRot = Mathf.Atan2(dirRot.y, dirRot.x) * Mathf.Rad2Deg;
                    s.transform.rotation = Quaternion.AngleAxis(angleRot, Vector3.forward);
                    s.GetComponent<Rigidbody2D>().AddForce(dirRot.normalized * 10f, ForceMode2D.Impulse);
                }
                /*
                for (int i = 0; i < shoots.Length; i++) {
                    GameObject s = Instantiate (shoots [i], shootSpawn [i].position, Quaternion.identity) as GameObject;
                    Vector3 dirRot = shootSpawn[i].transform.position - transform.position;
                    float angleRot = Mathf.Atan2 (dirRot.y, dirRot.x) * Mathf.Rad2Deg;
                    s.transform.rotation = Quaternion.AngleAxis (angleRot, Vector3.forward);
                    s.GetComponent<Rigidbody2D> ().AddForce (dirRot.normalized * 10f, ForceMode2D.Impulse);
                }
                */
            }
			if (timer > randTime) {
				timerAtk = 0f;
				timer = 0f;
				rand = Random.Range (0, 8);
				break;
			}
			break;

		case States.doidao:
                anim.SetBool("Encolher", true);
                dir = Vector3.zero;
			transform.Rotate (Vector3.forward * speedRotWalk * 3 * Time.deltaTime);
			dir = waypoints [counter].position - transform.position;
			if (dir.magnitude < minDist) {
				if (counter < waypoints.Count - 1)
					counter++;
				else
					counter = 0;
			}
			dir = dir.normalized;
			transform.position += dir * speed * Time.deltaTime;

			timerAtk += Time.deltaTime;
			if (timerAtk > 0.3f) {
				timerAtk = 0f;
                    AudioSource.PlayClipAtPoint(Sounds.Instance.bossShoot, Vector3.zero);
                    if (!red.damaged)
                    {
                        GameObject s = Instantiate(shoots[0], shootSpawn[0].position, Quaternion.identity) as GameObject;
                        Vector3 dirRot = shootSpawn[0].transform.position - transform.position;
                        float angleRot = Mathf.Atan2(dirRot.y, dirRot.x) * Mathf.Rad2Deg;
                        s.transform.rotation = Quaternion.AngleAxis(angleRot, Vector3.forward);
                        s.GetComponent<Rigidbody2D>().AddForce(dirRot.normalized * 10f, ForceMode2D.Impulse);
                    }
                    if (!green.damaged)
                    {
                        GameObject s = Instantiate(shoots[1], shootSpawn[1].position, Quaternion.identity) as GameObject;
                        Vector3 dirRot = shootSpawn[1].transform.position - transform.position;
                        float angleRot = Mathf.Atan2(dirRot.y, dirRot.x) * Mathf.Rad2Deg;
                        s.transform.rotation = Quaternion.AngleAxis(angleRot, Vector3.forward);
                        s.GetComponent<Rigidbody2D>().AddForce(dirRot.normalized * 10f, ForceMode2D.Impulse);
                    }
                    if (!blue.damaged)
                    {
                        GameObject s = Instantiate(shoots[2], shootSpawn[2].position, Quaternion.identity) as GameObject;
                        Vector3 dirRot = shootSpawn[2].transform.position - transform.position;
                        float angleRot = Mathf.Atan2(dirRot.y, dirRot.x) * Mathf.Rad2Deg;
                        s.transform.rotation = Quaternion.AngleAxis(angleRot, Vector3.forward);
                        s.GetComponent<Rigidbody2D>().AddForce(dirRot.normalized * 10f, ForceMode2D.Impulse);
                    }
                }

			if (timer > randTime) {
				timerAtk = 0f;
				timer = 0f;
				rand = Random.Range (0, 8);
				break;
			}
			break;

		case States.chase:
                anim.SetBool("Encolher", false);
                done = false;
			Vector3 dirRotChase = player.transform.position - transform.position;
			float angleRotChase = Mathf.Atan2 (dirRotChase.y, dirRotChase.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (angleRotChase, Vector3.forward);
			transform.position = Vector2.MoveTowards (transform.position, player.transform.position, 10f * Time.deltaTime);

			if (dist <= 5f) {
				done = true;
				timerAtk = 0f;
				timer = 0f;
				rand = Random.Range (0, 8);
				break;
			}
			break;

		default:
			break;
		}
	}

	void OnDisable()
	{
		Spawner.bossAlive = false;
	}

}
