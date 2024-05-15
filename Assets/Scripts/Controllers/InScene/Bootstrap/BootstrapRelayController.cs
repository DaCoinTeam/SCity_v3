using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services;
using Unity.Services.Relay;
using Unity.Networking.Transport;

public class BootstrapRelayController : SingletonPersistent<BootstrapRelayController>
{
    private async void CreateRelayServer()
    {   
    }

    //void Example_KeepingConnectionAlive()
    //{
    //    // Update the NetworkDrivers regularly to ensure the host/player is kept online.
    //    if (HostDriver.IsCreated && isRelayServerConnected)
    //    {
    //        HostDriver.ScheduleUpdate().Complete();

    //        //Accept incoming client connections
    //        while (HostDriver.Accept() != default(NetworkConnection))
    //        {
    //            Debug.Log("Accepted an incoming connection.");
    //        }
    //    }

    //    if (PlayerDriver.IsCreated && clientConnection.IsCreated)
    //    {
    //        PlayerDriver.ScheduleUpdate().Complete();

    //        //Resolve event queue
    //        NetworkEvent.Type eventType;
    //        while ((eventType = clientConnection.PopEvent(PlayerDriver, out _)) != NetworkEvent.Type.Empty)
    //        {
    //            if (eventType == NetworkEvent.Type.Connect)
    //            {
    //                Debug.Log("Client connected to the server");
    //            }
    //            else if (eventType == NetworkEvent.Type.Disconnect)
    //            {
    //                Debug.Log("Client got disconnected from server");
    //                clientConnection = default(NetworkConnection);
    //            }
    //        }
    //    }
    //}
}
