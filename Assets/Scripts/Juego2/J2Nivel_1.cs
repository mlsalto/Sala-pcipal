using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;


//***   EN EL NIVEL 1 SÓLO SE HARÁN SUMAS DE 1 EN 1 HASTA EL NÚMERO 10   ***//

public class J2Nivel_1 : MonoBehaviour
{
 
    // variables publicas
    public ObjetoEnArea acuario;
    public GameObject botonE;
    public GameObject botonO;
    public GameObject botonS;


    public GameObject ObjetosNivel_1;
    public GameObject ObjetosNivel_2;
    public GameObject ObjetosNivel_3;
    public GameObject ObjetosNivel_4;

    // variables privadas
    private bool start;
    private bool juego;
    private int nivel;
    [SerializeField] private TMP_Text texto;
    private int numParaSumar;
    private int suma;
    private System.Random random;

    // Start is called before the first frame update
    void Start()
    {
        start = false;
        juego = false;
        nivel = 1;
        botonE.SetActive(true);
        botonO.SetActive(false);
        botonS.SetActive(false);
        texto.text = "El mar se está quedando sin peces por la contaminación. \n ¡¡¡¡ Ayudame a repoblarlos sumando !!!!";

        random = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        //IF LE DAN A OK EN EL MENÚ ANTERIOR HAZ LO SIGUIENTE:
        //El numero del nivel 1 es de 1-10, nivel 2 10-99, nivel 3 99-999, (solo con dec, cent, uni) 

        if (start == true)
        {

            botonE.SetActive(false);
            botonO.SetActive(true);

            texto.text = "Suma los peces para conseguir el número " + numParaSumar.ToString() + "\n \n" + ConvertirVectorATexto(acuario.vectNumeros, acuario.numPecesIn);

            if (numParaSumar == suma)
            {
                texto.text = "Suma los peces para conseguir el número " + numParaSumar.ToString() + "\n \n" + ConvertirVectorATexto(acuario.vectNumeros, acuario.numPecesIn) + "\n" + "CORRECTO  :)";
                if (nivel != 4) { 
                botonS.SetActive(true);
                }
            }

            else if (numParaSumar < suma)
            {
                texto.text = "Suma los peces para conseguir el número " + numParaSumar.ToString() + "\n \n" + ConvertirVectorATexto(acuario.vectNumeros, acuario.numPecesIn) + "\n" + "INCORRECTO  :(";
            }
        }
    }

    // Funcion que convierte el vector de numeros a texto
    private string ConvertirVectorATexto(int[] vector, int size)
    {
        StringBuilder textoTmp = new StringBuilder();
        suma = 0;

        // vector no vacio 
        if (vector.Length > 0)
        {
            // primer numero
            textoTmp.Append(vector[0]);
            suma = vector[0];

            // resto numeros
            for (int i = 1; i < size; i++)
            {
                textoTmp.Append(" + " + vector[i]);
                suma += vector[i];
            }

            // suma
            textoTmp.Append(" = " + suma);
        }

        return textoTmp.ToString();
    }

    // funcion para empezar juego 
    public void empezarJuego()
    {
       
        setNivel(nivel);
        start = true;
    }
    
    public void siguienteNivel()
    {
        botonS.SetActive(false);
        if(nivel == 4)
        {
            nivel = 1;
        }
        else nivel++;
        setNivel(nivel);
    }


    //funcion de cambio de niveles & incializacion de niveles
    public void setNivel(int n)
    {
        nivel = n;

        // reiniciamos valores del vector de suma  //       
        acuario.reiniciar();

        // reiniciar todos los objetos
        ObjetosNivel_1.GetComponent<ObjetosNivel>().eliminarObjetosDinamicos();
        ObjetosNivel_2.GetComponent<ObjetosNivel>().eliminarObjetosDinamicos();
        ObjetosNivel_3.GetComponent<ObjetosNivel>().eliminarObjetosDinamicos();
        ObjetosNivel_4.GetComponent<ObjetosNivel>().eliminarObjetosDinamicos();


        // apagar todos los objetos
        ObjetosNivel_1.SetActive(false);
        ObjetosNivel_2.SetActive(false);
        ObjetosNivel_3.SetActive(false);
        ObjetosNivel_4.SetActive(false);

        // encender el objeto correspondiente y generar el número
        switch (n)
        {
            case 1:
                numParaSumar = random.Next(1, 11); //numero del 1 al 10
                ObjetosNivel_1.GetComponent<ObjetosNivel>().reiniciar();
                ObjetosNivel_1.SetActive(true);
                break;

            case 2:
                numParaSumar = 10 * random.Next(1, 11); //numero del 1 al 100
                ObjetosNivel_2.GetComponent<ObjetosNivel>().reiniciar();
                ObjetosNivel_2.SetActive(true);
                break;

            case 3:
                numParaSumar = 100 * random.Next(1, 4); //numero del 1 al 1000
                ObjetosNivel_3.GetComponent<ObjetosNivel>().reiniciar();
                ObjetosNivel_3.SetActive(true);
                break;

            case 4:
                numParaSumar = random.Next(1, 254); //numero del 1 al 100
                ObjetosNivel_4.GetComponent<ObjetosNivel>().reiniciar();
                ObjetosNivel_4.SetActive(true);
                break;

            default:
                break;
        }
    }
}
