using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* Confirmation calling list*/
public enum ConfirmCall {

    UNKNOWN,

    TUTORIAL_BASICS,
    TUTORIAL_FIRST_STEPS,
};

/* List of back callings*/
public enum BackCall {

    UNKNOWN,

    MAIN_MENU,
};

/* Main menu screen list*/
public enum MainMenuScreen {

    UNKNOWN,

    MAIN_MENU,
    TUTORIALS,
}


public class MainMenu : MonoBehaviour {

    private ConfirmCall confirm;
    private BackCall back;
    private MainMenuScreen screen;
    private MainMenuScreen last_screen;

    private string[] tutorial_menu_texts;

    private Transform tutorial_text_title;
    private Transform tutorial_text;


    [SerializeField]
    GameObject mainmenu_panel;

    [SerializeField]
    GameObject confirm_button_panel;

    [SerializeField]
    GameObject back_button_panel;

    [SerializeField]
    GameObject tutorials_panel;

    [SerializeField]
    TextAsset tutorial_text_file;

    [SerializeField]
    GameObject tutorial_panel;

    // Use this for initialization
    void Start () {

        this.confirm = ConfirmCall.UNKNOWN;
        this.back = BackCall.UNKNOWN;
        this.screen = MainMenuScreen.MAIN_MENU;

        // convert text file to texts (string array)
        tutorial_menu_texts = tutorial_text_file.text.Split(
            new string[] {
                "--END--\r\n"
            }, 
            System.StringSplitOptions.None);

        // Get text and title from tutorial panel
        this.tutorial_text_title = Utilities.GetChildrenByName(this.tutorial_panel, "Title");
        this.tutorial_text = Utilities.GetChildrenByName(this.tutorial_panel, "Text");
    }
	

	// Update is called once per frame (slower)
	void FixedUpdate () {

        // exit if there is no change
        if (last_screen == screen) return;

        this.last_screen = screen;

        mainmenu_panel.SetActive(false);
        tutorials_panel.SetActive(false);
        back_button_panel.SetActive(false);
        confirm_button_panel.SetActive(false);

        switch (this.screen) {

            case MainMenuScreen.MAIN_MENU:
                this.mainmenu_panel.SetActive(true);
                break;

            case MainMenuScreen.TUTORIALS:
                this.tutorials_panel.SetActive(true);
                this.back_button_panel.SetActive(true);
                this.back = BackCall.MAIN_MENU;
                break;

            case MainMenuScreen.UNKNOWN:
            default:

                break;
        }
    }

    // Navigates to tutorial screen menu
    public void Tutorial() {

        this.screen = MainMenuScreen.TUTORIALS;
    }


    // Handling click on Tutorial basics button
    public void TutorialLevelBasics() {

        //SceneManager.LoadScene("_devel");
    }


    // Handles click on Tutorial first stapes button
    public void TutorialFirstSteps() {

        this.confirm_button_panel.SetActive(true);
        this.confirm = ConfirmCall.TUTORIAL_FIRST_STEPS;
        this.tutorial_text_title.GetComponent<Text>().text = 
            MenuText.GetTitle(this.tutorial_menu_texts[1]);
        this.tutorial_text.GetComponent<Text>().text =
            MenuText.GetText(this.tutorial_menu_texts[1]);
    }

    // Handles click on Tutorial advanced button
    public void TutorialAdvanced() {

        //SceneManager.LoadScene("_devel");
    }


    // Quits game
    public void Quit() {

        Application.Quit();
    }


    // Handling click on confirm button
    public void Confirm() {

        switch(this.confirm) {

            case ConfirmCall.TUTORIAL_FIRST_STEPS:
                SceneManager.LoadScene("_devel");
                break;

            case ConfirmCall.TUTORIAL_BASICS:
            default:
                Errors.Error("Unknown case! " + this.confirm.ToString());
                break;
        }
    }


    // Handles click on back button
    public void Back() {

        switch(this.back) {

            case BackCall.MAIN_MENU:
                this.screen = MainMenuScreen.MAIN_MENU;
                break;

            case BackCall.UNKNOWN:
            default:
                break;
        }
    }
}
