using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cajacupcakescript : MonoBehaviour
{

    // Start is called before the first frame update
    public int contadorcake;
 
    void Start()
    {
        contadorcake = 0;
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Cupcake")
        {
            contadorcake++;
            FindObjectOfType<AudioManager>().Play("win");
        }
    }

}
