using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Sprite levelOne, levelTwo;
    public Button levelFrame;
    public Image padlockBody, padlockTop;
    public float unlockSpeed;
    private Button next, previous;
    private int levelNumber = 1;
    public static bool locked = true;
    
    void Start()
    {
        padlockAppearance(false, false);

        next = GameObject.FindGameObjectWithTag("LevelNext").GetComponent<Button>();
        previous = GameObject.FindGameObjectWithTag("LevelPrevious").GetComponent<Button>();

        disableButton();

        next.onClick.AddListener(nextButton);
        previous.onClick.AddListener(previousButton);
    }

    void Update()
    {
        if (locked)
        {
            if(levelNumber == 1)
            {
                padlockAppearance(false, false);
            }
            else if(levelNumber == 2)
            {
                padlockAppearance(true, true);
            }
        }else
        {
            padlockAppearance(false, false);
            levelFrame.interactable = true;
        }
    }

    private void nextButton()
    {
        levelNumber = 2;
        changeImage(levelTwo);
        disableButton();
    }

    private void previousButton()
    {
        levelNumber = 1;
        locked = true;
        changeImage(levelOne);
        disableButton();
    }

    private void disableButton()
    {
        if (locked)
        {
            if (levelNumber == 1)
            {
                levelFrame.interactable = true;
                previous.interactable = false;
                next.interactable = true;
            }
            else if (levelNumber == 2)
            {
                levelFrame.interactable = false;
                previous.interactable = true;
                next.interactable = false;
            }
        }
        else
        {
            levelNumber = 2;
            changeImage(levelTwo);
            previous.interactable = true;
            next.interactable = false;
        }
    }

    private void changeImage(Sprite levelImage)
    {
        levelFrame.image.overrideSprite = levelImage;
    }

    private void applyAnimation()
    { 
        padlockTop.transform.Translate(new Vector3(0, unlockSpeed, 0));
    }

    private void padlockAppearance(bool body, bool top)
    {
        padlockBody.gameObject.SetActive(body);
        padlockTop.gameObject.SetActive(top);
    }
}
