using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasPS : MonoBehaviour
{
    
    public GameObject Dart;
    public ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == Dart)
        {
            ps.Play();
        }
        Dart.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<AudioSource>().Play();
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Dart)
        {
            ps.Stop();
        }
        Dart.GetComponent<Rigidbody>().isKinematic = true;
    }
}
