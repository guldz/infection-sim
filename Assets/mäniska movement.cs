using UnityEngine;

public class mäniska : MonoBehaviour

{
    public float speed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float randomX = Random.Range(-1f, 1f);

        float randomY = Random.Range(-1f, 1f);

        Vector2 randomDirection = new Vector2(randomX, randomY);
    }
}
