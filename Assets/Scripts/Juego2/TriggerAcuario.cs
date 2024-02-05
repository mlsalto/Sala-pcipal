using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAcuario : MonoBehaviour
{
    // Start is called before the first frame update
    public int contador;
    private int i; //numero de numeros 
    private int[] vectorNum;
    private int suma;
    //private int[] vectorNum = { 1, 2, 3, 4, 5 };

    void Start()
    {
        contador = 0;
        i = 0;
        suma = 0;
        //int[] vectorNum = { 1, 2, 3, 4, 5 };
        vectorNum = new int[10];
    }

    // Update is called once per frame
    void Update()
    {

    }

    //En el caso de que detecte colision pues añade la suma (y añadri que se ilumine tmb)
    private void OnTriggerEnter(Collider collision)
    {
        //contador = contador + int.Parse(collision.gameObject.tag);
        suma = 0;
        // actualizar el vector de los números (text a numeros)
        vectorNum[i] = int.Parse(collision.gameObject.tag);

        for (int a = 0 ; a <= i; a++)
        {
            suma += vectorNum[a];
        }

        i++;
    }

    //private int suma {  return contador; }
    public int[] vectNumeros { 
        get
        {
            return vectorNum;
        } 
    }
    
    public int numPecesIn {
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
