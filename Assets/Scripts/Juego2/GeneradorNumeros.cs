using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GeneradorNumeros : MonoBehaviour
{
    public TextMeshPro mText_1;
    public TextMeshPro mText_2;
    public int numero = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.tag = numero.ToString();
        mText_1.SetText(numero.ToString()); 
        mText_2.SetText(numero.ToString()); 
    }

}
