using Photon.Pun;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class Health : MonoBehaviourPunCallbacks
{
    [SerializeField] private float PHealth = 100f;
    [SerializeField] private InstancingPlayerPruebas instancingPlayer;
    public bool dead;

    private void Awake()
    {
        instancingPlayer = FindAnyObjectByType<InstancingPlayerPruebas>();
    }

    void SettingPun()
    {
        photonView.RPC("TakeDamage",RpcTarget.All);
        photonView.RPC("Die", RpcTarget.All);
    }

    [PunRPC]
    public void TakeDamage(float damage)
    {
        PHealth -= damage;
        if (PHealth <= 0)
        {
            Die();
        }
    }

    [PunRPC]
    public void Die()
    {
        PHealth = 100f;
        dead = true;
        gameObject.transform.position = Vector3.zero;
    }
}
