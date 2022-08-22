using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mute : MonoBehaviour
{
    public List<AudioSource> sonido;
   
    public Image boton;
    public Sprite off,on;
   public void sound()
   {
      if(  Camera.main.GetComponent<AudioListener> ().enabled)
        {
            for(int i=0;i<sonido.Count;i++)
            {
                sonido[i].volume=0;
            }
            Camera.main.GetComponent<AudioListener> ().enabled=false;

            boton.sprite=off;
        }
     else
      {
          for(int i=0;i<sonido.Count;i++)
            {
                sonido[i].volume=1;
            }
           boton.sprite=on;
          Camera.main.GetComponent<AudioListener> ().enabled=true;
      }
   }
}
