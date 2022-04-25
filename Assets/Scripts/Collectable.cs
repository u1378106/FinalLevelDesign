using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public static int collectionCounter = 0;

    FuelManager fuelManager;
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        fuelManager = GameObject.FindObjectOfType<FuelManager>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
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
           
            if (fuelManager.fuelAmount < 1)
            {
                fuelManager.fuelAmount += 0.1f;
                audioManager.coinAudio.Play();
            }

            Destroy(other.gameObject);
        }
    }
}
