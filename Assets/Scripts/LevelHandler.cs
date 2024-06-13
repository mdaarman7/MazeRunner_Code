using UnityEngine;
public static class LevelHandler
{
    public static bool level2;
    public static void Active()
    {
        level2 = true;
    }
    public static void Deactive()
    {
        level2 = false;
    }
}