using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameController : MonoBehaviourPunCallbacks
{
    public GameObject anchor;

    private void Awake()
    {
        GameObject go = PhotonNetwork.Instantiate("OVRPlayerController", transform.position, Quaternion.identity); // OVRCameraRig OVRPlayerController
        go.transform.position = anchor.transform.position;

    }
}
