﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class SaveData
{
    public int narrativeProgress;

    public SaveData(int progress){
        // inventorySave = new Ingredient[inventory.Count];
        // for(int i = 0; i < inventorySave.Length; i++){
        //     inventorySave[i] = inventory[i];
        // }
        // narrativeProgress = progress;
    }
    
}
