using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCondition : MonoBehaviour {

    private float hp;
    private float hp_max;
    private float hp_regen_rate;    // per s
    private float hp_percent;
    private float hp_decrement;

    private float energy;
    private float energy_max;
    private float energy_regen_rate;
    private float energy_percent;
    private float energy_decrement;

    private GameObject condition_panel;

    private Transform cond_panel_hp;
    private Transform cond_panel_hp_max;
    private Transform cond_panel_hp_bar_act;
    private Transform cond_panel_energy;
    private Transform cond_panel_energy_max;
    private Transform cond_panel_energy_bar_act;

    private RectTransform rt_of_hp_bar;
    private RectTransform rt_of_energy_bar;

    private Vector3 energy_bar_100;

    // Use this for initialization
    void Start () {

        // TODO: should fetch form scenario or cfg file
        this.hp = 100;
        this.hp_max = 100;
        this.hp_regen_rate = 0.1f;
        this.hp_percent = 100;

        this.energy = 100;
        this.energy_max = 100;
        this.energy_regen_rate = 1.0f;
        this.energy_percent = 100;

        this.condition_panel = GameObject.FindGameObjectWithTag("PlayerConditions");

        this.cond_panel_hp = 
            Utilities.GetChildrenByName(condition_panel, "HpTextActual");
        this.cond_panel_hp_max = 
            Utilities.GetChildrenByName(condition_panel, "HpTextMax");
        this.cond_panel_hp_bar_act = 
            Utilities.GetChildrenByName(condition_panel, "HpBarActual");
        this.cond_panel_energy = 
            Utilities.GetChildrenByName(condition_panel, "EnergyTextActual");
        this.cond_panel_energy_max = 
            Utilities.GetChildrenByName(condition_panel, "EnergyTextMax");
        this.cond_panel_energy_bar_act = 
            Utilities.GetChildrenByName(condition_panel, "EnergyBarActual");


        rt_of_hp_bar = cond_panel_hp_bar_act.GetComponent<RectTransform>();
        rt_of_energy_bar = cond_panel_energy_bar_act.GetComponent<RectTransform>();

        energy_bar_100 = cond_panel_energy_bar_act.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        float fps = PlayerStatus.GetFps();

        this.Decrement(fps);
        this.Regenerate(fps);

        this.Percentages();
        this.RedrawCondPanel();
    }

    // Claculates decrementation of stats according to FPS (no jumps or delays)
    private void Decrement(float fps) {

        if (this.energy - this.energy_decrement < 0) this.energy = 0;
        else this.energy -= this.energy_decrement / fps;

        this.energy_decrement -= this.energy_decrement / fps;
    }

    // Calculates regeneration according to FPS (no jumps or delays)
    private void Regenerate(float fps) {

        float regen;

        // HP regen
        regen = hp_regen_rate / fps;

        if (regen + hp < hp_max) hp += regen;
        else hp = hp_max;

        // energy regen
        regen = energy_regen_rate / fps;

        if (regen + energy < energy_max) energy += regen;
        else energy = energy_max;
    }

    // Calculates percantages of conditions
    private void Percentages() {

        hp_percent = hp_max * hp / 100;
        energy_percent = energy_max * energy / 100;
    }

    // Redraw condition panel
    private void RedrawCondPanel() {

        cond_panel_hp.GetComponent<Text>().text = "" + Mathf.Round(hp);
        cond_panel_hp_max.GetComponent<Text>().text = "" + Mathf.Round(hp_max);
        cond_panel_energy.GetComponent<Text>().text = "" + Mathf.Round(energy);
        cond_panel_energy_max.GetComponent<Text>().text = "" + Mathf.Round(energy_max);

        //cond_panel_energy_bar_act.transform.position = new Vector3(
        //    energy_bar_size100.x - (energy_bar_size100.x * energy_percent / 100),
        //    energy_bar_size100.y, 0);


        //float new_x = energy_bar_size100.x - (energy_bar_size100.x * (100 - energy_percent) / 100 / 2);

        //float new_x = energy_bar_size100.x - (energy_bar_size100.x * (100 - energy_percent) / 100);

        //float new_x = energy_bar_100.x - cond_panel_energy_bar_act.transform.localScale.x/2;


        float new_x = energy_bar_100.x - (cond_panel_energy_bar_act.GetComponent<RectTransform>().sizeDelta.x * (100 - energy_percent) / 100 /2 );

        cond_panel_energy_bar_act.transform.localScale = new Vector3(energy_percent / 100, 1, 1);

        cond_panel_energy_bar_act.transform.position = new Vector3(
            new_x,
            energy_bar_100.y,
            energy_bar_100.z
            );



    }


    // Set decrementation of next energy check
    public void EnergyDec(float dec) {

        this.energy_decrement += dec;
    }
}
