using Photon.Pun;
using UnityEngine;

public class InstancingPlayer : MonoBehaviourPunCallbacks
{
    [SerializeField] private PhotonView playerPrefab;
    [SerializeField] private Transform posicionSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();

    }

    public override void OnJoinedRoom()
    {

        PhotonNetwork.Instantiate(playerPrefab.name, posicionSpawn.position, posicionSpawn.rotation);
    }
}
