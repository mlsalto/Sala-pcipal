using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Manipulation;
using System;
using UnityEngine.SceneManagement;


public class CambioMundo : MonoBehaviour
{
//    public GameObject llaveN1;
    public GameObject llaveN1;
    public GameObject llaveN2;

    //public GameObject llaveN3;
    //public GameObject llaveN4;
    public UxrGrabbableObjectAnchor altar;
    public UxrGrabbableObject cilindro1;
    public UxrGrabbableObject cilindro2;
    // Start is called before the first frame update

    //public event EventHandler Placed;
    private bool colocado1;
    private bool colocado2;
    private float timer;
    private int nivel;

    void Start()
    {
        colocado1 = false;
        colocado2 = false;
        timer = 0.0f;
        nivel = 0;
   
    }

    // Update is called once per frame
    void Update()
    {
        cilindro1.Placed += ObjetoColocado1; // etiqueta de evento se usa así jeje
        cilindro2.Placed += ObjetoColocado2; // etiqueta de evento se usa así jeje


        if (colocado1 == true)
        {
            timer += Time.deltaTime;
            llaveN1.transform.localScale += new Vector3(0.0f, 0.01f, 0.0f);

            if (timer > 5)
            {
                StartCoroutine(LoadYourAsyncScene1());
            }
        }
        else if (colocado2 == true)
        {
            timer += Time.deltaTime;
            llaveN2.transform.localScale += new Vector3(0.0f, 0.01f, 0.0f);

            if (timer > 5)
            {
                StartCoroutine(LoadYourAsyncScene2());
            }
        }
    }

    void ObjetoColocado1(object sender, UxrManipulationEventArgs e)
    {
        colocado1 = true;
        //contador = Time.deltaTime;
    }

    void ObjetoColocado2(object sender, UxrManipulationEventArgs e)
    {
        colocado2 = true;
        //contador = Time.deltaTime;
    }

    //void NivelElegido()
    //{
    //    if(Nivel1.IsBeingGrabbed == true) { nivel = 1; }
    //    else if (Nivel2.IsBeingGrabbed == true) { nivel = 2; }
    //    else if (Nivel3.IsBeingGrabbed == true) { nivel = 3; }
    //    else if (Nivel4.IsBeingGrabbed == true) { nivel = 4; }
    //}

    IEnumerator LoadYourAsyncScene1()
    {
        AsyncOperation asyncLoad1 = SceneManager.LoadSceneAsync("Juego1");

        while (!asyncLoad1.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadYourAsyncScene2()
    {
        AsyncOperation asyncLoad2 = SceneManager.LoadSceneAsync("Juego2");

        while (!asyncLoad2.isDone )
        {
            yield return null;
        }
    }
}
