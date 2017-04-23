using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour {

    public List<Blueprint> blueprints;
    public int blueprints_learnt;
    public int blueprints_can_be_crafted;

    public GameObject blueprint_list_panel;

    public GameObject blueprint_listitem_model;
    public GameObject[] blueprint_list;

    private bool refresh;

    // Use this for initialization
    void Start () {

        blueprints_learnt = 0;

        blueprints = new List<Blueprint>();

        string[] starting_blueprints = GameScenario.GetStartingBlueprints();
        for(int i = 0; i < starting_blueprints.Length; i++) {

            Blueprint bp;

            BlueprintDatabase.InitBlueprint(starting_blueprints[i], out bp);
            AddBlueprint(bp);
        }

        this.refresh = true;
	}
	
	// Update is called once per frame
	void Update () {

        // crafting tab is opened, refresh it
        if (this.refresh && GameManager.crafting_open_state) { 

            // refresh content only once
            this.refresh = false;

            // Is there something what could be crafted?
            this.checkBlueprintsAvailability();

            // Render blueprint list
            // TODO: according to filtration or search
            this.CheckBlueprints();

        } else {

            if (!GameManager.crafting_open_state) this.invokeRefresh();
        }


    } 

    /* Check learnt bluepritns and render them to list*/
    private void CheckBlueprints() {

        blueprint_list = new GameObject[blueprints_learnt];

        foreach (Transform child in blueprint_list_panel.transform) {
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 0; i < blueprints_learnt; i++) {

            Transform blueprint_listitem_text;

            // making bluepirnt list item from model
            blueprint_list[i] = Instantiate(blueprint_listitem_model);
            blueprint_list[i].transform.SetParent(blueprint_list_panel.transform);

            // finding text component
            blueprint_listitem_text = Utilities.GetChildrenByName(blueprint_list[i], "BlueprintListItemText");

            // text value
            blueprint_listitem_text.GetComponent<Text>().text = blueprints[i].output.name;

            // coloring text
            blueprint_listitem_text.GetComponent<Text>().color = blueprints[i].can_craft > 0 ? Colors.can_craft : Colors.cannot_craft;
        }
    }

    /* Checks blueprintlist if there is something that can be crafted*/
    private void checkBlueprintsAvailability() {

        blueprints_can_be_crafted = blueprints_learnt;

        for (int i = 0; i < blueprints_learnt; i++) {

            Blueprint blueprint = blueprints[i];
            int[] item_counts = new int[blueprint.component_count];

            blueprints.Remove(blueprint);

            for (int c = 0; c < blueprint.component_count; c++) {

                item_counts[c] = Inventory.HasThis(blueprint.components[c].name, blueprint.components[c].count);

                if (item_counts[c] == 0) {

                    // item is cannot be crafted due to missing components
                    blueprints_can_be_crafted--;
                    break;
                }
            }

            // sets available item and replaces blueprint information
            blueprint.can_craft = Mathf.Min(item_counts); ;
            blueprints.Add(blueprint);
        }
    }

    /* Adds blueprint if is not already stored*/
    private void AddBlueprint(Blueprint bp) {

        if(!blueprints.Contains(bp)) {

            //Debug.Log("Adding (id="+ bp.output.id + ") BP.name = "+bp.output.name);

            blueprints.Add(bp);
            blueprints_learnt++;
            this.invokeRefresh();
        }
    }

    /* Blueprint list needs refresh*/
    private void invokeRefresh() {

        this.refresh = true;
    }
}
