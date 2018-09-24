using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Transform mira;
    public float speed = 5f;
    public float rotSpeed = 3f;

	// Use this for initialization
	void Start () {
        mira = GameObject.Find("Mira").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerV2.isDead)
            return;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.gameObject.transform.position += new Vector3(mira.position.x - this.gameObject.transform.position.x, 
                mira.position.y - this.gameObject.transform.position.y, 0).normalized * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.gameObject.transform.position += new Vector3(mira.position.x - this.gameObject.transform.position.x,
                mira.position.y - this.gameObject.transform.position.y, 0).normalized * Time.deltaTime * -0.5f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, 0, 75) * Time.deltaTime * rotSpeed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 0, -75) * Time.deltaTime * rotSpeed);
        }
        Move();
	}

    private void Move()
    {
        
    }
}
