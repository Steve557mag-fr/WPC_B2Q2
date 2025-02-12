using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject Canvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Event Entered");

        if (other.tag == "EventTrigger")
        {
            Canvas.GetComponent<QTE>().StartQTE();
            GameManager.instance.SetTileSpeed(1);
        }
    }
}
