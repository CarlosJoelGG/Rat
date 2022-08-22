using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void animar()
    {
        if (!StaticVariables.iniciar)
        {
            GetComponent<Animator>().Play("inicio");
            StaticVariables.iniciar = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
