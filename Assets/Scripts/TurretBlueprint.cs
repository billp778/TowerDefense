using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{

    public GameObject prefab;
    public int cost;

    public List<GameObject> turretLevels;

    public int upgradeCost;

    public int maxLevel;

    public int GetSellAmount()
    {
        return cost / 2;
    }

    public GameObject GetTurretPrefab(int level)
    {
        if (turretLevels.Count >= level)
        {
            return turretLevels[level - 1];
        }
        return null;
    }

}
