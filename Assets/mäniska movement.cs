using UnityEngine;

public class Maniska : MonoBehaviour
{
    public float speed = 1f;
    public Vector2 direction; //sätt till public 
    private float changeDirectionTime = 0f;
    public enum HealthState { Healthy, Infected, Immune, Dead }
    public HealthState state = HealthState.Healthy;
    private SpriteRenderer sr;
    private float infectionTimer = 0f;
    public float infectionDuration = 5f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (transform.position == Vector3.zero)
        {
            transform.position = new Vector2(
                Random.Range(-8f, 8f),
                Random.Range(-4f, 4f)
            );
        }

        // börjar gå i en slumpad riktning
        if (direction == Vector2.zero)
            direction = Random.insideUnitCircle.normalized;
    }

    void Update()
    {
        switch (state)
        {
            case HealthState.Healthy: sr.color = Color.green; break;
            case HealthState.Infected: sr.color = Color.red; break;
            case HealthState.Immune: sr.color = Color.blue; break;
            case HealthState.Dead: sr.color = Color.black; break;
        }

        if (state == HealthState.Dead)
            return;
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

        if (state == HealthState.Infected)
        {
            infectionTimer += Time.deltaTime;

            if (infectionTimer >= infectionDuration)
            {
                int roll = Random.Range(0, 100);

                if (roll < 50)
                {
                    // 50% chans att dö
                    state = HealthState.Dead;
                    Debug.Log($"{name} dog av infektionen. Roll = {roll}");
                }
                else
                {
                    
                    Debug.Log($"{name} överlevde infektionen (för nu). Roll = {roll}");
                }

                infectionTimer = 0f; 
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Maniska otherHuman = other.GetComponent<Maniska>();
        if (otherHuman == null) return;

        Debug.Log($"{name} touched {other.name}");

        // om den här personen är infekterad och den andra är mottaglig (inte immun eller död)
        if (state == HealthState.Infected &&
            otherHuman.state == HealthState.Healthy)
        {
            int roll = Random.Range(0, 100);

            if (roll < 40)
            {
                otherHuman.state = HealthState.Infected;
                Debug.Log($"Infected {otherHuman.name}! Roll = {roll}");
            }
            else if (roll < 90)
            {
                Debug.Log($"{otherHuman.name} klarade sig. Roll = {roll}");
            }
            else if (roll < 97)
            {
                otherHuman.state = HealthState.Immune;
                Debug.Log($"{otherHuman.name} blev immun! Roll = {roll}");
            }
            else
            {
                otherHuman.state = HealthState.Dead;
                Debug.Log($"{otherHuman.name} dog! Roll = {roll}");
            }
        }
        // samma åt andra hållet (ifall other är infekterad)
        else if (otherHuman.state == HealthState.Infected &&
                 state == HealthState.Healthy)
        {
            int roll = Random.Range(0, 100);

            if (roll < 40)
            {
                state = HealthState.Infected;
                Debug.Log($"{name} blev infekterad! Roll = {roll}");
            }
            else if (roll < 90)
            {
                Debug.Log($"{name} klarade sig. Roll = {roll}");
            }
            else if (roll < 97)
            {
                state = HealthState.Immune;
                Debug.Log($"{name} blev immun! Roll = {roll}");
            }
            else
            {
                state = HealthState.Dead;
                Debug.Log($"{name} dog! Roll = {roll}");
            }
        }
    }
}