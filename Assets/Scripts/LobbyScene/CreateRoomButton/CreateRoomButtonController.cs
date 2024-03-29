using Mirror;
using UnityEngine;
using NetworkRoomManagerExt;

namespace LobbyScene.CreateRoomButton {

    [DisallowMultipleComponent]
    public class CreateRoomButtonController : MonoBehaviour {
        // NOTE:
        // Experimentally, CallStopHost is currently employed because the prototype is supposed to use LAN network hosted.
        // However, starting with dedicated server requires has to request the server to start and clients should connect to it as client-only.
        // Therefore, this method is going to be deprecated.
        public void CallStartHost() {
            var manager = NetworkManager.singleton as MatchNetworkRoomManager;
            manager.StartHost();
        }
    }
}