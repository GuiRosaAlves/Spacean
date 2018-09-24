using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScreen : MonoBehaviour {

    public Camera cam;
    public static float shake = 0f;
    [SerializeField]
    private float decreaseFactor = 1f;
    public float yshake = 0.1f;
    public float xshake = 0.1f;
    private GameObject player;


    void OnAwake()
    {
        shake = 0f;
    }

    // Use this for initialization
    void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (shake > 0)
        {
            cam.transform.localPosition = new Vector3(Random.Range(-xshake, xshake),Random.Range(-yshake, yshake), -10);
            shake -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shake = 0.0f;
        }
	}
}
