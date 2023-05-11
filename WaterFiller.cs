using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFiller : MonoBehaviour
{
    public Material ChMaterial;
    public Color waterColor, sWaterColor;
    bool fill;
    float bkQuantity;
    // Start is called before the first frame update
    void Start()
    {
        fill = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(fill)
        {
            if(bkQuantity == 0)
            {
               
                if (bkQuantity <= 1)
                {
                    ChMaterial.SetColor("Color_5d9b2948507045b5b3d536f0a1c4dd7b", waterColor);
                    ChMaterial.SetColor("Color_514031bec61447c38cbe345a4be91314", sWaterColor);
                    bkQuantity = ChMaterial.GetFloat("Vector1_2e333aae97a343bf9f8ccc6df1e689df");
                    bkQuantity = bkQuantity + 0.001f;
                    ChMaterial.SetFloat("Vector1_2e333aae97a343bf9f8ccc6df1e689df", bkQuantity);


                }
            }
            else if(bkQuantity < 0)
            {
                if (bkQuantity <= 1)
                {
                    bkQuantity = ChMaterial.GetFloat("Vector1_2e333aae97a343bf9f8ccc6df1e689df");
                    bkQuantity = bkQuantity + 0.001f;
                    ChMaterial.SetFloat("Vector1_2e333aae97a343bf9f8ccc6df1e689df", bkQuantity);


                }
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Beaker")
        {
            fill = true;
            

        }
    }
}
