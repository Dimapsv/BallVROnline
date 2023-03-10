
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
        PhotonNetwork.Instantiate("OculusCameraMine", Player.transform.position, Quaternion.identity); //OVRCameraRig
        PhotonNetwork.Instantiate("GameManager", Player.transform.position, Quaternion.identity);
    }
}
