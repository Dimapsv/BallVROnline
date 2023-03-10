
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject Player;


    void Awake()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        PhotonNetwork.Instantiate("OVRCameraRig", Player.transform.position, Quaternion.identity);
    }
}
