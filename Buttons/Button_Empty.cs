using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button_Empty : MonoBehaviour
{
    public Mixer mixScript;
    //public GameObject beaker;
    public Material BeakerChemical_material, H2O_material;
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    public GameObject presser;
    bool isPressed;
    public Mixer mixerScript;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
        mixerScript = FindObjectOfType<Mixer>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(!isPressed)
        {
            button.transform.localPosition -= new Vector3(0, 0.01f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == presser)
        {
            button.transform.localPosition += new Vector3(0, 0.01f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void EmptyBeaker()
    {
        mixerScript.byProduct_plus_Text.SetActive(false);
        mixerScript.beakerChemicalName.text = "";
        mixerScript.Quantity = 0f;
        mixerScript.chemPoured = 0;
        BeakerChemical_material.SetFloat("Vector1_2e333aae97a343bf9f8ccc6df1e689df", 0f);
        H2O_material.SetFloat("Vector1_2e333aae97a343bf9f8ccc6df1e689df", 1f);
        mixerScript.chAdded = "";
        mixerScript.Element1.text = "";
        mixerScript.Element2.text = "";
        mixerScript.ProductElement.text = "";

    }
}
