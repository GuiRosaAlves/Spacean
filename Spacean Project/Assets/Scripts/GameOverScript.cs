using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

	public GameObject GameOver;
	public GameObject TextGO;
	public string[] sentence;
	public Text textObj;
    private bool gameEnd = true;

    private bool bbb = false;

	// Use this for initialization
	void Start () {
        bbb = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerV2.isDead) {
            if (gameEnd)
            {
                GameOver.SetActive(true);
                TextGO.SetActive(true);
                textObj.text = sentence[Random.Range(0, sentence.Length)];
                gameEnd = false;
            }
            if (gameEnd == false)
            {
                Invoke("aaa", 3f);

            }
            if (Input.anyKey && bbb)
            {
                SceneManager.LoadScene(0);
            }

        }
	}

    public void aaa() {
        bbb = true;
    }
}
