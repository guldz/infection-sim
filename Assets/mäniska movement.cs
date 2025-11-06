using UnityEngine;

public class mäniska : MonoBehaviour

{
    mäniskaspawn humanspawn;
    public float speed = 1f;
    private Vector2 direction;
    private float changeDirectionTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //som namnen random väg att gå
        direction = Random.insideUnitCircle.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        //väjer random ställe att flytta sig varje ny start på spel
        changeDirectionTime -= Time.deltaTime;
        if (changeDirectionTime <= 0f)
        {
            direction = Random.insideUnitCircle.normalized;
            changeDirectionTime = Random.Range(1f, 3f); 
        }
        //denna flyttar spelobjektet 
        transform.Translate(direction * speed * Time.deltaTime);
        //använd detta för hålla snubbe inom scenen 
        Vector3 pos = transform.position;
        if (pos.x > 8 || pos.x < -8) direction.x = -direction.x;
        if (pos.y > 4 || pos.y < -4) direction.y = -direction.y;
    }

}
