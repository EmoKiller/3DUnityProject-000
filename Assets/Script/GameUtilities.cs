using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class GameUtilities
{
    public static void UpdateHeroInfomation<T>(List<T> list, int indexHeroCLass) where T : TextMeshProUGUI
    {
        for (int i = 0; i <= list.Count - 1; i++)
        {
            list[i].text = ConfigDataHelper.GameConfig.heroConfig.heroClass[(HeroClassType)indexHeroCLass].baseAttribute[(AttributeType)i].value.ToString();

        }
    }
    
}
