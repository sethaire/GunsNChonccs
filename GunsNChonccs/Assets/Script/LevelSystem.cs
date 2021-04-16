using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public float expUntilLevelUp = 100;

    public float currentLevel = 1;
    public float currentEXP;
    private float levelModifier = 1.20f;

    private float tempEXP;

    public float totalEXPGained;
    

    public void expGain (float experience)
    {
        currentEXP += experience;
        totalEXPGained += experience;

        if(currentEXP >= expUntilLevelUp)
        { 
            tempEXP = currentEXP - expUntilLevelUp;
            expUntilLevelUp = expUntilLevelUp * levelModifier;

            currentEXP = 0 + tempEXP;
            currentLevel += 1;

        }
    }
}
