using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class ControlDelJuego1_N2 : MonoBehaviour
{
   [SerializeField] private TMP_Text textTimer;
   [SerializeField, Tooltip("Tiempo en segundos")] private float timer;

    //Nivel 2
    public cajagalletascript cajagalle;
    public cajadonascript cajadon;
    public TextMeshProUGUI textoGalletaMarcador;
    public TextMeshProUGUI textoDonaMarcador;
    public TextMeshProUGUI textofinTiempo;
    public TextMeshProUGUI textoResultadoIncorrecto1;
    public TextMeshProUGUI textoResultadoIncorrecto2;
    public TextMeshProUGUI textoResultadoCorrecto;
    public TextMeshProUGUI textoCorrecto;
    public TextMeshProUGUI textoInorrecto;
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
    private int total1;
    private int total2;
    private int total;
    //public GameObject musicaFondo;
    //private GameObject clone;

    // Start is called before the first frame update
    void Start()
    {
        tiempoActivo = true;
        //clone = Instantiate(musicaFondo);
    }


    public void ActualizarGalletas(int galletatotal)
    {
        textoGalletaMarcador.text = "Galletas: " + galletatotal;
    }

    public void ActualizarDonas(int donatotal)
    {
        textoDonaMarcador.text = "Donas: " + donatotal;
    }



    public void FinTiempo(int total, int total1, int total2, int galletaInter, int donaInter)
    {
        //GameObject.Destroy(clone);
        textofinTiempo.gameObject.SetActive(true);
        if ((0==galletaInter) && (0==donaInter))
        {
            textoPocosObjetosRecolectados.gameObject.SetActive(true);
            Invoke("MyFunction", 3);
            SceneManager.LoadScene("SalaPcipal");
        }
    
        else 
        {
            if (galletaInter > donaInter)
            {
                textofinTiempo.text = "¡Es turno de la resta!\nResta el número de galletas y donas que marcan las cajas y pulsa la respuesta correcta: " + galletaInter + " - " + donaInter;

            }
            else
            {
                textofinTiempo.text = "¡Es turno de la resta!\nResta el número de donas y galletas que marcan las cajas y pulsa la respuesta correcta: " + donaInter + " - " + galletaInter;

            }
            textoResultadoIncorrecto1.text = total1.ToString();
            textoResultadoIncorrecto2.text = total2.ToString();
            textoResultadoCorrecto.text = total.ToString();
            textofinTiempo.gameObject.SetActive(true);
            BotonOpcA.gameObject.SetActive(true);
            BotonOpcB.gameObject.SetActive(true);
            BotonOpcC.gameObject.SetActive(true);
        }
        

        if (textoCorrecto.gameObject.activeInHierarchy)
        {
            textofinTiempo.gameObject.SetActive(false);
            BotonOpcA.gameObject.SetActive(false);
            BotonOpcB.gameObject.SetActive(false);
            BotonOpcC.gameObject.SetActive(false);
            Invoke("MyFunction", 3);
            SceneManager.LoadScene("SalaPcipal");
        }

        else if (textoInorrecto.gameObject.activeInHierarchy)
        {
            textofinTiempo.gameObject.SetActive(false);
            BotonOpcA.gameObject.SetActive(false);
            BotonOpcB.gameObject.SetActive(false);
            BotonOpcC.gameObject.SetActive(false);
            Invoke("MyFunction", 3);
            SceneManager.LoadScene("SalaPcipal");
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = 0;
        }
        if (timer != 0)
        {
            minutos = (int)(timer / 60f);
            segundos = (int)(timer - minutos * 60f);
            cent = (int)((timer - (int)timer) * 100f);
            textTimer.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, cent);
            //Nivel 2
            galletaInter = cajagalle.contadorgalleta;
            ActualizarGalletas(galletaInter);
            donaInter = cajadon.contadordona;
            ActualizarDonas(donaInter);
            total1 = Mathf.Abs(galletaInter - donaInter - 1);
            total2 = Mathf.Abs(galletaInter - donaInter + 1);
            total = Mathf.Abs(galletaInter - donaInter);

        }
        else if (timer == 0)
        {
            textTimer.text = string.Format("{0:00}:{1:00}:{2:00}", 0, 0, 0);
            FinTiempo(total, total1, total2, galletaInter, donaInter);
        }
    }


    void MyFunction()
    {
        Debug.Log("Cambiando Escena");
    }


}
