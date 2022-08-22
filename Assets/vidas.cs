using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vidas : MonoBehaviour
{
    public Text a;
    public int actualvida=0;
    // Start is called before the first frame update
    void Start()
    {
       
            actualvida = StaticVariables.vidas;
        a.text = "x " + StaticVariables.vidas;
    }

    // Update is called once per frame
    void Update()
    {
        if (actualvida != StaticVariables.vidas)
        {
            GetComponent<Animator>().Play("vidasmenos");

            actualvida= StaticVariables.vidas;
            a.text = "x " + StaticVariables.vidas;
        }
    }
}
