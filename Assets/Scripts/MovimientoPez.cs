using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPez : MonoBehaviour
{
    public GameObject Pez;
    public float speed = 2;
    public float radius = 0.3f;
    public float x, y;
    public float angle;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        angle += (speed / (radius * Mathf.PI * 2.0f)) * Time.deltaTime;
        Pez.transform.position = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
    }
}
