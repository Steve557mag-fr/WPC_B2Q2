using UnityEngine;
using System.IO.Ports;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Formatters;

public class Trombonette : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] TMPro.TextMeshProUGUI textDebug;

    [Header("Conx Params")]
    [SerializeField] internal string COMName = "COM A";
    [SerializeField] internal int COMBitrate = 9600;
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
        if (Input.GetKeyUp(KeyCode.Space)) {
            CloseCOM();
            print("closed!");
        }

        if (serial == null || !serial.IsOpen) return;

        JObject obj = JObject.Parse(serial.ReadLine());
        textDebug.text = $"data: {obj}";

    }
}
