using UnityEngine;
using System.IO.Ports;

public class Trombonette : MonoBehaviour
{

    [Header("Conx Params")]
    [SerializeField] string COMName = "COM A";
    [SerializeField] int COMBitrate = 9600;

    GameObject partA;
    GameObject partB;
    GameObject partC;

    void Start()
    {

    }

    void Update()
    {
        
    }
}
