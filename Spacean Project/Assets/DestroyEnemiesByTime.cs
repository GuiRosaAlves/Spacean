using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemiesByTime : MonoBehaviour {

    public GameObject player;

    public float timetoRun = 8f;

    public Vector3 dir;

    private Rigidbody2D rb;

    private float distance;

    // Use this for initialization
    void Start () {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        Invoke("RunToDeath", timetoRun);
        player = GameObject.FindWithTag("Player");
    }

    void RunToDeath()
    {
        //dir = new Vector3(player.transform.position.x + this.gameObject.transform.position.x, 
        //    player.transform.position.y + this.gameObject.transform.position.y, 0).normalized;
        distance = Vector2.Distance(transform.position, player.transform.position);
        dir = transform.right * -1;

        if (distance > 12)
            rb.AddForce(dir * 15, ForceMode2D.Impulse);
        Invoke("RunToDeath", 1f);
    }

}
