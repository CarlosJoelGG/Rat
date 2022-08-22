using System;
using UnityEngine;
using UnityEngine.UI;

public class cronometro : MonoBehaviour
{
    public Text temporizador;
    public string segundos;
    public int TM = 10;
    public float ActualTime = 0, T = 0;
    public int h = 0, m = 0, s = 0, ov = 0;

    // Start is called before the first frame update
    void Start()
    {
        Iniciar();
    }
    public void Iniciar()
    {
      
        StaticVariables.Tiempo = 150;
        ActualTime = 0;
        TM = 10;
        ov = (60 - StaticVariables.minutos);
        
        h = 0; m = 0; s = 0;
    }
    public void mostrar()
    {
        //Debug.Log(mostrarseg()+"");
        int min, seg;
        // min = Convert.ToInt32(Math.Floor((StaticVariables.Tiempo - mostrarseg()) / 60f));
        //seg = Convert.ToInt32(Math.Floor((StaticVariables.Tiempo - mostrarseg()) - (60 * min)));
        min = Convert.ToInt32(Math.Floor((StaticVariables.Tiempo - T) / 60f));
        seg = Convert.ToInt32(Math.Floor((StaticVariables.Tiempo - T) - (60 * min)));
        if (seg < 10)
            segundos = "0" + seg;
        else
            segundos = "" + seg;
        StaticVariables.AT = (min * 60) + seg;
        temporizador.text = min + ":" + segundos;
       
    }
    // Update is called once per frame
    public int mostrarseg()
    {


        if (DateTime.UtcNow.Minute > StaticVariables.minutos && DateTime.UtcNow.Second >= StaticVariables.seg)
        {
            m = DateTime.UtcNow.Minute - StaticVariables.minutos;
        }
        else
        {

            if (DateTime.UtcNow.Minute == StaticVariables.minutos && DateTime.UtcNow.Second >= StaticVariables.seg)
            {
                m = 0;
            }
            else
            if (DateTime.UtcNow.Minute < StaticVariables.minutos && DateTime.UtcNow.Second >= StaticVariables.seg)
            {
                m = (60 - StaticVariables.minutos) + DateTime.UtcNow.Minute;
            }

        }
        if (DateTime.UtcNow.Second > StaticVariables.seg)
        {
            s = DateTime.UtcNow.Second - StaticVariables.seg;
        }
        else
        {
            if (DateTime.UtcNow.Second == StaticVariables.seg)
                s = 0;
            else
                if (DateTime.UtcNow.Second < StaticVariables.seg)
                s = (60 - StaticVariables.seg) + DateTime.UtcNow.Second;

        }
        return s + (m * 60);

    }
    public void Trampa()
    {

    }
    void Update()
    {
        if (!StaticVariables.gameover)
        {
            if (StaticVariables.iniciar)
            {
               // if ((StaticVariables.Tiempo - mostrarseg()) <= 0)
               if(StaticVariables.Tiempo-T<=0)
                {
                   // Trampa();
                   // StaticVariables.Tiempo = mostrarseg();
                    StaticVariables.gameover = true;
                    mostrar();
                }
                else
                {/*
                    mostrar();
                    if (mostrarseg() < ActualTime)
                        StaticVariables.gameover = true;
                        */
                    
                    T = T + Time.deltaTime;
                    mostrar();
                }
            }
        }
    }
}
