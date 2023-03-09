using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class PhotonMenuController : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField roomName, nickName;
    [SerializeField] private TMP_Text lobbyMenu;
    private bool connected = false;


    private void Awake()
    {
        StartCoroutine(StartGameCor());
    }
    private IEnumerator StartGameCor()
    {
        PhotonNetwork.ConnectUsingSettings();
        yield return new WaitUntil(() => connected);
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected");
        connected = true;
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(roomName.text);
        PhotonNetwork.LocalPlayer.NickName = nickName.text;
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(roomName.text);
        PhotonNetwork.LocalPlayer.NickName = nickName.text;
    }
    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.PlayerList.Length == 2)
        {
            photonView.RPC("StartGame", RpcTarget.All);
        }
        else
        {
            Debug.Log("Joined");
        }
        photonView.RPC("UpdateUI", RpcTarget.All);
    }


    [PunRPC]
    public void StartGame()
    {
        PhotonNetwork.LoadLevel(3);
    }

    [PunRPC]
    private void UpdateUI()
    {
        lobbyMenu.text = string.Empty;
        foreach (var item in PhotonNetwork.PlayerList)
        {
            lobbyMenu.text += item.NickName + "\n";
        }
    }
}
