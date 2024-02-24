using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosNivel : MonoBehaviour
{
    public List<GameObject> listaDeGameObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void eliminarObjetosDinamicos()
    {
        foreach (GameObject obj in listaDeGameObjects)
        {
            if (obj.tag == "conjunto")
            {
                obj.GetComponent<GeneradorObjetos>().eliminarObjetosDinamicos();
            }
        }
    }

    public void reiniciar()
    {
        foreach (GameObject obj in listaDeGameObjects)
        {
            if (obj.tag == "conjunto")
            {
                obj.GetComponent<GeneradorObjetos>().reiniciar();
            }
            else
            {
                obj.GetComponent<MovimientoPezCirc>().reiniciar();
            }
 
        }
    }

}
