using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Sprite levelOne, levelTwo;
    public Button levelFrame;
    private Button next, previous;
    private int levelNumber;
    private bool locked = true;
    
    void Start()
    {

        next = GameObject.FindGameObjectWithTag("LevelNext").GetComponent<Button>();
        previous = GameObject.FindGameObjectWithTag("LevelPrevious").GetComponent<Button>();

        levelNumber = 1;

        disableButton();

        next.onClick.AddListener(nextButton);
        previous.onClick.AddListener(previousButton);
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
        changeImage(levelOne);
        disableButton();
    }

    private void disableButton()
    {
        if(levelNumber == 1)
        {
            previous.interactable = false;
            next.interactable = true;
        }
        else if(levelNumber == 2)
        {
            previous.interactable = true;
            next.interactable = false;
        }
    }

    private void changeImage(Sprite levelImage)
    {

        if(levelNumber == 1)
        {
            levelFrame.image.overrideSprite = levelImage;
        }
        else if(levelNumber == 2)
        {
            if (locked)
            {
                levelLock(levelImage);
            }
            else
            {
                levelUnLock(levelImage);
            }
        }
    }

    private void levelLock(Sprite original)
    {
       // imageGrayScale(ref original);
        levelFrame.image.overrideSprite = original;
    }

    private void levelUnLock(Sprite original)
    {
        //applyAnimation();
        levelFrame.image.overrideSprite = original;
        locked = false;
    }

    private void applyAnimation()
    {

    }

    private void imageGrayScale(ref Sprite gray)
    {
       
    }
}
