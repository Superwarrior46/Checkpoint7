using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

public class RoomList : MonoBehaviourPunCallbacks
{
    public GameObject prefabBtnRooms;
    public GameObject[] AllRooms;

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            if (AllRooms[i] != null)
            {
                Destroy(AllRooms[i]);
            }
        }

        AllRooms = new GameObject[roomList.Count];

        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].IsOpen && roomList[i].IsVisible && roomList[i].PlayerCount > 1)
            {
                GameObject room = Instantiate(prefabBtnRooms, Vector2.zero, Quaternion.identity, GameObject.Find("Content").transform);
                room.GetComponent<Room>().roomName.text = roomList[i].Name;

                AllRooms[i] = room;
            }
        }
    }
}
