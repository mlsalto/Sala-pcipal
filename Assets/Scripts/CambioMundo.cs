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
                StartCoroutine(LoadYourAsyncScene());
            }
        }
    }

    void ObjetoColocado(object sender, UxrManipulationEventArgs e)
    {
        colocado = true;
        //contador = Time.deltaTime;
    }

    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Juego2");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
