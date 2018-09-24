using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MENU : MonoBehaviour
{
    private bool bbb = false;

    // Use this for initialization
    void Start()
    {
        bbb = false;
        Invoke("aaa", 3f);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && bbb)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void aaa()
    {
        bbb = true;
    }
}