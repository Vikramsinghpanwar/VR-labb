using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnerBoiler : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem beakerParticeStystem;
    void Start()
    {
        beakerParticeStystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponentInChildren<ParticleSystem>().Stop();
        if (other.gameObject.name == "Br")
        {
            other.gameObject.GetComponentInChildren<ParticleSystem>().Play();
        }
        
        if(other.gameObject.name == "Beaker")
        {
            other.gameObject.GetComponentInChildren<ParticleSystem>().Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponentInChildren<ParticleSystem>().Stop();
        if(other.gameObject.name == "Beaker")
        {
            beakerParticeStystem.Stop();
        }
    }
}
