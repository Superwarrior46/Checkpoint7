using Photon.Pun;
using UnityEngine;

public class SceneLimits : MonoBehaviourPunCallbacks
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        health.Die();
    }
}
