using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeInvDatabase", menuName = "UpgradeInv/UpgradeSlot")]
public class UpgradeInvDatabase : ScriptableObject
{
    public UpgradeSlot[] slots;

    public UpgradeSlot GetUpgradeSlot(int index)
    {
        return slots[index];
    }

    public int GetUpgradeLength()
    {
        return slots.Length;
    }
}
