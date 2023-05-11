using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ElementDetector : MonoBehaviour
{
    public GameObject panelDefault, PannelInfo;
    public Text elementName, atomicNo, color, type, symbol, commonName;
    private GameObject CurrentObj;
    //private TextMeshPro Ename, atomicNo, color, type, commonName;
    // Start is called before the first frame update
    void Start()
    {
        panelDefault.SetActive(true);
        PannelInfo.SetActive(false);

                
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        CurrentObj = other.gameObject;
        panelDefault.SetActive(false);
        if(other.gameObject.name == "Bromine")
        {
            PannelInfo.SetActive(true);
            atomicNo.text = "35";
            color.text = "Reddish Brown";
            type.text = "Element";
            commonName.text = "";
            symbol.text = "Br";
            elementName.GetComponent<TextMeshPro>().text = "Bromine";

        }
        if (other.gameObject.name == "H2O")
        {
            PannelInfo.SetActive(true);
            elementName.text = "Hydrogen DiOxide";
            atomicNo.text = "";
            color.text = "Colourless";
            type.text = "Compound";
            symbol.text = "H2O";
            commonName.text = "Water";
        }
       if(other.gameObject.name == "HCl")
        {
            PannelInfo.SetActive(true);
            elementName.text = "Hydrogen Chloride";
            atomicNo.text = "35";
            color.text = "Colourless";
            type.text = "Compound";
            symbol.text = "HCl";
            commonName.text = "HydroChloric Acid";
        }
       if(other.gameObject.name == "NaoH")
        {
            PannelInfo.SetActive(true);
            elementName.text = "Sodium Hydroxide";
            atomicNo.text = "";
            color.text = "Colourless";
            type.text = "Compound";
            symbol.text = "NaOH";
            commonName.text = "Sodium Hydroxide";
        }
       
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == CurrentObj)
        {
            panelDefault.SetActive(true);
            PannelInfo.SetActive(false);
        }
    }
}

