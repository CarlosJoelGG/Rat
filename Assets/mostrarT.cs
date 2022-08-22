using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mostrarT : MonoBehaviour
{
    public int tiempo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticVariables.AT <= tiempo)
        {
            gameObject.SetActive(false);
        }
    }
}
