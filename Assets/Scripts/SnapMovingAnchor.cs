using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Manipulation;

public class SnapMovingAnchor : MonoBehaviour
{
    public UxrGrabbableObjectAnchor frame;
    public UxrGrabbableObject objeto;

    private bool colocado;

    // Start is called before the first frame update
    void Start()
    {
        colocado = false;
    }

    // Update is called once per frame
    void Update()
    {
        frame.Placed += ObjetoColocado;
        if (colocado == true)
        {
        }

    }


    void ObjetoColocado(object sender, UxrManipulationEventArgs e)
    {
        colocado = true;
        //contador = Time.deltaTime;
    }
}
