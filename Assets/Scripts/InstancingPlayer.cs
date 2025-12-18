using Photon.Pun;
using UnityEngine;

public class InstancingPlayerPruebas : MonoBehaviourPunCallbacks
{
    [SerializeField] private PhotonView playerPrefab;
    [SerializeField] private Transform posicionSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ReInstancingPlayers();
    }

    public void ReInstancingPlayers()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, posicionSpawn.position, posicionSpawn.rotation);
    }
}
