using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;

    public Animator animator;
    public string triggerAttack = "Attack";
    public string triggerKill = "Death";

    public HeathBase heathBase;

    public float timeToDestroy = 1f;

    private void Awake()
    {
        if (heathBase != null)
        {
            heathBase.OnKill += OnEnemyKill;
        }
    }

    private void OnEnemyKill()
    {
        heathBase.OnKill -= OnEnemyKill;
        PlayKillAnimation();
        Destroy(gameObject, timeToDestroy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name);

        var heath = collision.gameObject.GetComponent<HeathBase>();

        if (heath != null)
        {
            heath.Damage(damage);
            PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }

    private void PlayKillAnimation()
    {
        animator.SetTrigger(triggerKill);
    }

    public void Damage (int amount)
    {
        heathBase.Damage(amount);
    }
}
