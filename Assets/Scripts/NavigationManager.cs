using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : MonoBehaviour
{

    private void Start()
    {
        FindClosestEnemy();
        LookAtCloseCol();
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] collectibles;
        collectibles = GameObject.FindGameObjectsWithTag("collectable");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in collectibles)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
                Debug.Log("distance : " + distance);
            }
        }
        return closest;
    }

    private void LookAtCloseCol()
    {
        this.transform.LookAt(FindClosestEnemy().transform);
    }

    private void Update()
    {
        LookAtCloseCol();
    }
}
