using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPunCallbacks
{
    private GameObject target;
    private Vector3 pos;

    private void Awake()
    {
        pos = Random.insideUnitSphere * 10;

    }

    private void Start()
    {
        foreach (var item in FindObjectsOfType<Player>())
        {
            if (!item.photonView.IsMine)
            {
                target = item.gameObject;
            }
        }
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 3);
        if (Vector3.Distance(transform.position, pos) < 2)
        {
            pos = Random.insideUnitSphere * 10;
        }
        transform.LookAt(target.transform);
    }

    void FixedUpdate()
    {
        
    }
}
