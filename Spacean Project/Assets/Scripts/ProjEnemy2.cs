using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjEnemy2 : MonoBehaviour {

    public Vector3 dir = Vector3.zero;
    public float speed;

    private void FixedUpdate()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    public void SetDir(Vector3 d)
    {
        dir = d;
    }

}
