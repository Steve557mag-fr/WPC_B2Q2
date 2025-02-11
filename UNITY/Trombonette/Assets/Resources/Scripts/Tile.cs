using UnityEngine;

public class Tile : MonoBehaviour
{

    internal Vector3 endPosition = new Vector3(22f, 0.0f, 0.0f);

    public float lifetime;

    void Update()
    {
        transform.LeanMove(endPosition, lifetime).setEase(LeanTweenType.linear);
        if(Vector3.Distance(endPosition, transform.position) < 0.5f) 
        {
            Destroy(gameObject);   
        }

    }
}
