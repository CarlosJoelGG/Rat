using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHud : MonoBehaviour
{
    public Text QuesoP, QuesoT, VidasP, VidasT, Total;
    public Image icono, fondo,cara;
    public List<Sprite> iconos; 
    public GameObject redi;
    // Start is called before the first frame update
    public bool a = false;
    void Start()
    {
       QuesoP.text="x "+StaticVariables.score + "(25) :";
        QuesoT.text = "" + (StaticVariables.score * 25+" pts");
        VidasP.text = "x " + StaticVariables.vidas + "(50) :";
        VidasT.text = "" + (StaticVariables.vidas * 50)+" pts";
        Total.text = "" + ((StaticVariables.score * 25) + (StaticVariables.vidas * 50)+" pts");
        StaticVariables.TScore=((StaticVariables.score * 25) + (StaticVariables.vidas * 50));
        redi.GetComponent<redireccion>().enabled=true;
        if (StaticVariables.AT <=0 || StaticVariables.score>=10)
        {
            fondo.sprite = iconos[0];
            icono.sprite = iconos[2];
            cara.sprite = iconos[4];
            icono.gameObject.GetComponent<Animator>().Play("IdleW");
        }
        else
        {
            fondo.sprite = iconos[1];
            icono.sprite = iconos[3];
            cara.sprite = iconos[4];
            icono.gameObject.GetComponent<Animator>().Play("IdleL");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
