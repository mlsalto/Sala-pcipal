using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cajapiruletascript : MonoBehaviour
{

    // Start is called before the first frame update
    public int contadorpiruleta;


    void Start()
    {
        contadorpiruleta = 0;
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Piruleta")
        {
            contadorpiruleta++;
            FindObjectOfType<AudioManager>().Play("win");
        }
    }
}
