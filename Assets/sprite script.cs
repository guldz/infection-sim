using UnityEngine;

public class ManiskaSprite : MonoBehaviour
{
    public Sprite[] stateSprites;
    public Sprite HealthySprite;
    public Sprite SickSprite;
    public Sprite ImmuneSprite;
    public Sprite DeadSprite; 


    private Maniska maniska;
    private SpriteRenderer sr;

    void Start()
    {
        maniska = GetComponent<Maniska>();
        sr = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }

    void Update()
    {
        UpdateSprite();
    }

    void UpdateSprite()
    {
        sr.sprite = stateSprites[(int)maniska.state];
    }
}


