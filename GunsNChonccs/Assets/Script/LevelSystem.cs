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

        while(currentEXP >= expUntilLevelUp)
        {
            tempEXP = currentEXP - expUntilLevelUp;
            expUntilLevelUp = expUntilLevelUp * levelModifier; //pissråtor.

            expUntilLevelUp = Mathf.Round(expUntilLevelUp);

            currentEXP = 0 + tempEXP;
            currentEXP = Mathf.Round(currentEXP);
            currentLevel += 1;
        }

    }
}
