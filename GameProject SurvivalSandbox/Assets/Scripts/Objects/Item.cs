using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    private string object_name;
    private GameItem item;

    // Use this for initialization
    void Start () {

        object_name = transform.root.name;

        ItemDatabase.CreateItem(this.object_name, out this.item);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameItem GetItem() { return item; }
}
