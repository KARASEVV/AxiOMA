using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Jsoncontroller : MonoBehaviour
{

    public Text dat1;
    public Text dat2;
    public Text dat3;
    public Text dat4;
    public Text dat5;
    public Text dat6;
    public Text dat7;
    public Text dat8;
    public Text dat9;
    public Text dat10;
    public Image dat11;
    public Image dat12;
    public Text dat13;
    public Text dat14;
    public Text dat15;
    public Text dat16;
    public Text dat17;
    public Text dat18;
    public Text dat19;
    public Text dat20;

    public Image Im1;
    public Image Im2;
    public Button options;
    public GameObject Opti;
    public Text Cha1;
  
    public Text Cha2;
 
    public Text Moto;
    
    public Toggle tdc1;
    public Toggle tdc2;
    public Toggle tdmt;
    public Toggle td1;
    public Toggle td2;
    public Toggle td3;
    public Toggle td4;
    public Toggle td5;
    public Toggle td6;
    public Toggle td7;
    public Toggle td8;
    public Toggle td9;
    public Toggle td10;

    public Toggle td12;
    public Toggle td13;
    public Toggle td14;



    public string jsonURL;
    public Test jsnData;

    void Start()
    {
        
        StartCoroutine(getData());

    }
    private void Update()
    {
    }
    IEnumerator getData()
    {
        Debug.Log("Download...");
        var uwr = new UnityWebRequest(jsonURL);
        uwr.method = UnityWebRequest.kHttpVerbGET;
        var resultFile = Path.Combine(Application.persistentDataPath, "result.json");
        var dh = new DownloadHandlerFile(resultFile);
        dh.removeFileOnAbort = true;
        uwr.downloadHandler = dh;
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
            dat1.text = "ERROR";
        else
        {
            Debug.Log("Download saved to: " + resultFile);

            var rawData = File.ReadAllText(Application.persistentDataPath + "/result.json");
            var data = JObject.Parse(rawData)["data"]?.Children() ?? throw new Exception("Root field was not found");
            var parsedResult = new Dictionary<string, Dictionary<string, string>>(data.Count());

            foreach (var dataToken in data)
            {
                var itemsLength = dataToken.Count();
                if (itemsLength != 2)
                {
                    throw new Exception(
                        $"Invalid items inside data array. Expected 2, got {itemsLength}. Raw data: {dataToken}");
                }

                var title = dataToken.First?.Value<string>() ?? throw new Exception("Title was not found or it's null");
                var measurements = dataToken.Last?.Children().ToDictionary(x => x[0]?.Value<string>(), x => x[1]?.Value<string>());

                parsedResult[title] = measurements;
            }

            Debug.Log(parsedResult["Канал 1"]["Время работы канала (всего)"]);
            dat1.text = parsedResult["Канал 1"]["Статус канала"];
            dat2.text = parsedResult["Канал 1"]["Режим канала"];
            dat3.text = parsedResult["Канал 1"]["Время работы программы"];
            dat4.text = parsedResult["Канал 1"]["Процент выполнения программы"];
            dat5.text = parsedResult["Канал 1"]["Программа"];
            dat14.text = parsedResult["Канал 1"]["Время работы канала (всего)"];
            dat13.text = parsedResult["Канал 1"]["Время работы канала (текущее)"];


            char[] MyChar = { '%' };
            string data11string = parsedResult["Канал 1"]["Процент выполнения программы"].TrimEnd(MyChar);
            dat11.fillAmount = (float.Parse(data11string) / (float)100);





            dat6.text = parsedResult["Канал_2"]["Статус канала"];
            dat7.text = parsedResult["Канал_2"]["Режим канала"];
            dat8.text = parsedResult["Канал_2"]["Время работы программы"];
            dat9.text = parsedResult["Канал_2"]["Процент выполнения программы"];
            dat10.text = parsedResult["Канал_2"]["Программа"];
            string data12string = parsedResult["Канал_2"]["Процент выполнения программы"].TrimEnd(MyChar);
            dat12.fillAmount = (float.Parse(data12string) / (float)100);
            dat15.text = parsedResult["Канал_2"]["Время работы канала (всего)"];
            dat16.text = parsedResult["Канал_2"]["Время работы канала (текущее)"];

            dat17.text = parsedResult["Моточасы"]["Время работы ядра (всего)"];
            dat18.text = parsedResult["Моточасы"]["Время работы ядра (текущее)"];
            dat19.text = parsedResult["Моточасы"]["Количество перезапусков ядра"];
            dat20.text = parsedResult["Моточасы"]["Количество каналов"];

        }
        yield return StartCoroutine(getData());
    }
    public class Test
    {

        public string[][][][] data { get; set; }

    }
    public void buttonclick()
    {
        dat1.gameObject.SetActive(false);
        dat2.gameObject.SetActive(false);
        dat3.gameObject.SetActive(false);
        dat4.gameObject.SetActive(false);
        dat5.gameObject.SetActive(false);
        dat6.gameObject.SetActive(false);
        dat7.gameObject.SetActive(false);
        dat8.gameObject.SetActive(false);
        dat9.gameObject.SetActive(false);
        dat10.gameObject.SetActive(false);
        dat11.gameObject.SetActive(false);
        dat12.gameObject.SetActive(false);
        dat13.gameObject.SetActive(false);
        dat14.gameObject.SetActive(false);
        dat15.gameObject.SetActive(false);
        dat16.gameObject.SetActive(false);
        Im1.gameObject.SetActive(false);
        Im2.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        Cha1.gameObject.SetActive(false);
        Cha2.gameObject.SetActive(false);
        Moto.gameObject.SetActive(false);
        dat17.gameObject.SetActive(false);
        dat18.gameObject.SetActive(false);
        dat19.gameObject.SetActive(false);
        dat20.gameObject.SetActive(false);


        Opti.gameObject.SetActive(true);
    }
    public void opticlick()
    {
        Opti.gameObject.SetActive(false);
        options.gameObject.SetActive(true);
        
        if (tdc1.isOn)
        {
            
            Cha1.gameObject.SetActive(true);
            if (td1.isOn)
            {
                dat1.gameObject.SetActive(true);
                dat2.gameObject.SetActive(true);
            }
            if (td2.isOn)
            {
                dat13.gameObject.SetActive(true);
                dat14.gameObject.SetActive(true);
            }
            if (td3.isOn)
            {
                dat3.gameObject.SetActive(true);
            }
            if (td4.isOn)
            {
                dat4.gameObject.SetActive(true);
                Im2.gameObject.SetActive(true);
                dat11.gameObject.SetActive(true);
            }
            if (td5.isOn)
            {

                dat5.gameObject.SetActive(true);
            }
        }
        if (tdc2.isOn)
        {
         
            Cha2.gameObject.SetActive(true);
            if (td6.isOn)
            {
                dat6.gameObject.SetActive(true);
                dat7.gameObject.SetActive(true);
            }
            if (td7.isOn)
            {
                dat15.gameObject.SetActive(true);
                dat16.gameObject.SetActive(true);
            }
            if (td8.isOn)
            {
                dat8.gameObject.SetActive(true);
            }
            if (td9.isOn)
            {
                dat9.gameObject.SetActive(true);
                Im1.gameObject.SetActive(true);
                dat12.gameObject.SetActive(true);
            }
            if (td10.isOn)
            {
                dat10.gameObject.SetActive(true);
            }
        }
        if (tdmt.isOn)
        {
           
            Moto.gameObject.SetActive(true);
            if (td12.isOn)
            {
                dat17.gameObject.SetActive(true);
                dat18.gameObject.SetActive(true);
            }
            if (td13.isOn)
            {
                dat19.gameObject.SetActive(true);
            }
            if (td14.isOn)
            {
                dat20.gameObject.SetActive(true);
            }
        }

    }
    
    

}









