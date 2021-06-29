using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class InventoryTracker : MonoBehaviour
{
    #region Public Variables
    [Tooltip("Takes in a Sprite and a name associated with that Sprite. The name should be the same as key used in inventoryDict. Place in order of appearance in inventory menu.")]
    public List<IngredientPicture> ingredientPicturesTemp = new List<IngredientPicture>();
    public Dictionary<string, Sprite> ingredientPictures = new Dictionary<string, Sprite>();
    [Tooltip("Spawnable Food prefab")]
    public Dictionary<string, int> inventory = new Dictionary<string, int>();
    public int max = 40;
    public int count = 0;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        foreach(IngredientPicture temp in ingredientPicturesTemp){
            ingredientPictures.Add(temp.name, temp.picture);
        }
        //destroys self if it is a duplicate
        // GameObject[] search = GameObject.FindGameObjectsWithTag("InventoryTracker");
        // if(search.Length > 1){
        //     Destroy(this.gameObject);
        // }
        // DontDestroyOnLoad(this.gameObject);
    }

    //adds modifier to amount in inventory linked to key
    //returns true if addition succesful
    //returns false if addition couldn't be done
    public void addOne(string name){
        if(count >= max){
            
        }
        else if(inventory.ContainsKey(name)){
            inventory[name] += 1;
        }
        else{
            inventory.Add(name, 1);
        }
        count++;
    }

    public void subOne(string name){
        if(inventory.ContainsKey(name)){
            count--;
            inventory[name] -= 1;
            if(inventory[name] < 1){
                inventory.Remove(name);
            }
        }
        
    }

    //returns a reference to a ingredient object
    //returns null if ingredient not found
    public Sprite getIngredient(string ingredientName){
        
        if(ingredientPictures.ContainsKey(ingredientName)){
            return ingredientPictures[ingredientName];
        }
        return null;
    }
    
    //spawns a foodObject at the given coordinates with the sprite of the given ingredient
    //returns false if the object wasn't spawned
    public bool spawnFood(string name, int texture, int warmth, int flavor, Vector3 coords){
        
        // FoodDrop dropped = Instantiate(foodObject, coords, Quaternion.identity);
        // dropped.setImage(getIngredient(name).picture);
        // dropped.setValues(texture, warmth, flavor, name);
        // dropped.gameObject.GetComponent<Rigidbody>().AddForce();
        return false;
    }

    //Saves current inventory state to savedData.smc
    public void save(){
        // BinaryFormatter formatter = new BinaryFormatter();
        // string path = Application.persistentDataPath + "/savedData.smc";
        // FileStream stream = new FileStream(path, FileMode.Create);
        
        // SaveData data = new SaveData(inventory, dialogueProg);
        // formatter.Serialize(stream, data);
        // stream.Close();
    }

    //Loads inventory state from savedData.smc
    public void load(){
        // Debug.Log("loading");
        // string path = Application.persistentDataPath + "/savedData.smc";
        // if(File.Exists(path)){
        //     BinaryFormatter formatter = new BinaryFormatter();
        //     FileStream stream = new FileStream(path, FileMode.Open);

        //     SaveData load = formatter.Deserialize(stream) as SaveData;

        //     inventory.Clear();
        //     foreach(Ingredient ingredient in load.inventorySave){
        //         inventory.Add(ingredient);
        //     }
        //     dialogueProg = load.narrativeProgress;
        // }
        // else{
        //     Debug.LogError("save file not found");
        // }
    }

    public void ClearInventory(){
        inventory.Clear();
        Debug.Log(inventory.Count);
    }
}

[System.Serializable]
public class IngredientPicture{
    public string name;
    public Sprite picture;
}

[System.Serializable]
public class Ingredient{
    public string name;
    public Ingredient(){
        // name = food.name;
        // float[] vars = food.getValues();
        // texture = vars[0];
        // warmth = vars[1];
        // flavor = vars[2];
    }
}