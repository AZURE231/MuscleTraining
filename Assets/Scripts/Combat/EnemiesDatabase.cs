using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemies", menuName = "EnemiesDatabase/Enemies")]
public class EnemiesDatabase : ScriptableObject
{
    public Enemy[] enemies;

    public int GetEnemiesLength()
    {
        return enemies.Length;
    }

    public Enemy GetEnemy(int index)
    {
        return enemies[index];
    }
}
