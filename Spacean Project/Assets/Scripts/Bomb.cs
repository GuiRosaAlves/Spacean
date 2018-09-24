using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Bomb : MonoBehaviour {

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
		Destroy (gameObject, 8f);
        player = GameObject.Find("Player");
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

	void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.gameObject.tag.Equals ("Player")) {
			Destroy (gameObject);
			print ("tomou");
		}
	}

}
