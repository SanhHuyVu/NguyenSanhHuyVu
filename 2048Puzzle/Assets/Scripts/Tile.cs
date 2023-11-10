using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Tile : MonoBehaviour
{
    public Block OccupiedBlock;
    public Vector2 GetPos => transform.position;
}
