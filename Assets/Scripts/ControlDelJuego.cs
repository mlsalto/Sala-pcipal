using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class ControlDelJuego : MonoBehaviour
{
   [SerializeField] private TMP_Text textTimer;
   [SerializeField, Tooltip("Tiempo en segundos")] private float timer;

    //Nivel 1
    public  cajacupcakescript cajacup;
    public cajapiruletascript cajapiru;
    public TextMeshProUGUI textoMagdalenaMarcador;
    public TextMeshProUGUI textoPiruletaMarcador;
    public TextMeshProUGUI textofinTiempo;
    public TextMeshProUGUI textoResultadoIncorrecto1;
    public TextMeshProUGUI textoResultadoIncorrecto2;
    public TextMeshProUGUI textoResultadoCorrecto;
    private int piruletaInter;
    private int magdalenaInter;

    //Nivel 2
    public cajagalletascript cajagalle;
    public cajadonascript cajadon;
    public TextMeshProUGUI textoGalletaMarcador;
    public TextMeshProUGUI textoDonaMarcador;
    public TextMeshProUGUI textofinTiempoN2_GD;
    public TextMeshProUGUI textofinTiempoN2_DG;
    public TextMeshProUGUI textoResultadoIncorrecto1N2;
    public TextMeshProUGUI textoResultadoIncorrecto2N2;
    public TextMeshProUGUI textoResultadoCorrectoN2;
    private int galletaInter;
    private int donaInter;

    //Generic
    public Button BotonOpcA;
    public Button BotonOpcB;
    public Button BotonOpcC;
    public TextMeshProUGUI textoPocosObjetosRecolectados;

    public bool tiempoActivo;
    private int minutos;
    private int segundos;
    private int cent;

    // Start is called before the first frame update
    void Start()
    {
        tiempoActivo = true;

    }

    public void ActualizarMagdalenas( int magdalenatotal)
    {
        textoMagdalenaMarcador.text = "Magdalenas: " + magdalenatotal;
    }

    public void ActualizarPiruletas(int piruletatotal)
    {
        textoPiruletaMarcador.text = "Piruletas: " + piruletatotal;
    }

    public void ActualizarGalletas(int galletatotal)
    {
        textoGalletaMarcador.text = "Galletas: " + galletatotal;
    }

    public void ActualizarDonas(int donatotal)
    {
        textoDonaMarcador.text = "Donas: " + donatotal;
    }



    public void FinTiempo()
    {
        textofinTiempo.gameObject.SetActive(true);
        if ((galletaInter - donaInter )> 0)
        {
            textofinTiempoN2_GD.gameObject.SetActive(true);
        }
        else
        {
            textofinTiempoN2_DG.gameObject.SetActive(true);
        }
        BotonOpcA.gameObject.SetActive(true);
        BotonOpcB.gameObject.SetActive(true);
        BotonOpcC.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = 0;
        }
        minutos = (int)(timer / 60f);
        segundos= (int)(timer - minutos * 60f);
        cent= (int)((timer - (int)timer) * 100f);
        textTimer.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, cent);
        if (timer == 0) FinTiempo();
        //Nivel 1
        magdalenaInter = cajacup.contadorcake;
        ActualizarMagdalenas(magdalenaInter);
        piruletaInter = cajapiru.contadorpiruleta;
        ActualizarPiruletas(piruletaInter);
        int total1 = piruletaInter + magdalenaInter - 1;
        int total2 = piruletaInter + magdalenaInter + 2;
        int total = piruletaInter + magdalenaInter;

        //Nivel 2
        galletaInter = cajagalle.contadorgalleta;
        ActualizarGalletas(galletaInter);
        donaInter = cajadon.contadordona;
        ActualizarDonas(donaInter);
        int total1N2 = Mathf.Abs(galletaInter - donaInter - 1);
        int total2N2 = Mathf.Abs(galletaInter - donaInter + 1);
        int totalN2 = Mathf.Abs(galletaInter - donaInter);



        if (0== total && 0 == galletaInter && 0 == donaInter)
        {
            textoPocosObjetosRecolectados.gameObject.SetActive(true);
        }
        else
        {

        //Nivel 1
            textoResultadoIncorrecto1.text = total1.ToString();
            textoResultadoIncorrecto2.text = total2.ToString();
            textoResultadoCorrecto.text = total.ToString();
         //Nivel 2
            textoResultadoIncorrecto1N2.text = total1N2.ToString();
            textoResultadoIncorrecto2N2.text = total2N2.ToString();
            textoResultadoCorrectoN2.text = totalN2.ToString();
        }
    }

           
}
