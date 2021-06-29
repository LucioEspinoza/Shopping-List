using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextGenerator : MonoBehaviour
{
    public InventoryTracker tracker;
    public Text output;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ChangeText();
    }

    public void ChangeText(){
        string generation = "";
        output.text = GenerateShoppingList(generation);
    }

    string GenerateShoppingList(string input){
        foreach(KeyValuePair<string, int> pair in tracker.inventory){
            input += "<b>.</b>I have " + pair.Value + " " + pair.Key + "(s)\n";
        }
        if(tracker.count >= tracker.max){
            input += "<b>.</b>My shopping cart is full.";
        }
        return input;
    }
}
