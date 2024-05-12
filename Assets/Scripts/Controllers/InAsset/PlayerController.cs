using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            Debug.Log("OnNetworkSpawn");
        }
    }
}