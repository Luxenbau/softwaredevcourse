using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseImage : MonoBehaviour
{
    public GameObject imagePanel;
    public int imageId;
    public GameObject chooseImageText;
    public CharacterCreation characterCreation;
    public bool isImageSelected;
    public List<Sprite> characterSpriteList = new List<Sprite>();
    public List<Sprite> monsterSpriteList = new List<Sprite>();
    public Image characterImage;

    public void SetImageId(int id)
    {
        isImageSelected = true;
        imageId = id;
        characterCreation.iconId = imageId;
        characterCreation.imageIsSet = true;
    }
    public void ResetCharacterImage()
    {
        isImageSelected = false;
        characterImage.sprite = null;
        characterCreation.imageIsSet = false;
        
    }
    void Update()
    {
        chooseImageText.SetActive(!isImageSelected);
        if (isImageSelected)
        {
            characterImage.sprite = characterSpriteList[imageId];
        }
    }
}
