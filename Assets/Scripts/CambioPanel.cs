using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioPanel : MonoBehaviour
{
    public GameObject Panel;

    public void Cambio()
    {
        if (Panel != null)
        {
            Panel.SetActive(true);
        }
    }
}
