using UnityEngine;

public class mäniskaspawn : MonoBehaviour
{
    public GameObject Square; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = -8; i < 15; i++) 
        {
            Instantiate(Square, new Vector3(i * 0.0f, 0, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
