using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPez : MonoBehaviour
{
    public GameObject Pez;
    private float speed = 0.5f; // radianes/segundo
    private float radiusx = 5f;
    private float radiusz = 1.2f;
    public float x = 7.5f; // centro de rotacion x
    public float z = 1f; // centro de rotacion z

    public float angle;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        //angle += (speed/(Mathf.PI*2*radius)) * Time.deltaTime;
        //Pez.transform.position = new Vector3(-Mathf.Sin(angle) * radius, 0, Mathf.Cos(angle)) * radius * speed;
        // Pez.transform.Rotate(0.0f, angle, 0.0f, Space.Self);
        
        angle += speed * Time.deltaTime;
        Pez.transform.position = new Vector3( x + (Mathf.Sin(angle) * radiusx), 0, -z + (Mathf.Cos(angle) * radiusz));
        Pez.transform.forward = Pez.transform.position + new Vector3(2, 0, 2);
    }
}
