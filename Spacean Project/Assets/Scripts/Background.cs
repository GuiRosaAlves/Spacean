using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    
    SpriteRenderer sr;
    Vector2 offset = Vector2.zero;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        offset.x += Input.GetAxisRaw("Horizontal");
        offset.y += Input.GetAxisRaw("Vertical");
        sr.material.mainTextureOffset = offset * 0.001f;
    }

}
