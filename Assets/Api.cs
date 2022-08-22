using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System;

[Serializable]
public class jsonSend
{
    public bool finished;
    public string accion, juego,sala, Token, Accept;
    public int Score;
}

public class Api: MonoBehaviour
{
    public bool send = false;
    public string nombredeljuego="";
    public string sala, url,token,accep, redirect;

  

    public void getredirect(string a)
    {
        redirect = a;
    }
    public void enviarinit()
    {
        StartCoroutine(PostData_Coroutine("playGame",false));
    }
    public void getToken(string a)
    {
        token = a;
    }
    public void getAccept(string a)
    {
        accep = a;
    }
    public void geturl(string a)
    {
        url = a;
    }
    public void getsala(string a)
    {
        sala = a;
    }

    public void Sendpost(string a,bool b)
    {//"SaveDataPlayGame"
        StartCoroutine(PostData_Coroutine(a,b));
    }
    public void resend()
    {
        send = false;
    }

    IEnumerator PostData_Coroutine(string c,bool b)
    {
        jsonSend a = new jsonSend();
        a.accion = c;
        a.finished=b;
        a.juego = nombredeljuego;
        a.sala = sala;
        a.Token = token;
        a.Accept = accep;
        a.Score= StaticVariables.TScore;
        string uri = url;
        string json = JsonUtility.ToJson(a);
        print(json);
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("accept", "application/json");
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            Debug.Log("Error: " + request.error);
        }
        else
        {
            Debug.Log("Status Code: " + request.responseCode);
        }
    }
}
