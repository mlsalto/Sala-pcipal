using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Manipulation;
using System;
using UnityEngine.SceneManagement;


public class CambioMundo : MonoBehaviour
{
    public GameObject llave;
    public UxrGrabbableObjectAnchor altar;
    public UxrGrabbableObject cilindro;
    // Start is called before the first frame update

    //public event EventHandler Placed;
    private bool colocado;
    private float timer;

    void Start()
    {
        colocado = false;
        timer = 0.0f;
   
    }

    // Update is called once per frame
    void Update()
    {
        altar.Placed += ObjetoColocado; // etiqueta de evento se usa así jeje

        if (colocado == true)
        {
            timer += Time.deltaTime;
            llave.transform.localScale += new Vector3(0.0f, 0.01f, 0.0f);

            if (timer > 5)
            {
                Cambio("Juego2");
            }
        }
    }

    void ObjetoColocado(object sender, UxrManipulationEventArgs e)
    {
        colocado = true;
        //contador = Time.deltaTime;
    }

    public void Cambio(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
}
