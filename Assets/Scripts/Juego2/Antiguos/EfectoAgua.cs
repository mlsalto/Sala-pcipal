using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class EfectoAgua : MonoBehaviour
{

    public float fps = 30.0f;         //footage fps
    public Texture2D[] frames;      //caustics images

    private int frameIndex;
    private DecalProjector projector;    //Projector GameObject

    void Start()
    {
        projector = GetComponent<DecalProjector>();
        NextFrame();
        InvokeRepeating("NextFrame", 1 / fps, 1 / fps);
    }

    void NextFrame()
    {
        projector.material.SetTexture("_DecalTex", frames[frameIndex]);
        frameIndex = (frameIndex + 1) % frames.Length;
    }

    //private DecalProjector _decalProjector;

    //void Awake()
    //{
    //    _decalProjector = GetComponent<DecalProjector>();
    //}

    //void LateUpdate()
    //{
    //    _decalProjector.material.SetTexture
    //}
}
