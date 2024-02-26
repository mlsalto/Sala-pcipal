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
    private bool acuario;
    public UxrGrabbableObject pesesito;
    private Animator animator;
    private Vector3 posini; 

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // se supone que obtiene el objeto en el que está
        // var pesesito = new UxrManipulationEventArgs();

        x = Pez.transform.position.x;
        y = Pez.transform.position.y;
        z = Pez.transform.position.z;

        posini = Pez.transform.position;
        // poner ángulo random //problema me lo hace con el banco de peces tmb????
        //System.Random random = new System.Random();
        //hangle = (float)random.NextDouble();

        colocado = false;
        agua = true;
        acuario = false;
    }

    // Update is called once per frame
    void Update()
    {
        // si lo colocamos en su sitio
        pesesito.Placed += ObjetoColocado;
        // si lo soltamos y no hay anchor alrededor
        pesesito.Released += ObjetoSoltado;
        pesesito.Placing += ObjetoColocando;


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
            else if(acuario == true || colocado == true)
            {
                noMovimiento();
            }
        }

        void ObjetoColocado(object sender, UxrManipulationEventArgs e)
        {
            colocado = true;
        }

        void ObjetoSoltado(object sender, UxrManipulationEventArgs e)
        {
            colocado = false;
        }
        void ObjetoColocando(object sender, UxrManipulationEventArgs e)
        {
            acuario = true;
        }
    }

 
    // funcion de movimiento estandar del pez
    private void movimientoNormal()
    {
        // movimiento dentro del agua
        if ( getDentroAgua() == true )
        {
            animator.SetBool("isWater", true);
            //circulo
            hangle += hspeed * Time.deltaTime;
            vangle += vspeed * Time.deltaTime;
            Pez.transform.position = new Vector3(x + (Mathf.Sin(hangle) * radiusx), y + (Mathf.Sin(vangle) * height), z - radiusz + (Mathf.Cos(hangle) * radiusz)); // a la pocicón del pez le resto el radio para que me de el centro de la circunferencia
                                                                                                                                                                    // Pez.transform.forward = new Vector3(x + (Mathf.Sin(angle + 20 ) * radiusx), 0, z + (Mathf.Cos(angle + 20) * radiusz));
            Pez.transform.LookAt(new Vector3(x + (Mathf.Sin(hangle - 25) * radiusx), y, z - radiusz + (Mathf.Cos(hangle - 25) * radiusz)));

            acuario = false;
        }


        else
        {          
              animator.SetBool("isWater", false);
              //caida hasta el suelo
              if (Pez.transform.position.y >= -1.3f)
              {
                     Pez.transform.position = new Vector3(x, -1.3f, z);
              }
             acuario = false;

        }
    }

    private void noMovimiento()
    {
        Pez.transform.position = new Vector3(x, y, z);
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
        acuario = false;
    }

    private bool getDentroAgua()
    {
        float limitsup_x = 8.2f;
        float limitinf_x = 1.6f;
        float limitsup_y = 1.7f;
        float limitinf_y = -1.7f;
        float limitsup_z = 21.7f;
        float limitinf_z = 15f;

       if(Pez.transform.position.x <= limitsup_x && Pez.transform.position.x >= limitinf_x && Pez.transform.position.y <= limitsup_y && Pez.transform.position.y >= limitinf_y && Pez.transform.position.z <= limitsup_z && Pez.transform.position.z >= limitinf_z)
       {
            return true;
       }
       else { return false; }
    }

    // reiniciar valores y todo
    public void reiniciar()
    {
        colocado = false;
        agua = true;

        Pez.transform.position = posini;

        x = Pez.transform.position.x;
        y = Pez.transform.position.y;
        z = Pez.transform.position.z;
    }
}


