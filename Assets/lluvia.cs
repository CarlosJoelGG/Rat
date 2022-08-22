using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lluvia : MonoBehaviour
{
    public float tiempoM;
    public List<GameObject> objetosM;
    public bool a=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        if ((StaticVariables.AT <= tiempoM) && !a)
        {
            a = true;
            for (int i = 0; i < objetosM.Count; i++)
            {
                objetosM[i].SetActive(true);
            }
        }
    }
}
