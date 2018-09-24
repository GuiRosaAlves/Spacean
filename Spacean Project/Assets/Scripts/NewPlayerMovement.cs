using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour {

    public float moveSpeed = 5f;
    public float rotSpeed = 3f;
    public float rotAcc = 75f;
    public float actualRotation;


    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerV2.isDead)
            return;

        actualRotation = this.gameObject.transform.rotation.z;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Vira pra Esquerda pelo melhor percurso
            if ((actualRotation < 0.68f || actualRotation > 0.72f) && (actualRotation > -0.6 && actualRotation < 0.72))
                transform.Rotate(new Vector3(0, 0, rotAcc) * Time.deltaTime * rotSpeed);
            else if (actualRotation < 0.68f || actualRotation > 0.72f)
                transform.Rotate(new Vector3(0, 0, -rotAcc) * Time.deltaTime * rotSpeed);

            if (actualRotation > 0)
            {
                this.gameObject.transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * moveSpeed;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Vira pra Direita pelo melhor percurso
            if ((actualRotation < -0.72f || actualRotation > -0.68f) && (actualRotation < 0.6 && actualRotation > -0.72))
            transform.Rotate(new Vector3(0, 0, -rotAcc) * Time.deltaTime * rotSpeed);
            else if (actualRotation < -0.72f || actualRotation > -0.68f)
            transform.Rotate(new Vector3(0, 0, rotAcc) * Time.deltaTime * rotSpeed);

            if (actualRotation < 0)
            {
                this.gameObject.transform.position += new Vector3(1, 0, 0) * Time.deltaTime * moveSpeed;
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Vira pra Cima pelo melhor percurso
            if ((actualRotation < -0.02f || actualRotation > 0.02f) && (actualRotation > -0.02))
            transform.Rotate(new Vector3(0, 0, -rotAcc) * Time.deltaTime * rotSpeed);
            else if (actualRotation < -0.02f || actualRotation > 0.02f)
            transform.Rotate(new Vector3(0, 0, rotAcc) * Time.deltaTime * rotSpeed);

            if (actualRotation < 0.5 && actualRotation > -0.5)
            {
                this.gameObject.transform.position += new Vector3(0, 1, 0) * Time.deltaTime * moveSpeed;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Vira pra Baixo pelo melhor percurso
            if ((actualRotation < 0.98f || actualRotation > -0.98) && (actualRotation > 0))
            transform.Rotate(new Vector3(0, 0, rotAcc) * Time.deltaTime * rotSpeed);
            else if (actualRotation > -0.98f)
            transform.Rotate(new Vector3(0, 0, -rotAcc) * Time.deltaTime * rotSpeed);

            if (actualRotation < -0.5f || actualRotation > 0.5f)
            {
                this.gameObject.transform.position += new Vector3(0, -1, 0) * Time.deltaTime * moveSpeed;
            }
        }
    }

    void RotateLeft () {
        transform.Rotate(Vector3.forward);
    }
}
