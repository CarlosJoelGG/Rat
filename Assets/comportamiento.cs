using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comportamiento : MonoBehaviour
{
    public int NC, aux = -1,auy=1,dog=0;
    public float Tiempo, Reset,xD=0,D;
    public Vector2 AX,AY,desacelerar;
    public int Tnorepeat;
    public int index = 0;

    //-1.73
    public Vector3 movimiento;
    void Start()
    {
        
        Elegir();
    }
    public void Elegir()
    {
        movimiento = transform.position;
        if (index==2)
        {
            NC = (int)Mathf.FloorToInt(Random.Range(0, 2.9f));
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
            NC = (int)Mathf.FloorToInt(Random.Range(0, 1.5f));
        
    }
    public void Comportar()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if ((StaticVariables.iniciar && !StaticVariables.gameover) || index==5)
        {
            movimiento = transform.position;
           
            switch (index)
            {
                case 0://energia
                    if (movimiento.y >= AY.x)
                    {
                        auy = -1; 
                    }
                    if (movimiento.y <= AY.y)
                        auy = 1;
                    if (xD >= (-desacelerar.x * D) * Time.deltaTime)
                        aux = 1;
                    if (xD <= (desacelerar.x * D) * Time.deltaTime)
                        aux = -1;
                    switch (NC)
                        {
                            case 0:
                                movimiento.y = movimiento.y + (auy * desacelerar.y * Time.deltaTime);
                                break;
                            case 1:
                                movimiento.x = movimiento.x + ((desacelerar.x * aux) * Time.deltaTime);
                                xD = xD + ((desacelerar.x * aux) * Time.deltaTime);
                                break;
                        }
                    break;
                case 1://perro
                    if (movimiento.y >= (AY.x - (dog * 0.4f)))
                    {
                        if (index == 1)
                        { auy = 0; }
                      
                    }
                    if (movimiento.y <= AY.x)
                        auy = 1;
                    if (xD >= (-desacelerar.x * D) * Time.deltaTime)
                        aux = 1;
                   /* if (xD <= desacelerar.x * D)
                        aux = -1;*/
                    movimiento.x = movimiento.x + ((desacelerar.x * aux) * Time.deltaTime);
                    xD = xD + ((desacelerar.x * aux) * Time.deltaTime);
                    break;
                case 2://queso
                    switch (NC)
                    {
                        case 0:
                            movimiento.y = 2.86f;
                            break;
                        case 1:
                            movimiento.y = -0.46f;
                            break;
                        case 2:
                            movimiento.y = -2.34f;
                            break;

                    }
                    break;
                case 5:
                    movimiento.x = movimiento.x + (desacelerar.x  * Time.deltaTime);
                    break;

            }
 
            if (movimiento.x - xD <= AX.x && StaticVariables.AT> Tnorepeat)
            {
                Elegir();
                movimiento.x = AX.y;
                xD = 0;
                
                if (index==0 || index==1)
                {

                    if (NC == 0)
                    {
                        index = (int)Mathf.FloorToInt(Random.Range(0, 2.3f));
                        if (index > 1)
                        { index = 1; }
                        switch (index)
                        {
                            case 0:
                                GetComponent<Animator>().Play("energia");
                                transform.localScale = new Vector3(0.6f, 0.6f, 1);
                                break;
                            case 1:
                                auy = 1;
                                GetComponent<Animator>().Play("perro");
                                transform.localScale = new Vector3(0.8f, 0.8f, 1);
                                break;
                        }
                    }
                    else
                    {
                        index = 0;
                        GetComponent<Animator>().Play("energia");
                        transform.localScale = new Vector3(0.6f, 0.6f, 1);
                    }
                }
            }
            transform.position = movimiento;
        }
    }
}
