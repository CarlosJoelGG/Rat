using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animarI : MonoBehaviour
{
    public string NombreA;
    public float limiteX;
    public float AX;
    public bool AS = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= limiteX && !AS)
        {
            AS = true;
            GetComponent<Animator>().Play(NombreA);
        }
        AX = transform.position.x;
    }
}
