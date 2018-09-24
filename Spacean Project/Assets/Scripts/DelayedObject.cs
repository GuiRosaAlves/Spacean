using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedObject : MonoBehaviour {

    [SerializeField]
    private float speed = 2f;
    private GameObject player;

	void Start () {
        player = GameObject.Find("Player");
	}
	
	void FixedUpdate () {
        if (!PlayerV2.isDead)
        {
            this.gameObject.transform.position += new Vector3(player.transform.position.x -
                this.transform.position.x, player.transform.position.y - this.transform.position.y) * Time.deltaTime * speed;
        }
    }
}
