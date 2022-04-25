using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag.Equals("Projectile"))
        {
            Destroy(this.gameObject);
        }
    }
}
