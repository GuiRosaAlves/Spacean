using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Projectile : MonoBehaviour {

    [SerializeField]
    private float bulletSpeed = 10f;
    public Transform player;
    public Transform mira;
    public float tempoDeVida = 2.2f;
    Vector3 direcao;

    void OnAwake()
    {
        this.GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    void Start () {
        player = GameObject.Find("Player").GetComponent<Transform>();
        mira = GameObject.Find("Mira").GetComponent<Transform>();

        direcao = new Vector3(mira.position.x - player.position.x, mira.position.y - player.position.y, 0);
        Invoke("AutoDestruir", tempoDeVida);
    }

    void FixedUpdate () {
        this.gameObject.transform.localPosition += direcao * bulletSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("WallProj"))
            Destroy(gameObject);

        if (coll.gameObject.tag == "green" && this.gameObject.tag == "green")
        {
            Destroy(coll.gameObject);
            //Destroy(this.gameObject);
        }

        if(coll.gameObject.tag == "red" && this.gameObject.tag == "red")
        {
            Destroy(coll.gameObject);
            //Destroy(this.gameObject);
        }

        if(coll.gameObject.tag == "blue" && this.gameObject.tag == "blue")
        {
            Destroy(coll.gameObject);
            //Destroy(this.gameObject);
        }

        if (coll.gameObject.tag == "Destroy")
        {
            Destroy(this.gameObject);
        }

        if (coll.GetComponent<Projectile>())
        {
            //DO ANY COOL EFFECTS IN CASE A BULLET DESTROY A BULLET
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }

    private void AutoDestruir()
    {
        Destroy(this.gameObject);
    }
}
