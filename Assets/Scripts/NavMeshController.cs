using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    public Transform objetivo;
    NavMeshAgent agent = null;
    Animator anim;

    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
       anim = GetComponent<Animator>();
    }

    void Update()
    {
        agent.destination = objetivo.position + new Vector3(1.5f, 0.0f, 1.5f);
        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        float speed;
        speed = agent.velocity.magnitude;
        speed = Mathf.Clamp01(speed);
        anim.SetFloat("Speed", speed, 0.1f, Time.deltaTime);
    }
}
