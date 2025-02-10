using UnityEngine;
using System.IO.Ports;
using Newtonsoft.Json.Linq;

public class Trombonette : MonoBehaviour
{
    [Header("Debug")]
    TMPro.TextMeshProUGUI textDebug;

    [Header("Conx Params")]
    [SerializeField] string COMName = "COM A";
    [SerializeField] int COMBitrate = 9600;
    SerialPort serial;

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
        if (serial == null || !serial.IsOpen) return;

        JObject obj = JObject.Parse(serial.ReadLine());
        textDebug.text = $"data: {obj}";

    }
}
