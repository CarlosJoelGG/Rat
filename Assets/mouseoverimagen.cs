using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class mouseoverimagen : MonoBehaviour
     , IPointerEnterHandler
     , IPointerExitHandler
{
    public GameObject sombra;

    public void OnPointerEnter(PointerEventData eventData)
    {
        sombra.GetComponent<Animator>().Play("boton");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        sombra.GetComponent<Animator>().Play("Idle");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
