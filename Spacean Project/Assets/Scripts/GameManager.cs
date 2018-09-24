using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	static public int score;
	static public int combo;

	public PlayerV2 player;

    public Image combo1;
    public Image combo2;
    public Image combo3;
    public Image combo4;
    public Image combo5;

    public Image combo6;
    public Image combo7;
    public Image combo8;
    public Image combo9;
    public Image combo10;

    public Image combo11;
    public Image combo12;
    public Image combo13;
    public Image combo14;
    public Image combo15;

    public Image combo16;
    public Image combo17;
    public Image combo18;
    public Image combo19;
    public Image combo20;

    public Text combox2;
    public Text combox4;
    public Text combox8;
    public Text combox16;


    public float amountToIncrease = 0.08f; 

    // Use this for initialization
    void Start () {
		score = 0;
		combo = 0;
        player = GameObject.Find("Player").GetComponent<PlayerV2>();

        combo1 = GameObject.Find("Combo1").GetComponent<Image>();
        combo2 = GameObject.Find("Combo2").GetComponent<Image>();
        combo3 = GameObject.Find("Combo3").GetComponent<Image>();
        combo4 = GameObject.Find("Combo4").GetComponent<Image>();
        combo5 = GameObject.Find("Combo5").GetComponent<Image>();
        combo6 = GameObject.Find("Combo6").GetComponent<Image>();
        combo7 = GameObject.Find("Combo7").GetComponent<Image>();
        combo8 = GameObject.Find("Combo8").GetComponent<Image>();
        combo9 = GameObject.Find("Combo9").GetComponent<Image>();
        combo10 = GameObject.Find("Combo10").GetComponent<Image>();

    }

    void Update () {
		UpdateComboBar ();
		UpdateEnergyBar ();
	}

	static public void IncreaseScore(int points){
		if (combo < 6) {
			score += points;
		} else if (combo < 18) {
			score += points * 2;
		} else if (combo < 42) {
			score += points * 4;
		} else if (combo < 90) {
			score += points * 8;
		} else {
			score += points * 16;
		}
		combo++;;
	}

	static public void ResetCombo ()
	{
		combo = 0;
	}

	private void UpdateComboBar (){
		CtrlUI.score = (float)score;

        if (combo == 0)
        {
            combo1.enabled = false;
            combo2.enabled = false;
            combo3.enabled = false;
            combo4.enabled = false;
            combo5.enabled = false;
            combo6.enabled = false;
            combo7.enabled = false;
            combo8.enabled = false;
            combo9.enabled = false;
            combo10.enabled = false;
            combo11.enabled = false;
            combo12.enabled = false;
            combo13.enabled = false;
            combo14.enabled = false;
            combo15.enabled = false;
            combo16.enabled = false;
            combo17.enabled = false;
            combo18.enabled = false;
            combo19.enabled = false;
            combo20.enabled = false;

            combo1.transform.localScale = new Vector3(0, 1, 0);
        }
        if (combo == 1)
        {
            combo1.enabled = true;
            
            if(combo1.transform.localScale.x + amountToIncrease > 1)
            {
                combo1.transform.localScale = new Vector3(1, 1, 0);
                combo2.transform.localScale = new Vector3(1, 0, 0);
            } else {
                combo1.transform.localScale += new Vector3(amountToIncrease, 0, 0);
            }
        }
        if (combo == 2)
        {
            combo2.enabled = true;

            if (combo2.transform.localScale.y + amountToIncrease > 1)
            {
                combo2.transform.localScale = new Vector3(1, 1, 0);
                combo3.transform.localScale = new Vector3(0, 1, 0);
            }
            else {
                combo2.transform.localScale += new Vector3(0, amountToIncrease, 0);
            }
        }
        if (combo == 3 || combo == 4)
        {
            combo3.enabled = true;

            float temp = (combo - 2) / 2f;

            if (combo3.transform.localScale.x + amountToIncrease > temp)
            {
                combo3.transform.localScale = new Vector3(temp, 1, 0);
                combo4.transform.localScale = new Vector3(1, 0, 0);
            }
            else
            {
                combo3.transform.localScale += new Vector3(amountToIncrease, 0, 0);
            }
        }
        if (combo == 5)
        {
            combo4.enabled = true;

            if (combo4.transform.localScale.y + amountToIncrease > 1)
            {
                combo4.transform.localScale = new Vector3(1, 1, 0);
                combo5.transform.localScale = new Vector3(0, 1, 0);
            }
            else
            {
                combo4.transform.localScale += new Vector3(0, amountToIncrease, 0);
            }
        }
        if (combo == 6)
        {
            combo5.enabled = true;

            if (combo5.transform.localScale.x + amountToIncrease > 1)
            {
                combo5.transform.localScale = new Vector3(1, 1, 0);
                combo6.transform.localScale = new Vector3(0, 1, 0);
            }
            else
            {
                combo5.transform.localScale += new Vector3(amountToIncrease, 0, 0);
            }
        }

        if (combo == 7 || combo == 8)
        {
            combo1.enabled = false;
            combo2.enabled = false;
            combo3.enabled = false;
            combo4.enabled = false;
            combo5.enabled = false;
            combo6.enabled = true;
            float temp = (combo - 6) / 2f;

            if (combo6.transform.localScale.x + amountToIncrease > temp)
            {
                combo6.transform.localScale = new Vector3(temp, 1, 0);
                combo7.transform.localScale = new Vector3(1, 0, 0);
            }
            else
            {
                combo6.transform.localScale += new Vector3(amountToIncrease, 0, 0);
            }
        }
        if (combo == 9 || combo == 10)
        {
            combo7.enabled = true;
            float temp = (combo - 8) / 2f;

            if (combo7.transform.localScale.y + amountToIncrease > temp)
            {
                combo7.transform.localScale = new Vector3(1, temp, 0);
                combo8.transform.localScale = new Vector3(0, 1, 0);
            }
            else
            {
                combo7.transform.localScale += new Vector3(0, amountToIncrease, 0);
            }
        }
        if (combo >= 11 && combo <= 14)
        {
            combo8.enabled = true;
            float temp = (combo-10)/4f;

            if (combo8.transform.localScale.x + amountToIncrease > temp)
            {
                combo8.transform.localScale = new Vector3(temp, 1, 0);
                combo9.transform.localScale = new Vector3(1, 0, 0);
            }
            else
            {
                combo8.transform.localScale += new Vector3(amountToIncrease, 0, 0);
            }
        }
        if (combo == 15 || combo == 16)
        {
            combo9.enabled = true;
            float temp = (combo - 14) / 2f;

            if (combo9.transform.localScale.y + amountToIncrease > temp)
            {
                combo9.transform.localScale = new Vector3(1, temp, 0);
                combo10.transform.localScale = new Vector3(0, 1, 0);
            }
            else
            {
                combo9.transform.localScale += new Vector3(0, amountToIncrease, 0);
            }
        }
        if (combo == 17 || combo == 18)
        {
            combo10.enabled = true;
            float temp = (combo - 16) / 2f;

            if (combo10.transform.localScale.x + amountToIncrease > temp)
            {
                combo10.transform.localScale = new Vector3(temp, 1, 0);
                combo11.transform.localScale = new Vector3(0, 1, 0);
            }
            else
            {
                combo10.transform.localScale += new Vector3(amountToIncrease, 0, 0);
            }

        }


        if (combo >= 19 && combo <= 22)
        {
            combo6.enabled = false;
            combo7.enabled = false;
            combo8.enabled = false;
            combo9.enabled = false;
            combo10.enabled = false;
            combo11.enabled = true;
            float temp = (combo - 18) / 4f;

            if (combo11.transform.localScale.x + amountToIncrease > temp)
            {
                combo11.transform.localScale = new Vector3(temp, 1, 0);
                combo12.transform.localScale = new Vector3(1, 0, 0);
            }
            else
            {
                combo11.transform.localScale += new Vector3(amountToIncrease, 0, 0);
            }
        }
        if (combo >= 23 && combo <= 26)
        {
            combo12.enabled = true;
            float temp = (combo - 22) / 4f;

            if (combo12.transform.localScale.y + amountToIncrease > temp)
            {
                combo12.transform.localScale = new Vector3(1, temp, 0);
                combo13.transform.localScale = new Vector3(0, 1, 0);
            }
            else
            {
                combo12.transform.localScale += new Vector3(0, amountToIncrease, 0);
            }
        }
        if (combo >= 27 && combo <= 34)
        {
            combo13.enabled = true;
            float temp = (combo - 26) / 8f;

            if (combo13.transform.localScale.x + amountToIncrease > temp)
            {
                combo13.transform.localScale = new Vector3(temp, 1, 0);
                combo14.transform.localScale = new Vector3(1, 0, 0);
            }
            else
            {
                combo13.transform.localScale += new Vector3(amountToIncrease, 0, 0);
            }
        }
        if (combo >= 35 && combo <= 38)
        {
            combo14.enabled = true;
            float temp = (combo - 34) / 4f;

            if (combo14.transform.localScale.y + amountToIncrease > temp)
            {
                combo14.transform.localScale = new Vector3(1, temp, 0);
                combo15.transform.localScale = new Vector3(0, 1, 0);
            }
            else
            {
                combo14.transform.localScale += new Vector3(0, amountToIncrease, 0);
            }
        }
        if (combo >= 39 && combo <= 42)
        {
            combo15.enabled = true;
            float temp = (combo - 38) / 4f;

            if (combo15.transform.localScale.x + amountToIncrease > temp)
            {
                combo15.transform.localScale = new Vector3(temp, 1, 0);
                combo16.transform.localScale = new Vector3(0, 1, 0);
            }
            else
            {
                combo15.transform.localScale += new Vector3(amountToIncrease, 0, 0);
            }
        }

        if (combo >= 43 && combo <= 50)
        {
            combo11.enabled = false;
            combo12.enabled = false;
            combo13.enabled = false;
            combo14.enabled = false;
            combo15.enabled = false;
            combo16.enabled = true;
            float temp = (combo - 42) / 8f;

            if (combo16.transform.localScale.x + amountToIncrease > temp)
            {
                combo16.transform.localScale = new Vector3(temp, 1, 0);
                combo17.transform.localScale = new Vector3(1, 0, 0);
            }
            else
            {
                combo16.transform.localScale += new Vector3(amountToIncrease, 0, 0);
            }
        }
        if (combo >= 51 && combo <= 58)
        {
            combo17.enabled = true;
            float temp = (combo - 50) / 8f;

            if (combo17.transform.localScale.y + amountToIncrease > temp)
            {
                combo17.transform.localScale = new Vector3(1, temp, 0);
                combo18.transform.localScale = new Vector3(0, 1, 0);
            }
            else
            {
                combo17.transform.localScale += new Vector3(0, amountToIncrease, 0);
            }
        }
        if (combo >= 59 && combo <= 74)
        {
            combo18.enabled = true;
            float temp = (combo - 58) / 16f;

            if (combo18.transform.localScale.x + amountToIncrease > temp)
            {
                combo18.transform.localScale = new Vector3(temp, 1, 0);
                combo19.transform.localScale = new Vector3(1, 0, 0);
            }
            else
            {
                combo18.transform.localScale += new Vector3(amountToIncrease, 0, 0);
            }
        }
        if (combo >= 75 && combo <= 82)
        {
            combo19.enabled = true;
            float temp = (combo - 74) / 8f;

            if (combo19.transform.localScale.y + amountToIncrease > temp)
            {
                combo19.transform.localScale = new Vector3(1, temp, 0);
                combo20.transform.localScale = new Vector3(0, 1, 0);
            }
            else
            {
                combo19.transform.localScale += new Vector3(0, amountToIncrease, 0);
            }
        }
        if (combo >= 83 && combo <= 90)
        {
            combo20.enabled = true;
            float temp = (combo - 82) / 8f;

            if (combo20.transform.localScale.x + amountToIncrease > temp)
            {
                combo20.transform.localScale = new Vector3(temp, 1, 0);
            }
            else
            {
                combo20.transform.localScale += new Vector3(amountToIncrease, 0, 0);
            }
        }
        if(combo > 90)
        {
            //Muda de Cor ou Pulsa
        }


        if (combo < 6)
        {
            combox2.enabled = false;
            combox4.enabled = false;
            combox8.enabled = false;
            combox16.enabled = false;
        }
        else if (combo < 18)
        {
            combox2.enabled = true;
            combox4.enabled = false;
            combox8.enabled = false;
            combox16.enabled = false;
        }
        else if (combo < 42)
        {
            combox2.enabled = false;
            combox4.enabled = true;
            combox8.enabled = false;
            combox16.enabled = false;
        }
        else if (combo < 90)
        {
            combox2.enabled = false;
            combox4.enabled = false;
            combox8.enabled = true;
            combox16.enabled = false;
        }
        else
        {
            combox2.enabled = false;
            combox4.enabled = false;
            combox8.enabled = false;
            combox16.enabled = true;
        }

    }

	private void UpdateEnergyBar (){
		player.GetRedEnergy();

		player.GetBlueEnergy ();

		player.GetGreenEnergy ();

	}
}
