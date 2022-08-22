using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    public Vector3 M;
    public float velocidad=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        M = transform.position;
        if (GetComponent<SpriteRenderer>().enabled)
        {
            transform.position = new Vector3(M.x+ (velocidad * Time.deltaTime), M.y, M.z);
        }
    }
}
