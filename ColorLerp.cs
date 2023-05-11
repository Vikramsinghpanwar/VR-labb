using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerp : MonoBehaviour
{
    [SerializeField] [Range(0, 10f)] float lerpTime;
    public Material mat_real;
    [ColorUsageAttribute(true, true)]
    public Color sColor;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        mat_real.SetColor(
            "Color_5d9b2948507045b5b3d536f0a1c4dd7b",
            Color.Lerp(mat_real.GetColor("Color_5d9b2948507045b5b3d536f0a1c4dd7b"),
            sColor, lerpTime * Time.deltaTime)
            );
    }
}
