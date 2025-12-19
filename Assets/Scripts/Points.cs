using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Points : MonoBehaviourPunCallbacks
{
    [SerializeField]private GameObject[] players;
    void SettingPun()
    {
        photonView.RPC("End", RpcTarget.All);
    }

    private void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    [PunRPC]
    public void End()
    {
        for (int i = 0; i < players.Length; i++)
        {
            Combat combat = players[i].GetComponent<Combat>();
            if (combat != null && combat.MyPoints >= 3)
            {
                Debug.Log("Player " + players[i].name + " wins!");
                SceneManager.LoadScene("Lobby");
            }
        }
        
    }
}
