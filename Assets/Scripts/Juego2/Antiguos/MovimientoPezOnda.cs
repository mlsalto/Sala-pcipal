using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPezOnda : MonoBehaviour
{
    public GameObject Pez;
    public float hspeed = 0.5f; // radianes/segundo
    public float vspeed = 0.5f; // radianes/segundo
    public float radiusx = 5f;
    public float radiusz = 1.2f;
    private float x ; // centro de rotacion x
    private float y ;
    private float z ; // centro de rotacion z
    public float height = 1f;

    private float hangle;
    private float vangle;

    // Start is called before the first frame update
    void Start()
    {
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

        hangle += hspeed * Time.deltaTime;
        vangle += vspeed * Time.deltaTime;
        Pez.transform.position = new Vector3(x + (Mathf.Sin(hangle) * radiusx), y + (Mathf.Sin(vangle) * height), -z + (Mathf.Cos(hangle) * radiusz));
        Pez.transform.forward = new Vector3(x + (Mathf.Sin(hangle - 30) * radiusx), 0, -z + (Mathf.Cos(hangle - 30) * radiusz));
    }
}
