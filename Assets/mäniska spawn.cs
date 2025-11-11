using UnityEngine;

public class mäniskaspawn : MonoBehaviour
{
    public GameObject Square;
    public GameObject sick;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 10; i++) 
        {
            Instantiate(Square, new Vector3(i * 0.0f, 0, 0), Quaternion.identity);

        }

        
        
            Instantiate(sick, new Vector3(  0.0f, 0, 0), Quaternion.identity);
        
     
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
