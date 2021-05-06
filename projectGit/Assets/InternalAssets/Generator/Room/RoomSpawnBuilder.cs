using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawnBuilder : MonoBehaviour
{
    public List<Room> Build(Room room, GameObject container) {
        List<Room> rooms = new List<Room>();
        GameObject spawners = new GameObject("roomSpawners");
        spawners.transform.SetParent(container.transform);
        spawners.transform.position = room.transform.position;
        int verticalLen = room.height + room.bridgeLength;
        int horizontalLen = room.height + room.bridgeLength;
        if (room.openToTop) {
            Room newRoom = new Room();
            newRoom.openToBottom = true;
            
            GameObject topSpawner = createSpawner(spawners, room, "topSpawner");
            Vector3 transformPosition = new Vector3(0, verticalLen, 0);
            topSpawner.transform.position = topSpawner.transform.position + transformPosition;
            newRoom.position = topSpawner.transform.position;
            rooms.Add(newRoom);
        }
        if (room.openToLeft) {
            Room newRoom = new Room();
            newRoom.openToRight = true;
            GameObject leftSpawner = createSpawner(spawners, room, "leftSpawner");
            Vector3 transformPosition = new Vector3(-horizontalLen, 0, 0);
            leftSpawner.transform.position = leftSpawner.transform.position + transformPosition;
            newRoom.position = leftSpawner.transform.position;
            rooms.Add(newRoom);
        }
        if (room.openToBottom) {
            Room newRoom = new Room();
            newRoom.openToTop = true;
            GameObject bottomSpawner = createSpawner(spawners, room, "bottomSpawner");
            Vector3 transformPosition = new Vector3(0, -verticalLen, 0);
            bottomSpawner.transform.position = bottomSpawner.transform.position + transformPosition;
            newRoom.position = bottomSpawner.transform.position;
            rooms.Add(newRoom);
        }
        if (room.openToRight) {
            Room newRoom = new Room();
            newRoom.openToLeft = true;
            GameObject rightSpawner = createSpawner(spawners, room, "rightSpawner");
            Vector3 transformPosition = new Vector3(horizontalLen, 0, 0);
            rightSpawner.transform.position = rightSpawner.transform.position + transformPosition;
            newRoom.position = rightSpawner.transform.position;
            rooms.Add(newRoom);
        }
        return rooms;
    }
    GameObject createSpawner(GameObject parent, Room room, string name) {
        GameObject spawner = new GameObject(name);
        spawner.transform.SetParent(parent.transform);
        spawner.transform.position = parent.transform.position;

        BoxCollider2D colider = spawner.AddComponent<BoxCollider2D>() as BoxCollider2D;
        Rigidbody2D rigidBody = spawner.AddComponent<Rigidbody2D>() as Rigidbody2D;
        colider.isTrigger = true;
        rigidBody.isKinematic = true;
        return spawner;
    }
}
