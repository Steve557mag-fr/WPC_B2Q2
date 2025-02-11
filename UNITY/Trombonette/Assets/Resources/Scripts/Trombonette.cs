using UnityEngine;
using System.IO.Ports;

public class Trombonette : MonoBehaviour
{
    [Header("Conx Params")]
    [SerializeField] string COMName = "COM A";
    [SerializeField] int COMBitrate = 9600;
    SerialPort serial;

    public void OpenCOM()
    {
        serial = new SerialPort(COMName, COMBitrate);
        serial.Open();
    }

    public void CloseCOM()
    {
        serial.Close();
    }

    void Start()
    {
        serial = new SerialPort();
    }

    void Update()
    {
        if (serial == null || !serial.IsOpen) return;
        serial.DataReceived += DataReceived;

    }

    private void DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}
