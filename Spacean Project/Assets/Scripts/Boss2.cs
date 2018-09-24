using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour {

    public bool damaged = false;
    public string color;
    public Light l;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(color))
        {
            l.intensity = 0f;
            damaged = true;
        }
    }

}
