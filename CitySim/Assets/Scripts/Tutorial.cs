using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject nextButton;
    public GameObject undoButton;

    private TextMeshProUGUI text;
    public TextMeshProUGUI continueText;

    int tutorialStep = 0;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            tutorialStep++;

            switch (tutorialStep)
            {
                case 0:
                    text.text = "Here are the tools available to manage your city.";
                    break;
                case 1:
                    text.text = "Use WASD to move around your cities land.";
                    break;
                case 2:
                    text.text = "The top left shows your city balance as well as the current turn number.";
                    break;
                case 3:
                    text.text = "The bar on the right shows the co2 level.";
                    break;
                case 4:
                    text.text = "Press space to show and hide the shop. This is where you buy new buildings";
                    break;
                case 5:
                    text.text = "Left click a building in the shop to buy it and left click on an available space to build it.";
                    break;
                case 6:
                    undoButton.SetActive(true);
                    text.text = "Use the undo button at the top to remove previously placed buildings";
                    break;
                case 7:
                    nextButton.SetActive(true);
                    text.text = "Use the next turn button at the top to progress.";
                    break;
                case 8:
                    text.text = "";
                    continueText.text = "<<Press E to continue to game>>";
                    break;
                case 9:
                    SceneManager.LoadScene("Gameplay");
                    break;


            }

        }

       

    }
}
