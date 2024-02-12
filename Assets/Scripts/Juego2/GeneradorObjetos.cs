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

    // Start is called before the first frame update
    void Start()
    {
        //datos del pez central (alrededor de él se generan el resto de peces
        x = Objeto.transform.position.x;
        y = Objeto.transform.position.y;
        z = Objeto.transform.position.z;

        // asociamos los limites según la posición del pez original cubo de 1 de arista
        minPosition.x = Objeto.transform.position.x - ancho;
        minPosition.y = Objeto.transform.position.y - alto;
        minPosition.z = Objeto.transform.position.z - largo;
        maxPosition.x = Objeto.transform.position.x + ancho;
        maxPosition.y = Objeto.transform.position.y + alto;
        maxPosition.z = Objeto.transform.position.z + largo;


        //inicializacion vector
        Objetos = new GameObject[nobjetos];

        //inicializacion prefab
        for (int i = 0; i < nobjetos; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(minPosition.x, maxPosition.x),
                Random.Range(minPosition.y, maxPosition.y),
                Random.Range(minPosition.z, maxPosition.z)
             );

            Instantiate(Objeto, randomPosition, Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
