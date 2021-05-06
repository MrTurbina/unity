
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject startRoom;
    public GameObject block;
    public int width;
    public int height;

    void Start() {

        Room room = startRoom.GetComponent<Room>();
        room.block = block;
        room.width = width;
        room.height = height;
        room.openToTop = true;
        room.openToLeft = true;
        room.openToBottom = true;
        room.openToRight = true;
        List<GameObject> nextRooms = room.Build(this.transform.gameObject, room);
        // Debug.Log(nextRooms.Count);
        foreach(GameObject obj in nextRooms) {
            Room newRoom = obj.GetComponent<Room>();
            // newRoom.openToTop = false;
            // newRoom.openToLeft = false;
            // newRoom.openToBottom = false;
            // newRoom.openToRight = false;
            Room roombuilder = obj.GetComponent<Room>();
            roombuilder.Build(this.transform.gameObject, roombuilder);
            
            // rioombuilder.Build(this.transform.gameObject, room)
            // nextRooms = newRoom.Build(this.transform.gameObject);
        }
    }
    
}
