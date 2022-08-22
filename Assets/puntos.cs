using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puntos : MonoBehaviour
{
    public int index = 0;
    public Text Punto;
    // Start is called before the first frame update
    void Start()
    {
        Punto.text = StaticVariables.score+"";
    }

    // Update is called once per frame
    void Update()
    {
        if (index != StaticVariables.score)
        {
            Punto.text = StaticVariables.score + "";
            index = StaticVariables.score;
        }
    }
}
