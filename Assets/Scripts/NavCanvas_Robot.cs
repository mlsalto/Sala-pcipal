using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavCanvas_Robot : MonoBehaviour
{

    public Transform PosRobot;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {

        if (PosRobot != null)
        {
            transform.position = PosRobot.position + new Vector3(0.0f, 1.5f, 0.0f);
        }
    }
}
