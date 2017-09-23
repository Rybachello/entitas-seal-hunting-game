using UnityEngine;
using System.Collections;
using Entitas.CodeGeneration.Attributes;

[Game, Unique, CreateAssetMenu]
public class Globals : ScriptableObject
{
    public GameObject holePrefab;
    public int rows;
    public int columns;

    public int width = 8;

    public int height = 8;

    public float spawnSealInterval = 5;
    public float totalTime = 30;

    public float ClickRadius = 30f;

    public Sprite[] SealSprites;
}