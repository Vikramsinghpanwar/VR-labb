using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.

public class Chemical_flask : MonoBehaviour
{
    public float spd = 10f, chQuantity, bkQuantity;
    public Material BeakerChemical_material;
    public ParticleSystem Pouring_particleSystem;
    public SphereCollider SphCollidor;
    public Transform trans;
    private bool pour, readyToPour;
    public Material chemicalMaterial;
    // Start is called before the first frame update
    void Start()
    {
        chemicalMaterial.SetFloat("Vector1_2e333aae97a343bf9f8ccc6df1e689df", 1f);
        readyToPour = false;
        pour = false;     

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(trans.rotation.y);
        //Debug.Log(trans.rotation.x);
        if (trans.rotation.x > 0.05f || trans.rotation.z > 0.05f)
        {
            //Debug.Log("StartedPouring");
            pour = true;
        }
        else pour = false;
        if (readyToPour == true && pour)
        {
            bkQuantity = BeakerChemical_material.GetFloat("Vector1_2e333aae97a343bf9f8ccc6df1e689df");
            chQuantity = chemicalMaterial.GetFloat("Vector1_2e333aae97a343bf9f8ccc6df1e689df");
            if (Pouring_particleSystem)
            {
                //Debug.Log("Particlesystem True hai");
            }
            Pouring_particleSystem.Play();
            if (chQuantity > 0)
            {
                chQuantity = chQuantity - 0.001f;
            }
            if (bkQuantity <= 1)
            {
                bkQuantity = bkQuantity + 0.001f;

            }
            //Debug.Log(chQuantity);
            chemicalMaterial.SetFloat("Vector1_2e333aae97a343bf9f8ccc6df1e689df", chQuantity);
            BeakerChemical_material.SetFloat("Vector1_2e333aae97a343bf9f8ccc6df1e689df", bkQuantity);

            //float ter = Mathf.Lerp(1f, 0f , Time.deltaTime * spd);
            //chemicalMaterial.SetFloat("Vector1_2e333aae97a343bf9f8ccc6df1e689df", ter);

            //Debug.Log(chemicalMaterial.GetFloat("Vector1_2e333aae97a343bf9f8ccc6df1e689df"));



        }
        else
        {
            Pouring_particleSystem.Stop();
        }

    }

    private void OnTriggerEnter(Collider other)
    {    
        if(other.gameObject.tag == "Mixer")
        {
            //Debug.Log("TriggerEnteredToMixerBeaker");
            readyToPour = true;            
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Mixer")
        {
            //Debug.Log("TriggerExit");
            readyToPour = false;
        }
    }
}
