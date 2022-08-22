using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iniciarescena : MonoBehaviour
{
    public GameObject vaca,raton,puerta1,puerta2,musica,Hud,HudStart,FN,HudEnd;
    public bool contar = false;
    public float tiempo = 0,cro=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void IC()
    {
        contar = true;
        FN.GetComponent<Animator>().Play("fondoNoscurecer");
    }
    public void Iniciar()
    {
        vaca.GetComponent<Animator>().Play("comiendo");
        //pollo.GetComponent<Animator>().Play("");
        raton.GetComponent<Animator>().Play("New State");
        puerta1.GetComponent<Animator>().Play("St");
        puerta2.GetComponent<Animator>().Play("New State");
        FN.GetComponent<Animator>().Play("fondoNaclarar");
        musica.SetActive(true);
        Hud.SetActive(true);
        HudStart.SetActive(false);
    }
    public void lastHud()
    {
        Hud.SetActive(false);
        HudEnd.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {if (StaticVariables.gameover)
        {
            lastHud();
        }
        if (contar)
        {
            tiempo = tiempo + Time.deltaTime;
            if (tiempo >= cro)
            {
                contar = false;
                Iniciar();
                tiempo = 0;
            }
        }
    }
}
