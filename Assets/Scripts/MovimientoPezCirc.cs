using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Manipulation;
using System;

public class MovimientoPezCirc : MonoBehaviour
{
    public GameObject Pez;
    public float speed = 0.5f; // radianes/segundo
    public float radiusx = 5f;
    public float radiusz = 1.2f;
    private float x; // centro de rotacion x
    private float y; // centro de rotacion y
    private float z; // centro de rotacion z

    //private float xrot; // centro de rotacion x
    //private float yrot; // centro de rotacion y
    //private float zrot; // centro de rotacion z

    private float angle;
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
        System.Random random = new System.Random();
        angle = (float)random.NextDouble();
    }

    // Update is called once per frame
    void Update()
    {
        //angle += (speed/(Mathf.PI*2*radius)) * Time.deltaTime;
        //Pez.transform.position = new Vector3(-Mathf.Sin(angle) * radius, 0, Mathf.Cos(angle)) * radius * speed;
        // Pez.transform.Rotate(0.0f, angle, 0.0f, Space.Self);

        if (pesesito.IsBeingGrabbed == true)
        {
            // cuando lo coges vuelves a pillar los valores del pez :)
            x = Pez.transform.position.x;
            y = Pez.transform.position.y;
            z = Pez.transform.position.z;

            //animator.Play("Base Layer.Eat", 0, 0); // para la animación
            animator.SetBool("isGrabbed", true);

            angle = 0; 
            //timegrabbed = Time.deltaTime;
        }

        else
        {

            //animator.Play("Base Layer.Fear", 0, 0);
            animator.SetBool("isGrabbed", false);

            // circulo
            angle += speed * Time.deltaTime;
            Pez.transform.position = new Vector3(x + (Mathf.Sin(angle) * radiusx), y, z - radiusz + (Mathf.Cos(angle) * radiusz)); // a la pocicón del pez le resto el radio para que me de el centro de la circunferencia
            // Pez.transform.forward = new Vector3(x + (Mathf.Sin(angle + 20 ) * radiusx), 0, z + (Mathf.Cos(angle + 20) * radiusz));
            Pez.transform.LookAt(new Vector3(x + (Mathf.Sin(angle - 25) * radiusx), y, z - radiusz + (Mathf.Cos(angle - 25) * radiusz)));
        }

    }
}


