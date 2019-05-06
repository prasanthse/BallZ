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
    private int levelNumber;
    public bool locked = true;
    
    void Start()
    {
        padlockAppearance(false, false);

        next = GameObject.FindGameObjectWithTag("LevelNext").GetComponent<Button>();
        previous = GameObject.FindGameObjectWithTag("LevelPrevious").GetComponent<Button>();

        levelNumber = 1;

        disableButton();

        next.onClick.AddListener(nextButton);
        previous.onClick.AddListener(previousButton);
    }

    void Update()
    {
        
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
            levelFrame.interactable = true;
            previous.interactable = false;
            next.interactable = true;
        }
        else if(levelNumber == 2)
        {
            levelFrame.interactable = false;
            previous.interactable = true;
            next.interactable = false;
        }
    }

    private void changeImage(Sprite levelImage)
    {

        if(levelNumber == 1)
        {
            levelFrame.image.overrideSprite = levelImage;
            padlockAppearance(false, false);
        }
        else if(levelNumber == 2)
        {
            if (locked)
            {
                padlockAppearance(true, true);
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
        levelFrame.image.overrideSprite = original;
    }

    private void levelUnLock(Sprite original)
    {
        applyAnimation();
        levelFrame.image.overrideSprite = original;
        locked = false;
    }

    private void applyAnimation()
    {
        for (float timer = 0; timer < 5; timer += Time.deltaTime)
        {
            padlockTop.transform.Translate(new Vector3(0, 5, 0) * unlockSpeed);
        }
        padlockAppearance(false, false);
    }

    private void padlockAppearance(bool body, bool top)
    {
        padlockBody.gameObject.SetActive(body);
        padlockTop.gameObject.SetActive(top);
    }
}
