using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class redireccion : MonoBehaviour
{
    public GameObject Apis;
    float a = 5;
    public Text b;
    bool re = false;
    
    [DllImport("__Internal")]
    private static extern void openWindow(string url);

    public void QuitAndClose()
    {
        string a = Apis.GetComponent<Api>().redirect;
 
        if (a.Equals("") || a == null)
        {
            openWindow("https://www.google.com/");
        }
        else
            openWindow(a);
    }
    // Start is called before the first frame update
    void Start()
    {
        a = 5;
        Apis.GetComponent<Api>().Sendpost("SaveDataPlayGame",true);
        b.text= "Redireccionando en ... 5";

    }

    // Update is called once per frame
    void Update()
    {
        

        if (a <= 0)
        {if (!re)
            {
                re = true;
                QuitAndClose();
            }
        }
        else
        {
            b.text = "Redireccionando en ... " + System.Math.Round(a,0);
            a = a - Time.deltaTime;
        }
    }
}
