
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject Player;


    void Start()
    {
        
    }

    public void SpawnPlayer()
    {
        PhotonNetwork.Instantiate(Player.name, Player.transform.position, Quaternion.identity);
    }
}
