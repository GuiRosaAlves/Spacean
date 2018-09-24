using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class ProjEnemy : MonoBehaviour
{
    public static int cor;

    [SerializeField]
    private float bulletSpeed = 10f;
    public static GameObject go;
    public Transform enemy;
    public Transform mira;
    Vector3 direcao;
    public float tempoDevida = 2.2f;

    /*
    void OnAwake()
    {
        this.GetComponent<Rigidbody2D>().freezeRotation = true;
    }
    */

    void Start()
    {
        foreach (Transform t in go.GetComponentInChildren<Transform>())
        {
            if (t.name == "EnemyToShot")
                enemy = t;
        }

        mira = GameObject.Find("Crosshair").GetComponent<Transform>();
        //transform.rotation = enemy.rotation;
        direcao = new Vector3(mira.position.x - enemy.position.x, mira.position.y - enemy.position.y, 0);
        direcao.Normalize();
        Invoke("AutoDestruir", tempoDevida);
    }

    void FixedUpdate()
    {
        this.gameObject.transform.localPosition += direcao * bulletSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "green" && this.gameObject.tag == "ProjGreen")
        {
            if (coll.gameObject.name == "Projectile")
            {
                //DO ANY COOL EFFECTS IN CASE A BULLET DESTROY A BULLET
            }
            
            Destroy(coll.gameObject);
            Destroy(this.gameObject);
        }

        if (coll.gameObject.tag == "red" && this.gameObject.tag == "ProjRed")
        {
            if (coll.gameObject.name == "Projectile")
            {
                //DO ANY COOL EFFECTS IN CASE A BULLET DESTROY A BULLET
            }
            print(coll.name);
            Destroy(coll.gameObject);
            Destroy(this.gameObject);
        }

        if (coll.gameObject.tag == "blue" && this.gameObject.tag == "ProjBlue")
        {
            if (coll.gameObject.name == "Projectile")
            {
                //DO ANY COOL EFFECTS IN CASE A BULLET DESTROY A BULLET
            }

            Destroy(coll.gameObject);
            Destroy(this.gameObject);
        }

        if (coll.gameObject.tag == "Destroy")
        {
            Destroy(this.gameObject);
        }
    }

    private void AutoDestruir()
    {
        Destroy(this.gameObject);
    }
}
