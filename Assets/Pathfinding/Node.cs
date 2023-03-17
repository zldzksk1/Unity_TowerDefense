using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Pure C# is not serializable, so by entering this make pure c# to be serializable
public class Node //pure c#, can't be attached to gameobject
{
    public Vector2Int coordinates;
    public bool isWalkable;
    public bool isExplored;
    public bool isPath;
    public Node connectedTo;

    public Node(Vector2Int coordinates, bool isWalkable)
    {
        this.coordinates = coordinates;
        this.isWalkable = isWalkable;
    }
}
