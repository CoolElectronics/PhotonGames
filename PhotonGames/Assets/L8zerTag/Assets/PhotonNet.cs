using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
namespace L8zerTagNet
{
    public class PhotonNet : MonoBehaviourPunCallbacks
    {
        public void Awake(){
            PhotonNetwork.AutomaticallySyncScene = true;
            Connect();
            Debug.Log("Connecting...");
        }
        public override void OnConnectedToMaster(){
            Join();
            Debug.Log("Connected");
            base.OnConnectedToMaster();
        }
        public void Connect(){
            PhotonNetwork.GameVersion = "0.0.0";
            PhotonNetwork.ConnectUsingSettings();
            Debug.Log("Still Connecting...");
        }
        public void Join(){
            PhotonNetwork.JoinRandomRoom();
        }
        public override void OnJoinedRoom(){
            StartGame();
            Debug.Log("Joined");
            base.OnJoinedRoom();
        }
        public void StartGame(){
            if (PhotonNetwork.CurrentRoom.PlayerCount == 1){
                PhotonNetwork.LoadLevel(1);
                Debug.Log("Sucesess!");
            }
        }
        public override void OnJoinRandomFailed(short returnCode, string message){
            Create();
            base.OnJoinRandomFailed(returnCode,message);
            Debug.Log("Failed, Creating new Room");
        }
        public void Create(){
            PhotonNetwork.CreateRoom("");
        }
    }
}
