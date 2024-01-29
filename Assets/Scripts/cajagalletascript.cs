using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cajagalletascript : MonoBehaviour
{

    // Start is called before the first frame update
    public int contadorgalleta;


    void Start()
    {
        contadorgalleta = 0;
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Galleta")
        {
            contadorgalleta++;
        }
    }
}
