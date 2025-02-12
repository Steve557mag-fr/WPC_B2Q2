using UnityEngine;

public class Tile : MonoBehaviour
{

    internal Vector3 endPosition = new Vector3(22f, 0.0f, 0.0f);

    public float speed;

    private void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
        if(Vector3.Distance(endPosition, transform.position) < 0.5f) 
        {
            Destroy(gameObject);
            GameManager.instance.instantiatedTiles.Remove(gameObject);
            GameManager.instance.CreateTile();
        }
    }
}
