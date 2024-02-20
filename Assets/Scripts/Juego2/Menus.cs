using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menus : MonoBehaviour
{
    public GameObject menuOpciones;
    public GameObject menuNiveles;
    public GameObject juego;

    private bool start;

    // Start is called before the first frame update
    void Start()
    {
        juego.SetActive(true);
        menuOpciones.SetActive(false);
        menuNiveles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //funcion que enseñe el meni de opciones
    public void setMenuOpciones()
    {
        menuOpciones.SetActive(true);

        //desactivar resto de menus
        juego.SetActive(false);
        menuNiveles.SetActive(false);
    }


    //funcion que enseñe menu niveles
    public void setMenuNiveles()
    {
        menuNiveles.SetActive(true);

        //desactivar resto de menus
        juego.SetActive(false);
        menuOpciones.SetActive(false);
    }


    //funcion sala principal

    //función continuar nivel
    public void setJuego()
    {
        juego.SetActive(true);

        //desactivar resto de menus
        menuNiveles.SetActive(false);
        menuOpciones.SetActive(false);
    }
}
