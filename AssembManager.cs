using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AssembManager : MonoBehaviour
{
    public GameObject table;
    public GameObject detal;
    public GameObject direct_x;
    public GameObject receiver;
    public GameObject spindel;
    public GameObject stand;

    public bool istable;
    public bool isdetal;
    public bool isdirect_x;
    public bool isreceiver;
    public bool isspindel;
    public bool isstand;

    public string[] sets;
    public string str;
    void Start()
    {
        StartCoroutine(getRequest("https://karasevv.com/hacaton/data_read.php"));
    }
    IEnumerator getRequest(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            str = uwr.downloadHandler.text;
            //Debug.Log("Received: " + uwr.downloadHandler.text);
            sets = str.Split ('|');
            Debug.Log("Received: " + sets[1]);
        }
        yield return new WaitForSeconds(2);
        StartCoroutine(getRequest("https://karasevv.com/hacaton/data_read.php"));
    }
    void Update()
    {
        istable=setState(sets[0]);
        isdetal=setState(sets[1]);
        isdirect_x=setState(sets[2]);
        isreceiver=setState(sets[3]);
        isspindel=setState(sets[4]);
        isstand=setState(sets[5]);

        table.SetActive(istable);
        detal.SetActive(isdetal);
        direct_x.SetActive(isdirect_x);
        receiver.SetActive(isreceiver);
        spindel.SetActive(isspindel);
        stand.SetActive(isstand);
    }
    private bool setState(string val){
        if (val == "1")
            return true;
        return false;
    }
}
