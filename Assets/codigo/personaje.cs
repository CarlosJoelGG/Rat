using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class personaje : MonoBehaviour
{
    public float Frebote;
    public float AMax,AMin;
    public float y;
    public bool muyalto = false,shock=false;
    public Button ani;
    public int manual = 1;
    public float TM,ST=0, esperar=0;
    public bool tocarsuelo = false;
    public bool init = false;


    // Start is called before the first frame update
    void Start()
    {
        StaticVariables.iniciar = false;
        StaticVariables.gameover = false;  
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "enemigo":
                if (!shock)
                {
                    ST = 0;
                    shock = true;
                    GetComponent<Animator>().Play("click");
                    StaticVariables.vidas--;
                    if (StaticVariables.vidas <= 0)
                    {
                        muyalto = true;
                        StaticVariables.vidas = 0;
                    }
                    if (collision.gameObject.GetComponent<comportamiento>().index == 0)
                        GetComponent<Animator>().Play("electrocutar");
                    if (collision.gameObject.GetComponent<comportamiento>().index == 1)
                        GetComponent<Animator>().Play("electrocutarse");
                }
                break;
            case "queso":
                StaticVariables.score += 1;
                collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                break;
        }
        if (collision.gameObject.tag.Equals("enemigo"))
        {
            
        }

    }
    private void OnApplicationFocus(bool focus)
    {/*
        if (focus)
        {
            Time.timeScale = 1;
        }
        else
        {
            if (!StaticVariables.iniciar)
                Time.timeScale = 0;
        }*/
    }
   
    
    public void rebotar()
    {
            if (!muyalto && !StaticVariables.gameover )
            { 
               gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 6* manual);
            if (GetComponent<Rigidbody2D>().gravityScale == 0 && !StaticVariables.gameover)
            {
                if(!shock)
                GetComponent<Animator>().Play("click");
                GetComponent<Rigidbody2D>().gravityScale = 1* manual;
                StaticVariables.iniciar = true;
                StaticVariables.minutos = DateTime.UtcNow.Minute;
                StaticVariables.seg = DateTime.UtcNow.Second;
                StaticVariables.horas = DateTime.UtcNow.Hour;
            }
            else
            {
                if (shock)
                {
                   
                }
                else
                {
                    int ran = (int)Mathf.FloorToInt(UnityEngine.Random.Range(0, 1.9f));
                    if (ran == 0)
                        GetComponent<Animator>().Play("click");
                }
            }
        }          
    }
    // Update is called once per frame
    void Update()
    {
        if (init)
        {
            rebotar();
            init = false;
            ani.enabled = true;

        }
        if (StaticVariables.iniciar)
        {
            if (shock)
            {
                ST = Time.deltaTime + ST;
                if (ST > 2f)
                { shock = false;
                    ST = 0;
                }
            }
            if (StaticVariables.AT <= 0)
            { GetComponent<Rigidbody2D>().gravityScale = 1; }
            if (transform.position.y >= AMax)
            {
                muyalto = true;
            }
            if (transform.position.y < AMin)
            {
                StaticVariables.gameover = true;
                if (StaticVariables.AT > 0)
                { StaticVariables.vidas = 0; }
                GetComponent<Rigidbody2D>().gravityScale = 0;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                transform.position = new Vector3(transform.position.x, AMin, transform.position.z);
                if (StaticVariables.AT < 92 && StaticVariables.AT > 35)
                {
                    GetComponent<Animator>().Play("Agua");
                }
                else
                { if (StaticVariables.AT == 0)
                    { GetComponent<Animator>().Play("llegar"); }
                    else
                    GetComponent<Animator>().Play("caida"); 
                }
            }
        }
       
        y = transform.position.y;
    }
}
