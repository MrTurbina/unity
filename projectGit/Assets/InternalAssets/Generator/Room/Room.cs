using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    // Start is called before the first frame update
    public bool openToTop;
    public bool openToLeft;
    public bool openToBottom;
    public bool openToRight;
    public int width;
    public int height;
    public int bridgeLength;
    public GameObject block;

    public Vector3 position;
    public List<GameObject> Build(GameObject container, Room templateRoom)
    {
        List<GameObject> objects = new List<GameObject>();
        

        GameObject newRoom = instanceNewRoom(container);
        Room roomComponent = newRoom.GetComponent<Room>();
        newRoom.transform.position = templateRoom.position;

        roomComponent.block = templateRoom.block;
        roomComponent.width = templateRoom.width;
        roomComponent.height = templateRoom.height;

        roomComponent.openToTop = templateRoom.openToTop;
        roomComponent.openToLeft = templateRoom.openToLeft;
        roomComponent.openToBottom = templateRoom.openToBottom;
        roomComponent.openToRight = templateRoom.openToRight;
        

        RoomBuilder roomBuilder = newRoom.GetComponent<RoomBuilder>();
        RoomSpawnBuilder roomSpawnbuilder = newRoom.GetComponent<RoomSpawnBuilder>();
        
        roomBuilder.Build(roomComponent, block, newRoom);
        List<Room> rooms = roomSpawnbuilder.Build(roomComponent, newRoom);


        foreach (Room generatedRoom in rooms ) {
            GameObject instanceRoom = instanceNewRoom(container);
            instanceRoom.transform.position = generatedRoom.position;
            Room instanceRoomComponent = instanceRoom.GetComponent<Room>();
            instanceRoomComponent.width = templateRoom.width;
            instanceRoomComponent.height = templateRoom.height;
            instanceRoomComponent.bridgeLength = templateRoom.bridgeLength;
            instanceRoomComponent.block = templateRoom.block;


            instanceRoomComponent.openToTop = generatedRoom.openToTop;
            instanceRoomComponent.openToLeft = generatedRoom.openToLeft;
            instanceRoomComponent.openToBottom = generatedRoom.openToBottom;
            instanceRoomComponent.openToRight = generatedRoom.openToRight;
            instanceRoomComponent.position = generatedRoom.position;
            
            // instanceNewRoom.transform.position
            objects.Add(instanceRoom);
        }
        return objects;
        
    }
    private GameObject instanceNewRoom(GameObject container) {
        GameObject room = new GameObject("room");
        room.transform.SetParent(container.transform);
        room.transform.position = room.transform.position;
        
        room.AddComponent<Room>();
        room.AddComponent<RoomBuilder>();
        room.AddComponent<RoomSpawnBuilder>();

        return room;
    }
}
