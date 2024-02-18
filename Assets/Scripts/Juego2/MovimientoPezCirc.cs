using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Manipulation;
using System;

public class MovimientoPezCirc : MonoBehaviour
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
    private float vangle;

    private bool colocado;
    private bool quieto;
    private bool agua;
    public UxrGrabbableObject pesesito;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // se supone que obtiene el objeto en el que está
        // var pesesito = new UxrManipulationEventArgs();

        x = Pez.transform.position.x;
        y = Pez.transform.position.y;
        z = Pez.transform.position.z;

        // poner ángulo random //problema me lo hace con el banco de peces tmb????
        //System.Random random = new System.Random();
        //hangle = (float)random.NextDouble();

        colocado = false;
    }

    // Update is called once per frame
    void Update()
    {
        // si lo colocamos en su sitio
        pesesito.Placed += ObjetoColocado;

        if (pesesito.IsBeingGrabbed == true)
        {
            movimientoEnMano();

        }

        else
        {
            animator.SetBool("isGrabbed", false);

            if (colocado == false)
            {
                movimientoNormal();
            } 
        }

        void ObjetoColocado(object sender, UxrManipulationEventArgs e)
        {
            colocado = true;
        }
    }

    //  si entra algo en el cuadrado //
    private void OnTriggerEnter(Collider collider)
    {
        agua = true;
    }

    //  si sale algo del cuadrado //
    private void OnTriggerExit(Collider collider)
    {
        agua = false;
    }

    // funcion de movimiento estandar del pez
    private void movimientoNormal()
    {
        // movimiento dentro del agua
        if (agua == true)
        {
            //circulo
            hangle += hspeed * Time.deltaTime;
            vangle += vspeed * Time.deltaTime;
            Pez.transform.position = new Vector3(x + (Mathf.Sin(hangle) * radiusx), y + (Mathf.Sin(vangle) * height), z - radiusz + (Mathf.Cos(hangle) * radiusz)); // a la pocicón del pez le resto el radio para que me de el centro de la circunferencia
                                                                                                                                                                    // Pez.transform.forward = new Vector3(x + (Mathf.Sin(angle + 20 ) * radiusx), 0, z + (Mathf.Cos(angle + 20) * radiusz));
            Pez.transform.LookAt(new Vector3(x + (Mathf.Sin(hangle - 25) * radiusx), y, z - radiusz + (Mathf.Cos(hangle - 25) * radiusz)));
        }

        // movimiento fuera del agua
        else { 
            // hacer funcion
        }
    }


    // funcion en caso de estar cogidos por el jugador
    private void movimientoEnMano()
    {
        // cuando lo coges vuelves a pillar los valores del pez :)
        x = Pez.transform.position.x;
        y = Pez.transform.position.y;
        z = Pez.transform.position.z;

        ////animator.Play("Base Layer.Eat", 0, 0); // para la animación
        //animator.SetBool("isGrabbed", true);

        hangle = Pez.transform.rotation.y;


        animator.SetBool("isGrabbed", true);
    }
}


