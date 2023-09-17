using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BancoPeces : MonoBehaviour
{
    public int npeces;
    public GameObject pez;
    public Vector3 minPosition;
    public Vector3 maxPosition;
    //public GameObject[npeces] peces;
    // peces = new GameObject[npeces];
    //GameObject[] peces = new GameObject[npeces];

    private GameObject[] peces;


    // Start is called before the first frame update
    void Start()
    {
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

            Instantiate(pez, randomPosition, Quaternion.identity);
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
