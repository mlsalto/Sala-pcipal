using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjetos : MonoBehaviour
{
    public int nobjetos;
    public GameObject Objeto;

    public float ancho;
    public float alto;
    public float largo;
    

    private Vector3 minPosition;
    private Vector3 maxPosition;

    private GameObject[] Objetos;

    private float x; // centro de rotacion x
    private float y; // centro de rotacion y
    private float z; // centro de rotacion z

    private Vector3 posini;

    // Start is called before the first frame update
    void Start()
    {
        //datos del pez central (alrededor de él se generan el resto de peces)
        x = Objeto.transform.position.x;
        y = Objeto.transform.position.y;
        z = Objeto.transform.position.z;

        // pos ini 
        posini = Objeto.transform.position;

        //inicializacion vector
        Objetos = new GameObject[nobjetos];

        reiniciar();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void eliminarObjetosDinamicos()
    {
        // eliminas los objetos dinamicos
        for (int i = 0; i < nobjetos; i++)
        {
            Destroy(Objetos[i]);
        }

        // colocas el objeto inicial
        //Objeto.transform.position = posini;
       
        //iniciarObjetos();

    }

    public void reiniciar()
    {
        //Objeto.transform.position = posini;

        // asociamos los limites según la posición del pez original cubo de 1 de arista
        minPosition.x = posini.x - ancho;
        minPosition.y = posini.y - alto;
        minPosition.z = posini.z - largo;
        maxPosition.x = posini.x + ancho;
        maxPosition.y = posini.y + alto;
        maxPosition.z = posini.z + largo;

        //inicializacion prefab
        for (int i = 0; i < nobjetos; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(minPosition.x, maxPosition.x),
                Random.Range(minPosition.y, maxPosition.y),
                Random.Range(minPosition.z, maxPosition.z)
             );

            Objetos[i] = Instantiate(Objeto, randomPosition, Quaternion.identity);
        }
    }
}
