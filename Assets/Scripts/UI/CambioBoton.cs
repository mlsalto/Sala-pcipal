using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioBoton : MonoBehaviour
{
    public GameObject ButtonS;
    public GameObject ButtonE;

    public void Cambio()
    {
        if (ButtonS != null)
        {
            ButtonS.SetActive(true);
            ButtonE.SetActive(false);
        }
    }
}
