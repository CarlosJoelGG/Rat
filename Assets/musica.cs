using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musica : MonoBehaviour
{
    public AudioSource af;
    public List<AudioSource> melodias;
    public int index=0;
    public int playList = 0;
    public bool aux = false,Main=false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
 
    public void tocar(int a, bool b)
    {
        for (int i = 0; i < melodias.Count; i++)
        {
            if (a == i && !b)
            {
                if (!melodias[i].isPlaying)
                    melodias[i].Play();
            }
            else
            {
                if (melodias[i].isPlaying)
                    melodias[i].Stop();
            }
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        if (StaticVariables.gameover)
        {
            if (af.isPlaying)
            {
                af.Stop();
            }
        }
        else
        {
            tocar(playList, aux);
        }
        if (Main)
        {
            if (!af.isPlaying)
            {
                af.Play();
            }
        }
        else
            switch (index)
            {
                case 0:
                    if (StaticVariables.AT < 94)
                    {
                        playList++;
                        index++;
                    }
                    break;
                case 1:
                    if (StaticVariables.AT < 36)
                    {
                        index++;
                        playList++;
                    }
                    break;
                case 2:
                    if (StaticVariables.AT < -1)
                    {
                        index++;
                        playList++;
                       // aux = true;
                    }
                    break;
                case 3:
                    if (StaticVariables.AT < -1)
                        index++;
                    break;
            }

    }
}
