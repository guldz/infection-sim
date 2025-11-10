using UnityEngine;

public class Maniska : MonoBehaviour
{
    public float speed = 1f;
    private Vector2 direction;
    private float changeDirectionTime = 0f;

    void Start()
    {
        // börjar på random ställe
        direction = Random.insideUnitCircle.normalized;
    }

    void Update()
    {
        // väljer något annat random ställe att gå idk 
        changeDirectionTime -= Time.deltaTime;
        if (changeDirectionTime <= 0f)
        {
            direction = Random.insideUnitCircle.normalized;
            changeDirectionTime = Random.Range(2f, 6f);
        }

        // flyttar square 
        transform.Translate(direction * speed * Time.deltaTime);

        // höll inom spel area och studsa tillbaka 
        Vector3 pos = transform.position;
        float xLimit = 8f;
        float yLimit = 4f;

        if (pos.x > xLimit)
        {
            pos.x = xLimit;
            direction.x = -direction.x;
            changeDirectionTime = 4f;
        }
        else if (pos.x < -xLimit)
        {
            pos.x = -xLimit;
            direction.x = -direction.x;
            changeDirectionTime = 4f;
        }

        if (pos.y > yLimit)
        {
            pos.y = yLimit;
            direction.y = -direction.y;
            changeDirectionTime = 4f;
        }
        else if (pos.y < -yLimit)
        {
            pos.y = -yLimit;
            direction.y = -direction.y;
            changeDirectionTime = 4f;
        }

        // aplayar in eller något in den rätta positionen 
        transform.position = pos;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("i hit" + other.name);
        
    }
}
