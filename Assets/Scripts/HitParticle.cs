using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticle : MonoBehaviour
{
    public ParticleSystem[] particleSystems; 

    void Start()
    {
        PlayAllParticleSystems();
    }

    void Update()
    {
        //if (AllSystemsStopped())
        //{
        //    Destroy(this.gameObject);
        //}
    }

    public void PlayAllParticleSystems()
    {
        foreach (var p in particleSystems)
        {
            p.Play(); 
        }
    }

    //bool AllSystemsStopped()
    //{
    //    foreach (var p in particleSystems)
    //    {
    //        if (p.isPlaying)
    //        {
    //            return false;
    //        }    
    //    }
    //    return true;
    //}
}
