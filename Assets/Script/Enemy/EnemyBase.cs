using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name);

        var heath = collision.gameObject.GetComponent<HeathBase>();

        if (heath != null)
        {
            heath.Damage(damage);
        }
    }
}
