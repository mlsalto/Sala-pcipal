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
    private float xrot; // centro de rotacion x
    private float yrot; // centro de rotacion y
    private float zrot; // centro de rotacion z


    private float angle;

    /// Pruebas Grabbable object
    //public UxrGrabbableObject Pesesito;
    //public class UxrManipulationEventArgs pesesito
    //public class UxrManipulationEventArgs : EventArgs
    //UxrManipulationEventArgs() pesesito;
    //public event EventHandler<UxrManipulationEventArgs> Releasing;
    public UxrGrabbableObject pesesito;

    // Start is called before the first frame update
    void Start()
    {
       // var pesesito = new UxrManipulationEventArgs();

        x = Pez.transform.position.x;
        y = Pez.transform.position.y;
        z = Pez.transform.position.z;
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

            //xrot = Pez.transform.rotation.x;
            //yrot = Pez.transform.rotation.y;
            //zrot = Pez.transform.rotation.z;

            angle = 0; 
            //timegrabbed = Time.deltaTime;
        }

        else
        {
            // rotamos bien el pez
            //Pez.transform.rotation.x = 0;
            //Pez.transform.rotation.z = 0;
            // elipse
            angle += speed * Time.deltaTime;
            Pez.transform.position = new Vector3(x + (Mathf.Sin(angle) * radiusx), y, z - radiusz + (Mathf.Cos(angle) * radiusz)); // a la pocicón del pez le resto el radio para que me de el centro de la circunferencia
            // Pez.transform.forward = new Vector3(x + (Mathf.Sin(angle + 20 ) * radiusx), 0, z + (Mathf.Cos(angle + 20) * radiusz));
            Pez.transform.LookAt(new Vector3(x + (Mathf.Sin(angle - 25) * radiusx), y, z - radiusz + (Mathf.Cos(angle - 25) * radiusz)));
        }

    }
}


