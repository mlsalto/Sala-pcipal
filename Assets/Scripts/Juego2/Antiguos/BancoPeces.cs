using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BancoPeces : MonoBehaviour
{
    public int npeces;
    public GameObject Pez;

    //
    private Vector3 minPosition;
    private Vector3 maxPosition;
    //public GameObject[npeces] peces;
    // peces = new GameObject[npeces];
    //GameObject[] peces = new GameObject[npeces];

    private GameObject[] peces;

    private float x; // centro de rotacion x
    private float y; // centro de rotacion y
    private float z; // centro de rotacion z

    // Start is called before the first frame update
    void Start()
    {
        //datos del pez central (alrededor de él se generan el resto de peces
        x = Pez.transform.position.x;
        y = Pez.transform.position.y;
        z = Pez.transform.position.z;

        // asociamos los limites según la posición del pez original cubo de 1 de arista
        minPosition.x = Pez.transform.position.x - 0.5f; 
        minPosition.y = Pez.transform.position.y - 0.5f;
        minPosition.z = Pez.transform.position.z - 0.5f;
        maxPosition.x = Pez.transform.position.x + 0.5f;
        maxPosition.y = Pez.transform.position.y + 0.5f;
        maxPosition.z = Pez.transform.position.z + 0.5f;


        //inicializacion vector
        peces = new GameObject[npeces];

        //inicializacion prefab
        for (int i = 0; i < npeces; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(minPosition.x, maxPosition.x),
                Random.Range(minPosition.y, maxPosition.y),
                Random.Range(minPosition.z, maxPosition.z)
             );

            Instantiate(Pez, randomPosition, Quaternion.identity);
        }
    }
            // Update is called once per frame
    void Update()
    {
        
    }   

    //static void CreateRandomPoints()
    //{
    //    for (int i = 0; i < numberOfPoints; i++)
    //    {
    //        double x = GetRandomDouble(minX, maxX);
    //        double y = GetRandomDouble(minY, maxY);
    //        double z = GetRandomDouble(minZ, maxZ);
    //    }
    //}

    //static float GetRandomFloat(float min, float max)
    //{
    //    return min + (max - min) * (float)random.NextDouble();
    //}
}
