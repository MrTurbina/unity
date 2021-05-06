using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBuilder : MonoBehaviour{
    private GameObject block;
    private GameObject wallsGroup;
    public void DestroyWalls() {
        Destroy(wallsGroup);
    }
    public void Build(Room room, GameObject blockObj, GameObject container) {
        block = blockObj;

        wallsGroup = new GameObject("wallsGroup");
        wallsGroup.transform.SetParent(container.transform);
        wallsGroup.transform.position = room.transform.position;

        //
        float wallsX = (wallsGroup.transform.position.x - (room.width / 2));
        float wallsY = (wallsGroup.transform.position.y - (room.height / 2));

        topWall(wallsX, wallsY, wallsGroup, room);
        leftWall(wallsX, wallsY, wallsGroup, room);
        bottomWall(wallsX, wallsY, wallsGroup, room);
        rightWall(wallsX, wallsY, wallsGroup, room);
    }
    void rightWall(float wallsX, float wallsY, GameObject walls, Room room)
    {
        for (int i = 0; i < room.height; i++)
        {
            if (i == 0)
            {
                continue;
            }
            int centerBlock = room.height / 2;
            bool isCenterBlock = (i == centerBlock || i == centerBlock + 1 || i == centerBlock - 1);
            if (room.openToRight && isCenterBlock)
            {
                continue;
            }
            Vector2 position = new Vector2(wallsX + room.width - 1, wallsY + i);
            GameObject wall = Instantiate(block, position, Quaternion.identity);
            wall.transform.SetParent(walls.transform);
        }
    }
    void leftWall(float wallsX, float wallsY, GameObject walls, Room room)
    {
        for (int i = 0; i < room.height; i++)
        {
            if (i == room.height - 1)
            {
                continue;
            }
            int centerBlock = room.height / 2;
            bool isCenterBlock = (i == centerBlock || i == centerBlock + 1 || i == centerBlock - 1);
            if (room.openToLeft && isCenterBlock)
            {
                continue;
            }
            Vector2 position = new Vector2(wallsX, wallsY + i);
            GameObject wall = Instantiate(block, position, Quaternion.identity);
            wall.transform.SetParent(walls.transform);
        }
    }
    void topWall(float wallsX, float wallsY, GameObject walls, Room room)
    {
        for (int i = 0; i < room.width; i++)
        {
            if (i == room.width - 1)
            {
                continue;
            }
            int centerBlock = room.width / 2;
            bool isCenterBlock = (i == centerBlock || i == centerBlock + 1 || i == centerBlock - 1);
            if (room.openToTop && isCenterBlock)
            {
                continue;
            }
            Vector2 position = new Vector2(wallsX + i, wallsY + room.height - 1);
            GameObject wall = Instantiate(block, position, Quaternion.identity);
            wall.transform.SetParent(walls.transform);
        }
    }
    void bottomWall(float wallsX, float wallsY, GameObject walls, Room room)
    {
        for (int i = 0; i < room.width; i++)
        {
            if (i == 0)
            {
                continue;
            }
            int centerBlock = room.width / 2;
            bool isCenterBlock = (i == centerBlock || i == centerBlock + 1 || i == centerBlock - 1);
            if (room.openToBottom && isCenterBlock)
            {
                continue;
            }
            Vector2 position = new Vector2(wallsX + i, wallsY);
            GameObject wall = Instantiate(block, position, Quaternion.identity);
            wall.transform.SetParent(walls.transform);
        }
    }
}
