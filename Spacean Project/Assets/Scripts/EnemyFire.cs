using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour {

    public Transform mira;
    GameObject p;

    public float suaveMaxDist;
    bool firing = false;

    Vector3 dirRot;
    float angleRot;

    [SerializeField]
    private float maxDistance;
    private float distanceToPlayer;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float fireRate = 5f;
    private float lastShot = 0f;

    //REFERENCES OF OBJECTS
    private GameObject player;
    public Transform crosshair;
    public GameObject bullet;
    /*
    [SerializeField]
    private GameObject redBullet;
    [SerializeField]
    private GameObject blueBullet;
    [SerializeField]
    private GameObject greenBullet;
    */

    // Use this for initialization
    void Start () {
        p = GameObject.FindWithTag("Player");
        player = GameObject.Find("Delayed Player");
        crosshair = GameObject.Find("Crosshair").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (PlayerV2.isDead)
            return;
        Move();
	}

    private void Move()
    {
        /*
        dirRot = player.transform.position - transform.position;
		angleRot = Mathf.Atan2 (dirRot.y, dirRot.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angleRot, Vector3.forward);
         */

        distanceToPlayer = Vector2.Distance(this.transform.position, player.transform.position);

        Vector3 diff = player.transform.position - this.transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90f);

        if (firing)
        {
            if (distanceToPlayer > suaveMaxDist)
            {
                firing = false;
                this.gameObject.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
            else
            {
                Fire();
            }
            return;
        }

        if (distanceToPlayer > maxDistance)
        {
            fireRate = 2;
            this.gameObject.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            firing = true;
            Fire();
        }
    }

    private void LateUpdate()
    {
        //transform.position = new Vector3(transform.position.x + 0.81f, transform.position.y, 0);
    }

    private void Fire()
    {
        if (Time.time > fireRate + lastShot)
        {
            /*
            if (this.gameObject.tag == "red")
            {
                Instantiate(redBullet, crosshair.position, gameObject.transform.rotation);
            }
            if (this.gameObject.tag == "blue")
            {
                Instantiate(blueBullet, crosshair.position, gameObject.transform.rotation);
            }
            if (this.gameObject.tag == "green")
            {
                Instantiate(greenBullet, crosshair.position, gameObject.transform.rotation);
            }
            */
            AudioSource.PlayClipAtPoint(Sounds.Instance.bossShoot, Vector3.zero);
            GameObject g = Instantiate(bullet, crosshair.position, gameObject.transform.rotation) as GameObject;
            Vector3 direcao = new Vector3(p.transform.position.x - mira.position.x,
                p.transform.position.y - mira.position.y, 0).normalized;
            g.GetComponent<ProjEnemy2>().SetDir(direcao);
            lastShot = Time.time;
        }
    }
}
