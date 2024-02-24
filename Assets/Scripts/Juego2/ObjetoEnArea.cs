using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjetoEnArea : MonoBehaviour
{

    public GameObject objetoCentral;
    public BoxCollider objetoCollider;


    private float ancho;
    private float largo;
    private float alto;

    private Vector3 posicionCentral;

    private int i; //numero de numeros 
    private int[] vectorNum;
    private int suma;

    void Start()
    {
        // variables para cuentas
        i = 0;
        suma = 0;
        vectorNum = new int[20];

        //variables de posicion de objetos
        posicionCentral = objetoCentral.transform.position;
        ancho = objetoCollider.size.x;
        largo = objetoCollider.size.y;
        alto = objetoCollider.size.z;
    }

    //  si entra algo en el cuadrado //
    private void OnTriggerEnter(Collider collider)
    {
        sumaObjetosArea(true, collider);
    }

    //  si sale algo del cuadrado //
    private void OnTriggerExit(Collider collider)
    {      
        sumaObjetosArea(false, collider);
    }

    private void sumaObjetosArea(bool isuma, Collider collider)
    {
        // si es suma
        if(isuma == true) 
        {

            //** FUNCION DE SUMA **//

            suma = 0;
 
            vectorNum[i] = int.Parse(collider.gameObject.tag);

            for (int a = 0; a <= i; a++)
            {
                suma += vectorNum[a];
            }

            i++;
        }

        // si es resta
        else if (isuma == false)
        {

            //** FUNCION DE RESTA **//

            int a = 0;

            for (a = 0; a <= i - 1; a++)
            {
                if (vectorNum[a] == int.Parse(collider.gameObject.tag))
                {
                    // en el caso de que solo haya un numero
                    if (a == 0 && i == 1)
                    {
                        i--;
                        suma = 0;
                        vectorNum[a] = 0;
                        return;
                    }

                    //en el resto de casos
                    else {
                        Debug.Log("num encontrado");
                        // Retroceder los valores en la posición dada
                        for (int b = a; b <= i - 2; b++)
                        {
                            vectorNum[b] = vectorNum[b + 1];
                        }


                        // hacemos los calculos quitando el numero que hemos quitado
                        i--;

                        for (int c = 0; c <= i; c++)
                        {
                            suma += vectorNum[c];
                        }

                        return;
                    }

                }
            }

        }
    }

    bool CheckObjectsInsideRectangle(Vector3 position)
    {
        // distancia entre el objeto central y el collider que entra/sale
        float deltaX = Mathf.Abs(position.x - posicionCentral.x);
        float deltaY = Mathf.Abs(position.y - posicionCentral.y);
        float deltaZ = Mathf.Abs(position.z - posicionCentral.z);

        if (deltaX <= ancho && deltaY <= largo && deltaZ <= alto) {
            return true;
        }
        else return false;
    }

    public void reiniciar()
    {
        i = 0;
        suma = 0;
        vectorNum = new int[20];
    }

    public int[] vectNumeros
    {
        get
        {
            return vectorNum;
        }
    }

    public int numPecesIn
    {
        get
        {
            return i;
        }
    }

    public int sumaTot
    {
        get
        {
            return suma;
        }
    }
}
