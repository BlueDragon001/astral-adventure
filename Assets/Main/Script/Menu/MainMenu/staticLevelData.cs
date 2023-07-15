using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class  staticLevelData
{
    public static List<string> completedLevel = new List<string>();
    public static List<string> allLevel = new List<string>();

    public static string currentLevel;

    public const string defaultLevel = "Level 01";
}
