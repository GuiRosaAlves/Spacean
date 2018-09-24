using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerV2 : MonoBehaviour
{
    
    public static bool canTakeDamage = true;

    public float invencibilityTime = 2f;

    public static bool isDead;

    public Light[] lightPoints;

    public Image redGauge;
    public Image greenGauge;
    public Image blueGauge;

    public float vel = 5f;
    public float velRotacao = 3f;

    Rigidbody2D rb;
    Vector2 direcao;
    float angulo;
    Quaternion q;

    public Transform mira;

    public int life = 3;
    private bool m_recharging;

    //int actualBullet = 0;
    [Header("Atributos"), SerializeField]
    public static int redEnergy = 1000;
    [SerializeField]
    public static int blueEnergy = 1000;
    [SerializeField]
    public static int greenEnergy = 1000;

    [SerializeField]
    private int rechargeByTime = 10;
    [SerializeField]
    private int rechargeByBattery = 250;
    [SerializeField]
    private int EnergyByShot = 25;

    [SerializeField]
    private int EnergyLimit = 1000;
    [SerializeField]
    private int timeToRecharge = 2;

    [SerializeField]
    private int nVezesSemAtirar;
    [SerializeField]
    private int nVezesParaRecarregar;

    [SerializeField]
    private GameObject redShot;
    [SerializeField]
    private GameObject blueShot;
    [SerializeField]
    private GameObject greenShot;

    [SerializeField]
    private float fireRate = 0.5f;
    private float nextFire = 0.0f;
    public GameObject panel;

    //Apenas Para Testes
    public int essecombo;

    void OnAwake()
    {
        canTakeDamage = true;
        redEnergy = 1000;
        greenEnergy = 1000;
        blueEnergy = 1000;
    }

    void Start()
    {
        isDead = false;
        canTakeDamage = true;
        rb = GetComponent<Rigidbody2D>();
        redEnergy = 1000;
        greenEnergy = 1000;
        blueEnergy = 1000;
        nVezesParaRecarregar = timeToRecharge * 2;
        Invoke("RechargingByTime", 0.5f);
    }

    void FixedUpdate()
    {
        /*direcao = Vector2.zero;
        direcao.x = Input.GetAxisRaw("Horizontal");
        direcao.y = Input.GetAxisRaw("Vertical");

        //Também não sei, o japa deve saber melhor
        rb.velocity = direcao * vel;

        if (direcao != Vector2.zero)
        {
            angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
            q = Quaternion.AngleAxis(angulo, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * velRotacao);
        }
        else
        {
            rb.angularVelocity = 0f;
        }
        */
        if (isDead)
            return;

        if(life <= 0)
        {
            //panel.SetActive(true);
        }

        UpdateHUD();
        Fire();

        SetCombo();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Verifica o tipo de bateria que o jogador pegou
        if (col.gameObject.tag == "BlueEnergy")
        {
            //Verifica se A Bateria vai carregar toda energia, ou parcialmente
            if (blueEnergy + rechargeByBattery > EnergyLimit)
            {
                blueEnergy = EnergyLimit;
            }
            else
            {
                blueEnergy += rechargeByBattery;
            }
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "RedEnergy")
        {
            //Verifica se A Bateria vai carregar toda energia, ou parcialmente
            if (redEnergy + rechargeByBattery > EnergyLimit)
            {
                redEnergy = EnergyLimit;
            }
            else
            {
                redEnergy += rechargeByBattery;
            }
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "GreenEnergy")
        {
            //Verifica se A Bateria vai carregar toda energia, ou parcialmente
            if (greenEnergy + rechargeByBattery > EnergyLimit)
            {
                greenEnergy = EnergyLimit;
            }
            else
            {
                greenEnergy += rechargeByBattery;
            }
            Destroy(col.gameObject);
        }

        //if (col.gameObject.layer == 9 || col.gameObject.layer == 6)
        if (col.CompareTag("RedEnemy") || col.CompareTag("GreenEnemy") || col.CompareTag("BlueEnemy") ||
            col.CompareTag("RedProj") || col.CompareTag("GreenProj") || col.CompareTag("BlueProj"))
        {
            AudioSource.PlayClipAtPoint(Sounds.Instance.explosion, Vector3.zero);
            if (canTakeDamage)
            {
                life--;
                canTakeDamage = false;
                StartCoroutine("ChangeDamageState", invencibilityTime);
                Destroy(col.gameObject);
            }
            switch (life)
            {
                case 5:
                    lightPoints[6].intensity = 50f;
                    lightPoints[0].intensity = 0f;
                    break;
                case 4:
                    lightPoints[6].intensity = 40f;
                    lightPoints[1].intensity = 0f;
                    break;
                case 3:
                    lightPoints[6].intensity = 30f;
                    lightPoints[2].intensity = 0f;
                    break;
                case 2:
                    lightPoints[6].intensity = 20f;
                    lightPoints[3].intensity = 0f;
                    break;
                case 1:
                    lightPoints[6].intensity = 5f;
                    lightPoints[4].intensity = 0f;
                    break;
                case 0:
                    lightPoints[6].intensity = 0f;
                    lightPoints[5].intensity = 0f;
                    break;
                default:
                    break;
            }
            Destroy(col.gameObject);
            GameManager.ResetCombo();
        }
    }

    IEnumerator ChangeDamageState(float time)
    {
        yield return new WaitForSeconds(time);

        print("Damage State: " + canTakeDamage);
        canTakeDamage = !canTakeDamage;
        StopCoroutine("ChangeDamageState");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        rb.velocity = Vector2.zero;
    }

    void RechargingByTime()
    {
        if (nVezesSemAtirar > nVezesParaRecarregar)
        {
            Invoke("EnergyRecharge", 0f);
        }
        nVezesSemAtirar++;
        Invoke("RechargingByTime", 0.5f);
    }

    void EnergyRecharge()
    {
        if (redEnergy + rechargeByTime < EnergyLimit)
        {
            redEnergy += rechargeByTime;
        }
        else
        {
            redEnergy = EnergyLimit;
        }
        if (blueEnergy + rechargeByTime < EnergyLimit)
        {
            blueEnergy += rechargeByTime;
        }
        else
        {
            blueEnergy = EnergyLimit;
        }
        if (greenEnergy + rechargeByTime < EnergyLimit)
        {
            greenEnergy += rechargeByTime;
        }
        else
        {
            greenEnergy = EnergyLimit;
        }
    }

    private void Fire()
    {
        //Quando apertar Espaço, ele zera o carregamento de energia, e atira
        if (Input.GetKey(KeyCode.Z) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            AudioSource.PlayClipAtPoint(Sounds.Instance.shoot, Vector3.zero);

            if (redEnergy - EnergyByShot >= 0)
            {
                nVezesSemAtirar = 0;
                redEnergy -= EnergyByShot;
                Instantiate(redShot, mira.position, gameObject.transform.rotation);
            }
        }
        if (Input.GetKey(KeyCode.X) && Time.time > nextFire)
        {
            AudioSource.PlayClipAtPoint(Sounds.Instance.shoot, Vector3.zero);
            nextFire = Time.time + fireRate;
            if (greenEnergy - EnergyByShot >= 0)
            {
                nVezesSemAtirar = 0;
                greenEnergy -= EnergyByShot;
                Instantiate(greenShot, mira.position, gameObject.transform.rotation);
            }
        }
        if (Input.GetKey(KeyCode.C) && Time.time > nextFire)
        {
            AudioSource.PlayClipAtPoint(Sounds.Instance.shoot, Vector3.zero);
            nextFire = Time.time + fireRate;
            if (blueEnergy - EnergyByShot >= 0)
            {
                nVezesSemAtirar = 0;
                blueEnergy -= EnergyByShot;
                Instantiate(blueShot, mira.position, gameObject.transform.rotation);
            }
        }
    }

    public int GetRedEnergy()
    {
        return redEnergy;
    }
    public int GetBlueEnergy()
    {
        return blueEnergy;
    }
    public int GetGreenEnergy()
    {
        return greenEnergy;
    }

    public void UpdateHUD()
    {
        redGauge.fillAmount = (float)redEnergy / (float)EnergyLimit;
        greenGauge.fillAmount = (float)greenEnergy / (float)EnergyLimit;
        blueGauge.fillAmount = (float)blueEnergy / (float)EnergyLimit;

        //Verifica Vida
        /*
        if (life == 3)
        {

        }
        else if (life == 2)
        {

        }
        else if (life == 1)
        {

        }
        else */
        if (life <= 0)
        {
            //GameOver
            isDead = true;
            lightPoints[6].intensity = 0f;
            foreach (Collider2D col in GetComponents<Collider2D>())
            {
                col.enabled = false;
            }
        }
        //AtualizaEnergyBars
    }


    //Apenas Para Testes
    void SetCombo() {
        if(essecombo == 1)
        {
            GameManager.combo--;
            essecombo = 0;
        }
        if (essecombo == 2)
        {
            GameManager.combo++;
            essecombo = 0;
        }
        if (essecombo > 2 || essecombo < 0)
        {
            GameManager.combo = essecombo;
            essecombo = 0;
        }

    }
}