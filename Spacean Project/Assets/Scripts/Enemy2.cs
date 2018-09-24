using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour {

	GameObject wps;
	public List<Transform> waypoints = new List<Transform>();
	public float minSpeed, maxSpeed;
	float speed;
	Vector3 target;
	Vector3 dir;
	float angleRot;
	Rigidbody2D rb;
	public float whenAddForce = 1f;


	void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
		wps = GameObject.FindWithTag ("Waypoints");
		waypoints = wps.GetComponent<Waypoints> ().wpEnemies;
		speed = Random.Range (minSpeed, maxSpeed);
		target = waypoints [Random.Range (0, waypoints.Count)].position;
		dir = target - transform.position;
		dir = dir.normalized;
		angleRot = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angleRot, Vector3.forward);
	}

	void Update()
	{
		if (rb.velocity.magnitude < whenAddForce) {
			rb.AddForce (dir * speed, ForceMode2D.Impulse);
		}
	}


}
