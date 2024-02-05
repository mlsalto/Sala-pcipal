using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;


//***   EN EL NIVEL 1 SÓLO SE HARÁN SUMAS DE 1 EN 1 HASTA EL NÚMERO 10   ***//

public class J2Nivel_1 : MonoBehaviour
{
    [SerializeField] private TMP_Text texto;

    //private int[] vectorNum = { 1, 2, 3, 4, 5 };
    private bool start;
    private int numParaSumar;
    public TriggerAcuario acuario;
    public GameObject botonE;

    // Start is called before the first frame update
    void Start()
    {
        // creamos un numero aleatorio para el que tenemos que sumar  //
        System.Random random = new System.Random();
        numParaSumar = random.Next(1, 11); //numero del 1 al 10
        start = false;
        botonE.SetActive(true);
        texto.text = "El mar se está quedando sin peces por la contaminación. \n ¡¡¡¡ Ayudame a repoblarlos sumando !!!!";
    }

    // Update is called once per frame
    void Update()
    {
        //IF LE DAN A OK EN EL MENÚ ANTERIOR HAZ LO SIGUIENTE:
        //El numero del nivel 1 es de 1-10, nivel 2 10-99, nivel 3 99-999, (solo con dec, cent, uni) 
        // suma
        //vectorNum = acuario.vectorNum;
        if (start == true)
        {
            botonE.SetActive(false);
            texto.text = "Suma los peces para conseguir el número " + numParaSumar.ToString() + "\n \n" + ConvertirVectorATexto(acuario.vectNumeros, acuario.numPecesIn);

            if (numParaSumar == acuario.sumaTot)
            {
                texto.text = "Suma los peces para conseguir el número " + numParaSumar.ToString() + "\n \n" + ConvertirVectorATexto(acuario.vectNumeros, acuario.numPecesIn) + "\n \n" + "CORRECTO  :)";
            }

            else if (numParaSumar < acuario.sumaTot)
            {
                texto.text = "Suma los peces para conseguir el número " + numParaSumar.ToString() + "\n \n" + ConvertirVectorATexto(acuario.vectNumeros, acuario.numPecesIn) + "\n \n" + "INCORRECTO  :(";
            }
        }
    }

    // funcion para empezar juego 

    public void empezarJuego()
    {
        start = true;
    }

    // Funcion que convierte el vector de numeros a texto
    static string ConvertirVectorATexto(int[] vector, int size)
    {
        StringBuilder textoTmp = new StringBuilder();
        int suma = 0;

        // Verificar si el vector tiene elementos
        if (vector.Length > 0)
        {
            // Agregar el primer elemento
            textoTmp.Append(vector[0]);
            suma = vector[0];

            // Agregar los demás elementos con el formato "+ elemento"
            for (int i = 1; i < size; i++)
            {
                textoTmp.Append(" + " + vector[i]);
                suma += vector[i];
            }

            // Agregar la suma
            textoTmp.Append(" = " + suma);
        }

        return textoTmp.ToString();
    }
}
