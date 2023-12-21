using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class LevelData : ScriptableObject
{
    public List<Level> listLevel;
}
[Serializable]
public class Level
{
    public int id;
}