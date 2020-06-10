using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class SendRecord : MonoBehaviour {

	// Use this for initialization
	
	public void Send(string ID, string time)
    {
        Dictionary<string, string> record = new Dictionary<string, string>();

        DateTime t = DateTime.Now;
        record["activityID"] = ID;
        record["LastingTime"] = time;
        record["timeStamp"] = t.ToString("yyyy-M-d HH:mm:ss");


        StartCoroutine(PostRecord("http://127.0.0.1:8080/api/record", record));
    }

    IEnumerator PostRecord(string url, Dictionary<string,string> json)
    {
        WWWForm form = new WWWForm();
        foreach(KeyValuePair<string, string> i in json)
        {
            int n;
            if (int.TryParse(i.Value,out n))
            {
                form.AddField(i.Key, n);
            }
            else
            {
                form.AddField(i.Key, i.Value);
            }
        }
        using (UnityWebRequest uwr = UnityWebRequest.Post(url, form))
        {
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError)
            {
                Debug.LogError("network error");
            }
            else
            {
                Debug.Log(uwr.downloadHandler.text);
            }
        }
       
    }
}
