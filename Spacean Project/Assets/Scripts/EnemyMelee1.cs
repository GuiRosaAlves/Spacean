using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee1 : MonoBehaviour {

	public float speed = 3f;
	Vector3 dirRot;
	float angleRot;
	float x, y;

	//HANDLES SPIN MOVEMENT
	//private float distanceToPlayer;
	[SerializeField]
	private float maxDistance;

	//REFERENCES OF OBJECTS
	private GameObject player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void FixedUpdate()
	{
		Move ();
	}

	private void Move()
	{
		dirRot = player.transform.position - transform.position;
		angleRot = Mathf.Atan2 (dirRot.y, dirRot.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angleRot, Vector3.forward);

		//distanceToPlayer = Vector2.Distance(this.transform.position, player.transform.position);
		transform.position = Vector2.MoveTowards (transform.position, player.transform.position, speed * Time.deltaTime);
	}

}
