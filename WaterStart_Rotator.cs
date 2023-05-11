using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterStart_Rotator : MonoBehaviour
{
    public ParticleSystem pRSystem;
    public Transform rb;
    // Start is called before the first frame update
    void Start()
    {
        //rb = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.rotation.y > 0.1f)
        {
            pRSystem.Play();
            pRSystem.emissionRate = rb.rotation.y * 100f;
        }
        else pRSystem.Stop();
    }
}
