using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class enviarpost : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void EnviarPost()
    {
        StartCoroutine(PostRequest("http://www.google.com"));
    }
    IEnumerator PostRequest(string url)
    {
        WWWForm form = new WWWForm();
        form.AddField("score", ""+StaticVariables.score);

        UnityWebRequest uwr = UnityWebRequest.Post(url, form);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
