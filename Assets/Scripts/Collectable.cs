using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public static int collectionCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag.Equals("collectable"))
        {
            collectionCounter++;
            Debug.Log("Collection counter : " + collectionCounter);
            Destroy(other.gameObject);
        }
    }
}
