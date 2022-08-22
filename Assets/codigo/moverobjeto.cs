using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverobjeto : MonoBehaviour
{
    public float velocidad,limite,retroceso,x;
    public Vector3 movimiento;
    public List<Sprite> imagenes;
    public float destrutir;
    public bool repeat=false,menor=false, forzar_mover,visible=false;
    public int xyz;
    // Start is called before the first frame update
    void Start()
    {
        movimiento = transform.position;
      
    }
    public float evaluar(float mov,float pos)
    {
        if (menor)
        {
            if (mov <= limite && repeat)
            {
                mov = retroceso;
                pickone();
            }
            else
            { mov = pos + (velocidad * Time.deltaTime);
            }
        }
        else
        {
            if (mov >= limite && repeat)
            {
                mov = retroceso;
                pickone();
            }
            else
            { mov = pos + (velocidad * Time.deltaTime); }
        }
        return mov;
       
    }
    public void pickone()
    {
        int ran=(int)Mathf.FloorToInt(UnityEngine.Random.Range(0, imagenes.Count - 0.5f));
        GetComponent<SpriteRenderer>().sprite = imagenes[ran];
    }

   


   
    void Update()
    {
        if ((StaticVariables.iniciar && !StaticVariables.gameover) || (forzar_mover))
        {
            switch (xyz)
            {
                case 1:
                    movimiento.x = evaluar(movimiento.x, transform.position.x);
                   
                    break;
                case 2:
                    movimiento.y = evaluar(movimiento.y, transform.position.y);
                    break;
                case 3:
                    movimiento.z = evaluar(movimiento.z, transform.position.z);
                    
                    break;
            }
            transform.position = movimiento;
        }

    }
}
