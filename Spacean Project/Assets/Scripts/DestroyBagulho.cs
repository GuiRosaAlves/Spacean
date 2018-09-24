using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBagulho : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag.Equals("Wall")) {
            Destroy(gameObject);
        }
        
    }
}
