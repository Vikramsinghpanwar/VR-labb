using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Mixer : MonoBehaviour
{
    public Text beakerChemicalName;
    int currChemPouring;
    public AudioSource chemPourSound;
    bool isPresent;
    public Text quantityText;
    public float Quantity;
    public int chemPoured;
    bool prdColorInvoke;
    public List<ProductColor> PrdColorList;
    public List<Chemicals> chemList;
    public GameObject pourChemPannel, reactioPannel;
    //public Color Bromine_C, Bromine_Cs, Water_C, Water_Cs, HCL_C, HCL_Cs, NaoH_C, NaoH_Cs;
    public Material BrMaterial;
    //public Material M_Br, M_NaOH, M_H2O, M_HCl;
    //bool pBr, pHCl, pNaOH, pH2O, pFe, pCuSO4;
    float bkQuantity, chQuantity;
    public string chAdded;
    public Text Element1, Element2, ProductElement, ProductElement2;
    public GameObject byProduct_plus_Text;
    public ParticleSystem beakerPS;
    // Start is called before the first frame update
    void Start()
    {
        byProduct_plus_Text.SetActive(false);
        beakerChemicalName.text = "";
        currChemPouring = 0;
        isPresent = false;
        Quantity = 0f;
        chemPoured = 0;
        prdColorInvoke = true;
        pourChemPannel.SetActive(true);
        reactioPannel.SetActive(false);
        for(int i=0; i < chemList.Count; i++)
        {
            chemList[i].chemMaterial.SetFloat("Vector1_2e333aae97a343bf9f8ccc6df1e689df", 1);
            chemList[i]._isAdded = false;
        }
        BrMaterial.SetFloat("Vector1_2e333aae97a343bf9f8ccc6df1e689df", 0);
    }

    // Update is called once per frame
    void Update()
    {
        ////////////////////////////////////////////////////////
        //Debug.Log(chAdded);
        //Debug.Log(chemList.Count);
        if(bkQuantity > 0)
        {
            pourChemPannel.SetActive(false);
            reactioPannel.SetActive(true);
        }
        else if(bkQuantity == 0)
        {
            pourChemPannel.SetActive(true);
            reactioPannel.SetActive(false);
        }
        for (int i = 0; i < chemList.Count; i++)
        {
            if (chemList[i]._isAdded)
            {
                Quantity += 0.1f;
                quantityText.text = ((int)Quantity).ToString() + " ml";
                if (chemPoured == 1)
                {
                    BrMaterial.SetColor("Color_5d9b2948507045b5b3d536f0a1c4dd7b", chemList[i].chemMainColor);
                    BrMaterial.SetColor("Color_514031bec61447c38cbe345a4be91314", chemList[i].chemSec_Color);
                }
                
                bkQuantity = BrMaterial.GetFloat("Vector1_2e333aae97a343bf9f8ccc6df1e689df");
                chQuantity = chemList[i].chemMaterial.GetFloat("Vector1_2e333aae97a343bf9f8ccc6df1e689df");
                if (chQuantity > 0)
                {
                    chQuantity = chQuantity - 0.001f;
                }
                if (bkQuantity <= 1)
                {
                    bkQuantity = bkQuantity + 0.001f;

                }
                
                chemList[i].chemMaterial.SetFloat("Vector1_2e333aae97a343bf9f8ccc6df1e689df", chQuantity);
                BrMaterial.SetFloat("Vector1_2e333aae97a343bf9f8ccc6df1e689df", bkQuantity);
                chemList[i].ps.Play();
            }
            else
            {
                chemList[i].ps.Stop();
            }
        }

        
            if (prdColorInvoke)
            {
                ProductColor();
                //Invoke("ProductColor", 2);
            }
            //prdColorInvoke = false;
        

    }


    public void ProductColor()
    {
        for (int i = 0; i < PrdColorList.Count; i++)
        {
            if (chAdded == PrdColorList[i].chemCode1 || chAdded == PrdColorList[i].chemCode2)
            {
                BrMaterial.SetColor(
            "Color_5d9b2948507045b5b3d536f0a1c4dd7b",
            Color.Lerp(BrMaterial.GetColor("Color_5d9b2948507045b5b3d536f0a1c4dd7b"),
            PrdColorList[i].pColor, 0.2f * Time.deltaTime)
            ) ;

                BrMaterial.SetColor(
            "Color_514031bec61447c38cbe345a4be91314",
            Color.Lerp(BrMaterial.GetColor("Color_514031bec61447c38cbe345a4be91314"),
            PrdColorList[i].sColor, 0.2f * Time.deltaTime)
            );
            }
        }
        prdColorInvoke = true;
    }
   
    public void ProductChecker(string a, string b)
    {
        if (a == "CuSO4" && b == "Fe")
        {
            ProductElement.text = "FeSO4";
            beakerChemicalName.text = "Iron Sulphate";
        }

        if (a == "H2" && b == "O2")
        {
            ProductElement.text = "H2O";
            beakerChemicalName.text = "Water";
        }

        if (a == "H2" && b == "Cl")
        {
            ProductElement.text = "HCl";
            beakerChemicalName.text = "HydroChloric Acid";

        }

        if (a == "N2" && b == "H2")
        {
            ProductElement.text = "NH3";
            beakerChemicalName.text = "Ammonia";

        }

        if (a == "HCl" && b == "Zn")
        {
            ProductElement.text = "ZnCl";
            byProduct_plus_Text.SetActive(true);
            ProductElement2.text = "H2";
            beakerPS.Play();
            Invoke("beakerPsStop", 2);

        }


    }

    public void beakerPsStop()
    {
        beakerPS.Stop();
    }

    public int GetNthIndex(string s, char t, int n)
    {
        int count = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == t)
            {
                count++;
                if (count == n)
                {
                    return i;
                }
            }
        }
        return -1;
    }
     
    public bool IndexChK(string s, char t, int n)
    {
        int c = 0;
        for (int  i = 0; i< s.Length; i++)
        {
            if(s[i] == t)
            {
                c++;
                if(c >= n)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void OnTriggerEnter(Collider other)
    {

        for (int i = 0; i < chemList.Count; i++)
        {
            if (other.gameObject.name == chemList[i].chemName)
            {
                isPresent = false;
                chemPourSound.Play();
                chemPoured++;
                currChemPouring++;
                chemList[i]._isAdded = true;
                if(chemPoured == 1)
                {
                    beakerChemicalName.text = other.gameObject.name;
                }
                if(chemPoured > 1  && chAdded.Length >= other.gameObject.name.Length)
                {
                    for (int j = 0; j < chAdded.Length - other.gameObject.name.Length; j++)
                    {
                        //Debug.Log("Compare" + chAdded.Substring(j, other.gameObject.name.Length ) + "and" + other.gameObject.name);

                       

                        if (chAdded.Substring(j, other.gameObject.name.Length) == other.gameObject.name)
                        { 
                            //Debug.Log("isPresent");
                            isPresent = true;
                            j = chAdded.Length + 5;
                        }
                    }
                }

                if (!isPresent)
                {
                    chAdded = chAdded + chemList[i].chemName + '+';
                }
                //Debug.Log("chAdded =  " + chAdded);

                Element1.text = chAdded.Substring(0, chAdded.IndexOf('+'));
                if (IndexChK(chAdded, '+', 2))
                {
                    Element2.text = chAdded.Substring(GetNthIndex(chAdded, '+', 1) + 1, GetNthIndex(chAdded, '+', 2) - GetNthIndex(chAdded, '+', 1) - 1);                    
                }
                Debug.Log(Element1.text + Element2.text);
                ProductChecker(Element1.text, Element2.text);
                ProductChecker(Element2.text, Element1.text);
            }

        }




    }


    public void OnTriggerExit(Collider other)
    {
        for(int i = 0; i< chemList.Count; i++)
        {

            if (other.gameObject.name == chemList[i].chemName)
            {
                currChemPouring--;
                chemList[i]._isAdded = false;
                if(currChemPouring == 0 )
                {
                    chemPourSound.Stop();
                }
                
            }


        }
       
    }
}

[System.Serializable]
public class Chemicals
{
    public string chemName;
    public ParticleSystem ps;
    [ColorUsageAttribute(true, true, 0f, 8f, 0.125f, 3f)]
    public Color chemMainColor, chemSec_Color;
    public Material chemMaterial;
    public bool _isAdded;
}

[System.Serializable]
public class ProductColor
{
    [ColorUsageAttribute(true, true, 0f, 8f, 0.125f, 3f)]
    public Color pColor, sColor;
    public string chemCode1, chemCode2;
}