using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Manipulation;
using UnityEngine.SceneManagement;


public class J2Demo : MonoBehaviour
{
    public UxrGrabbableObjectAnchor altar1;
    public UxrGrabbableObjectAnchor altar2;
    public UxrGrabbableObjectAnchor altar3;

    private bool alt1on;
    private bool alt2on;
    private bool alt3on;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        alt1on = false;
        alt2on = false;
        alt3on = false;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        altar1.Placed += ObjetoColocado1;
        altar2.Placed += ObjetoColocado2;
        altar3.Placed += ObjetoColocado3;

        if (alt1on == true && alt2on == true && alt3on == true)
        {
            timer += Time.deltaTime;
            if (timer > 5)
            {
                StartCoroutine(LoadYourAsyncScene());
            }
        }
    }


    void ObjetoColocado1(object sender, UxrManipulationEventArgs e)
    {
        alt1on = true;
    }


    void ObjetoColocado2(object sender, UxrManipulationEventArgs e)
    {
        alt2on = true;
    }


    void ObjetoColocado3(object sender, UxrManipulationEventArgs e)
    {
        alt3on = true;
    }


    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SalaPcipal");

        while (!asyncLoad.isDone )
        {
            yield return null;
        }
    }
}
