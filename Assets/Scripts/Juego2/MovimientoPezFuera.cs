using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Manipulation;
using System;

public class MovimientoPezFuera : MonoBehaviour
{
    public GameObject Pez;

    public float hspeed = 0.5f; // radianes/segundo
    public float vspeed = 0.5f; // radianes/segundo
    public float radiusx = 5f;
    public float radiusz = 1.2f;
    public float height = 1f;

    private float x; // centro de rotacion x
    private float y; // centro de rotacion y
    private float z; // centro de rotacion z


    public float hangle;
    public float vangle;

    private bool colocado;
    private bool quieto;
    private bool agua;
    private bool acuario;
    public UxrGrabbableObject pesesito;
    private Animator animator;
    private Vector3 posini; 

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // se supone que obtiene el objeto en el que esta
        // var pesesito = new UxrManipulationEventArgs();

        x = Pez.transform.position.x;
        y = Pez.transform.position.y;
        z = Pez.transform.position.z;

        posini = Pez.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
          movimientoNormal();
    }

 
    // funcion de movimiento estandar del pez
    private void movimientoNormal()
    {
        // movimiento dentro del agua
 
        animator.SetBool("isWater", true);
            //circulo
        hangle += hspeed * Time.deltaTime;
        vangle += vspeed * Time.deltaTime;
        Pez.transform.position = new Vector3(x + (Mathf.Sin(hangle) * radiusx), y + (Mathf.Sin(vangle) * height), z - radiusz + (Mathf.Cos(hangle) * radiusz)); // a la pocicion del pez le resto el radio para que me de el centro de la circunferencia
        // Pez.transform.forward = new Vector3(x + (Mathf.Sin(angle + 20 ) * radiusx), 0, z + (Mathf.Cos(angle + 20) * radiusz));
        Pez.transform.LookAt(new Vector3(x + (Mathf.Sin(hangle - 25) * radiusx), y, z - radiusz + (Mathf.Cos(hangle - 25) * radiusz)));
    }

}


