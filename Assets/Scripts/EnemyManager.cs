using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    FuelManager fuelManager;

    public bool isRotateAround;

    public GameObject star3;

    AudioManager audioManager;

    private void Start()
    {
        fuelManager = GameObject.FindObjectOfType<FuelManager>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag.Equals("Projectile"))
        {
            ScoreManager.score += 10;
            Destroy(this.gameObject);
            audioManager.enemyDestroy.Play();
        }

        if(other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Game OVer !!!!");
            fuelManager.gameOver.SetActive(true);
            audioManager.enemyDestroy.Play();
        }
    }

    private void Update()
    {
        if (isRotateAround)
        {
            if(star3)
            transform.RotateAround(star3.transform.position, Vector3.up, 50 * Time.deltaTime);
        }
    }
}
