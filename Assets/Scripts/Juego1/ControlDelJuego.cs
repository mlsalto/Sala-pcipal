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

    public  cajacupcakescript cajacup;
    public cajapiruletascript cajapiru;
    public GameObject SUMADOR;

    public TextMeshProUGUI textoMagdalenaMarcador;
    public TextMeshProUGUI textoPiruletaMarcador;
    public TextMeshProUGUI textofinTiempo;
    public TextMeshProUGUI textoPocosObjetosRecolectados;
    public TextMeshProUGUI textoResultadoIncorrecto1;
    public TextMeshProUGUI textoResultadoIncorrecto2;
    public TextMeshProUGUI textoResultadoCorrecto;

    public Button BotonOpcA;
    public Button BotonOpcB;
    public Button BotonOpcC;

    public int total1;
    public int total2;
    public int total;

    public bool tiempoActivo;
    private int piruletaInter;
    private int magdalenaInter;
    private int minutos;
    private int segundos;
    private int cent;

    private bool fin;
    private float timerf;
    // Start is called before the first frame update
    void Start()
    {
        tiempoActivo = true;
        fin = false;
        timerf = 0.0f;

    }

    public void ActualizarMagdalenas( int magdalenatotal)
    {
        textoMagdalenaMarcador.text = "Magdalenas: " + magdalenatotal;
    }

    public void ActualizarPiruletas(int piruletatotal)
    {
        textoPiruletaMarcador.text = "Piruletas: " + piruletatotal;
    }

    public void FinTiempo()
    {
        
        if (total1 <= 0)
        {
            textoPocosObjetosRecolectados.gameObject.SetActive(true);
        }
        else
        {
            textofinTiempo.gameObject.SetActive(true);
            BotonOpcA.gameObject.SetActive(true);
            BotonOpcB.gameObject.SetActive(true);
            BotonOpcC.gameObject.SetActive(true);
            textoResultadoIncorrecto1.text = total1.ToString();
            textoResultadoIncorrecto2.text = total2.ToString();
            textoResultadoCorrecto.text = total.ToString();
            SUMADOR.SetActive(true);
            
        }

        fin = true;
    }

    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SalaPcipal");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // cambio escena
        if (fin == true)
        {
            timerf += Time.deltaTime;
            if (timerf > 10)
            {
                StartCoroutine(LoadYourAsyncScene());
            }
        }

        // cosas del juego
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = 0;
        }
        minutos = (int)(timer / 60f);
        segundos= (int)(timer - minutos * 60f);
        cent= (int)((timer - (int)timer) * 100f);
        textTimer.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, cent);
        if (timer == 0)
        { FinTiempo(); }
        else
        {
            magdalenaInter = cajacup.contadorcake;
            ActualizarMagdalenas(magdalenaInter);
            piruletaInter = cajapiru.contadorpiruleta;
            ActualizarPiruletas(piruletaInter);
            total1 = piruletaInter + magdalenaInter - 1;
            total2 = piruletaInter + magdalenaInter + 2;
            total = piruletaInter + magdalenaInter;
        }
       
    }
}
