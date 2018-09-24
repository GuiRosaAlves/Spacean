using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float vel = 1f;
	public float velRotacao = 1f;

	Rigidbody2D rb;
	Vector2 direcao;
	float angulo;
	Quaternion q;

	private bool m_recharging;

	//int actualBullet = 0;
	public int redEnergy = 1000;
	public int blueEnergy = 1000;
	public int greenEnergy = 1000;

	public int rechargeByTime = 10;
	public int rechargeByBattery = 250;
	public int EnergyByShot = 25;

	public int EnergyLimit = 1000;
	public int timeToRecharge = 2;

	public int nVezesSemAtirar;
	public int nVezesParaRecarregar;

	public GameObject redShot;
	public GameObject blueShot;
	public GameObject greenShot;

	void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
		redEnergy = 1000;
		greenEnergy = 1000;
		blueEnergy = 1000;
		nVezesParaRecarregar = timeToRecharge * 2;
		Invoke ("RechargingByTime", 0.5f);
	}

	void FixedUpdate()
	{
		direcao = Vector2.zero;
		direcao.x = Input.GetAxisRaw ("Horizontal");
		direcao.y = Input.GetAxisRaw ("Vertical");

		//Também não sei, o japa deve saber melhor
		rb.velocity = direcao * vel;
		if (direcao != Vector2.zero) {
			angulo = Mathf.Atan2 (direcao.y, direcao.x) * Mathf.Rad2Deg;
			q = Quaternion.AngleAxis (angulo, Vector3.forward);
			transform.rotation = Quaternion.Slerp (transform.rotation, q, Time.deltaTime * velRotacao);
		} else {
			rb.angularVelocity = 0f;
		}

		//Quando apertar Espaço, ele zera o carregamento de energia, e atira
		if (Input.GetKeyDown (KeyCode.Z)) {
			nVezesSemAtirar = 0;
			redEnergy -= EnergyByShot;
			Atirar (0);
		}
		if (Input.GetKeyDown (KeyCode.X)) {
			nVezesSemAtirar = 0;
			blueEnergy -= EnergyByShot;
			Atirar (1);
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			nVezesSemAtirar = 0;
			greenEnergy -= EnergyByShot;
			Atirar (2);
		}

	}

	void OnTriggerEnter2D(Collider2D col){
		//Verifica o tipo de bateria que o jogador pegou
		if (col.gameObject.tag == "blueEnergy") {
			//Verifica se A Bateria vai carregar toda energia, ou parcialmente
			if (blueEnergy + rechargeByBattery > EnergyLimit) {
				blueEnergy = EnergyLimit;
			} else {
				blueEnergy += rechargeByBattery;
			}
		}
		if (col.gameObject.tag == "redEnergy") {
			//Verifica se A Bateria vai carregar toda energia, ou parcialmente
			if (redEnergy + rechargeByBattery > EnergyLimit) {
				redEnergy = EnergyLimit;
			} else {
				redEnergy += rechargeByBattery;
			}
		}
		if (col.gameObject.tag == "greenEnergy") {
			//Verifica se A Bateria vai carregar toda energia, ou parcialmente
			if (greenEnergy + rechargeByBattery > EnergyLimit) {
				greenEnergy = EnergyLimit;
			} else {
				greenEnergy += rechargeByBattery;
			}
		}
	}

	void RechargingByTime(){
		if (nVezesSemAtirar > nVezesParaRecarregar) {
			Invoke ("EnergyRecharge", 0f);
		}
		nVezesSemAtirar++;
		Invoke ("RechargingByTime", 0.5f);
	}

	void EnergyRecharge()
	{
		
		if (redEnergy + rechargeByTime < EnergyLimit) {
			redEnergy += rechargeByTime;
		} else {
			redEnergy = EnergyLimit;
		}
		if (blueEnergy+rechargeByTime < EnergyLimit) {
			blueEnergy += rechargeByTime;
		} else {
			blueEnergy = EnergyLimit;
		}
		if (greenEnergy+rechargeByTime < EnergyLimit) {
			greenEnergy+= rechargeByTime;
		} else {
			greenEnergy = EnergyLimit;
		}
	}

	void Atirar(int tipoTiro){
		//Tiro Vermelho
		if (tipoTiro == 0) {
			Instantiate (redShot, this.gameObject.transform.position, Quaternion.identity);
		}
		//Tiro Azul
		if (tipoTiro == 1) {
			Instantiate (blueShot, this.gameObject.transform.position, Quaternion.identity);
		}
		//Tiro Verde
		if (tipoTiro == 2) {
			Instantiate (greenShot, this.gameObject.transform.position, Quaternion.identity);
		}
	}

	public int GetRedEnergy(){
		return redEnergy;
	}
	public int GetBlueEnergy(){
		return blueEnergy;
	}
	public int GetGreenEnergy(){
		return greenEnergy;
	}
}
