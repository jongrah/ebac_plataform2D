using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particleCoin;
    public float timeToHide = 3;
    public GameObject graphicItem;

    [Header("Sounds")]
    public AudioSource audioSource;


    private void Awake()
    {
        if (particleCoin != null)
        {
            particleCoin.transform.parent = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        HideObject();
        /*if (graphicItem != null) graphicItem.SetActive(false);
        Invoke("HideObject", timeToHide);*/
        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if (particleCoin != null)
        {
            particleCoin.Play();
        }

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
