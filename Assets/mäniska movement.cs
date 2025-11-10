using UnityEngine;

public class Maniska : MonoBehaviour
{
    public float speed = 1f;
    private Vector2 direction;
    private float changeDirectionTime = 0f;
    public enum HealthState { Healthy, Infected, Immune }
    public HealthState state = HealthState.Healthy;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
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
        switch (state)
        {
            case HealthState.Healthy: sr.color = Color.green; break;
            case HealthState.Infected: sr.color = Color.red; break;
            case HealthState.Immune: sr.color = Color.blue; break;
        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Maniska otherHuman = other.GetComponent<Maniska>();
        if (otherHuman != null)
        {
            Debug.Log($"{name} touched {other.name}");

            
            if ((state == HealthState.Infected && otherHuman.state != HealthState.Immune) ||
                (otherHuman.state == HealthState.Infected && state != HealthState.Immune))
            {
                int roll = Random.Range(0, 100);

                if (roll < 40)
                {
                    state = HealthState.Infected;
                    otherHuman.state = HealthState.Infected;
                    Debug.Log($"Infection! Roll = {roll}");
                }
                else if (roll <99)
                {
                    
                    Debug.Log($"Safe this time. Roll = {roll}");
                }
                else
                {
                    
                    state = HealthState.Immune;
                    otherHuman.state = HealthState.Immune;
                    Debug.Log($"Immune! Roll = {roll}");
                }
            }
        }
    }
}