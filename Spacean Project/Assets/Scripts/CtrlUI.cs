using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CtrlUI : MonoBehaviour {

	public Text scoreText;
	public Text comboText;

	public static float score = 0;
	public static int combo = 0;

	public void ChangeScore()
	{
		scoreText.text = "" + score;
	}

	public void ChangeCombo()
	{
		comboText.text = "" + combo;
	}

	void Update()
	{
		scoreText.text = "" + score;
        if (combo <= 0)
            comboText.text = "";
        else
            comboText.text = "" + combo;
	}

}
