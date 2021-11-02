using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralTools : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Color SetAlpha(Color color)
    {
        Color colorAlpha = color;
        color.a = 0.1f;
        return color;
    }
}
