using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectable : MonoBehaviour
{
    public static int collectionCounter = 0;

    public Vector3 lastCheckPos;

    FuelManager fuelManager;
    AudioManager audioManager;

    public TextMeshProUGUI partsCounterText;

    // Start is called before the first frame update
    void Start()
    {
        fuelManager = GameObject.FindObjectOfType<FuelManager>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();

        partsCounterText.text = "Parts Collected : /10" ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag.Equals("checkpoint"))
        {          
           
            lastCheckPos = other.transform.position;
            StartCoroutine(HandleCheckpointCollider(other.gameObject));      
            //other.gameObject.tag = null;
            //Destroy(other.gameObject);
        }

        if (other.gameObject.tag.Equals("collectable"))
        {
            collectionCounter++;
            Debug.Log("Collection counter : " + collectionCounter);
            partsCounterText.text = "Parts Collected : " + collectionCounter.ToString() + "/10";

            if (fuelManager.fuelAmount < 1)
            {
                fuelManager.fuelAmount += 0.1f;
            }

            audioManager.coinAudio.Play();

            Destroy(other.gameObject);
        }
    }

    IEnumerator HandleCheckpointCollider(GameObject other)
    {
        other.GetComponent<Collider>().enabled = false;
        audioManager.checkpointAudio.Play();
        yield return new WaitForSeconds(10f);
        other.GetComponent<Collider>().enabled = true;
    }
}
