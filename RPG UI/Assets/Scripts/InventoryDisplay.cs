using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    #region Public Variables
    [Tooltip("Texts and Images for displaying the inventory.")]
    public List<Display> ingredientDisplays = new List<Display>();
    public InventoryTracker tracker;
    #endregion

    #region Private Variables
    private int OffsetX = 40; //amount of leeway in x axis
    private int OffsetY = 40; //amount of leeway in y axis
    private bool onScreen = false;

    #endregion

    // Start is called before the first frame update
    void Start()
    {        
        foreach(Display display in ingredientDisplays){
            display.Deactivate();
        }

    }

    // Update is called once per frame
    void Update()
    {
        displayIngredients();
        // checkForMouseOver();
        if(Input.GetKeyDown(KeyCode.I)){
            onScreen = !onScreen;
        }
    }

    //Displays all discovered ingredients on given display objects
    //If ingredient in ingredientPictures hasn't been discovered, it will be passed over when displaying
    private void displayIngredients(){
        int display = 0;
        foreach(KeyValuePair<string, int> pair in tracker.inventory){
            if(display > ingredientDisplays.Count){
                break;
            }
            ingredientDisplays[display].Activate();
            Debug.Log(pair.Key);
            ingredientDisplays[display].image.sprite = tracker.ingredientPictures[pair.Key];
            ingredientDisplays[display].count.text = "x" + pair.Value;
            display++;
            // Debug.Log(ingredient.name);
            // //if inventory has key
            // if(tracker.inventory.ContainsKey(ingredient.name)){
            //     ingredientDisplays[display].Activate();
            //     ingredientDisplays[display].image.sprite = ingredient.picture;
            //     ingredientDisplays[display].count.text = "x" + tracker.inventory[ingredient.name];
            //     display++;
            //     Debug.Log(tracker.inventory[ingredient.name]);
            // }
            
        }
    }

    //Checks if mouse has moved over an image
    private void checkForMouseOver(){
        // textActive = false;
        // foreach(Display target in ingredientDisplays){
        //     if(Input.mousePosition.x < target.image.gameObject.transform.position.x + OffsetX && 
        //     Input.mousePosition.x > target.image.gameObject.transform.position.x - OffsetX && 
        //     Input.mousePosition.y < target.image.gameObject.transform.position.y + OffsetY && 
        //     Input.mousePosition.y > target.image.gameObject.transform.position.y - OffsetY &&
        //     target.active){
        //         // textActive = true;
        //         // textureSlider.transform.gameObject.SetActive(true);
        //         // warmthSlider.transform.gameObject.SetActive(true);
        //         // flavorSlider.transform.gameObject.SetActive(true);

        //         // textureSlider.value = target.texture;
        //         // warmthSlider.value = target.warmth;
        //         // flavorSlider.value = target.flavor;
        //         //info should be displayed here
        //         // followerText.text = "Name: " + target.name + 
        //         //                     "\nTexture: " + target.texture + 
        //         //                     "\nWarmth: " + target.warmth + 
        //         //                     "\nFlavor: " + target.flavor;
        //     }
        //     else{
        //         // textureSlider.transform.gameObject.SetActive(false);
        //         // warmthSlider.transform.gameObject.SetActive(false);
        //         // flavorSlider.transform.gameObject.SetActive(false);
        //     }
        // }
    }
}

[System.Serializable]
public class Display{
    public Image image;
    public bool active = false;
    public Text count;

    //Sets all members inactive
    public void Deactivate(){
        image.gameObject.SetActive(false);
        count.gameObject.SetActive(false);
        active = false;
    }

    //Sets all members active
    public void Activate(){
        image.gameObject.SetActive(true);
        count.gameObject.SetActive(true);
        active = true;
    }
}