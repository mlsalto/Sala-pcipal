using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cajadonascript : MonoBehaviour
{

    // Start is called before the first frame update
    public int contadordona;
    void Start()
    {
        contadordona = 0;
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Dona")
        {
            contadordona++;
        }
    }

}
