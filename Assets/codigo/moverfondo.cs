using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverfondo : MonoBehaviour
{
    public int index;
    public GameObject Fondo;
    public Material FC;
    public bool forzar;
    public Vector2 XYDCiudad, XYDLuna;
    public float VelocidadFondo,DFondo;
    

    // Update is called once per frame
    void Start()
    {
        
            FC = Fondo.GetComponent<SpriteRenderer>().material;
            
            XYDCiudad = FC.mainTextureOffset;
           
        
    }
    public void moverC(float a)
    {
      
            XYDCiudad.x = a;

            FC.mainTextureOffset = XYDCiudad;
        

    }
   
    public float Evaluar(float min, float pointH)
    {
        if (pointH < min)
            return min;
        else
            return pointH;
    }
    void Update()
    {
        if (StaticVariables.iniciar && (!StaticVariables.gameover || forzar))
        {
            DFondo = DFondo + (VelocidadFondo * Time.deltaTime);
            moverC(DFondo);
        }
        //moverL(Personaje.transform.position.x, this.transform.position.x);
      

    }


}
