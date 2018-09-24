using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botoes : MonoBehaviour {


	public void loadScene(string nomeCena){
		Application.LoadLevel (nomeCena);
	}
}
