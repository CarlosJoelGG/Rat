using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ocultar : MonoBehaviour
{ public float x =0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = transform.position.x;
        if (x < -48.4f)
        {
            Destroy(gameObject);
        }
        if (GetComponent<SpriteRenderer>().enabled)
            if (x > 28.6f)
            {
                GetComponent<SpriteRenderer>().enabled = false;
            }
        if (x <= 28.6f && !GetComponent<SpriteRenderer>().enabled)
            GetComponent<SpriteRenderer>().enabled = true;
    }
}
