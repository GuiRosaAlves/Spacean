using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour {

	private static Sounds instance;
	public AudioClip explosion;
	public AudioClip shoot;
	public AudioClip explosion2;
	public AudioClip bossShoot;
	public AudioClip click;
	public AudioClip gameOver;
	//public AudioClip bonus;

	public static Sounds Instance { get { return instance; } }

	private void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
		} else {
			instance = this;
		}
	}

}
