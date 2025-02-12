using UnityEngine;
using System.IO.Ports;
using Newtonsoft.Json.Linq;

public class Trombonette : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] TMPro.TextMeshProUGUI textDebug;

    [Header("Conx Params")]
    [SerializeField] internal string COMName = "COM A";
    [SerializeField] internal int COMBitrate = 9600;
    SerialPort serial;

    internal bool isAHold, isBHold, isCHold;
    internal int slideValue;
    const int MAX_SLIDE_VALUE = 663;

    public void OpenCOM()
    {
        print("Open..");
        serial = new SerialPort(COMName, COMBitrate);
        serial.Open();
    }


    public void CloseCOM()
    {
        serial.Close();
    }

    void Start()
    {
        serial = null;
        OpenCOM();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) {
            CloseCOM();
            print("closed!");
        }

        if (serial == null || !serial.IsOpen) return;

        JObject obj = JObject.Parse(serial.ReadLine());
        textDebug.text = $"data: {obj}";

        isAHold = (bool)obj["A"];
        isBHold = (bool)obj["B"];
        isCHold = (bool)obj["C"];

        slideValue = (int)((int)obj["D"]/(float)MAX_SLIDE_VALUE) * 100;
        
    }

    internal Combination GetCombination()
    {
        return new Combination()
        {
            isAHold = isAHold,
            isBHold = isBHold,
            isCHold = isCHold,
            slideLevel = slideValue
        };
    }

}
