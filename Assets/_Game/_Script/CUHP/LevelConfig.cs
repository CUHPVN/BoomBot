using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Game/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    public List<Transform> levelPrefabs = new();
}
