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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // funcion para empezar juego 
    public void empezarJuego()
    {
        start = true;
    }

    //funcion que enseñe el meni de opciones
    public void setMenuOpciones()
    {
        menuOpciones.SetActive(true);
        //desactivar resto de menus
    }


    //funcion que enseñe menu niveles
    public void setMenuNiveles()
    {
        menuNiveles.SetActive(true);
        //desactivar resto de menus
    }


    //funcion sala principal

    //función continuar nivel
}
