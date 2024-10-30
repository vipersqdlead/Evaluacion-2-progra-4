using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadImages : MonoBehaviour

{
    Image image;
    public string imgName;
    public string imgPath;

    // Start is called before the first frame update
    void Awake()
    {
        image = GetComponent<Image>();
        LoadImage(imgName);
    }

    public void LoadImage(string imageName)
    {
        //imgPath = Path.Combine("Images", imageName + ".png");
        imgPath = "Images/" + imageName ;
        Sprite sprite = Resources.Load<Sprite>(imgPath);

        if(sprite == null)
        {
            image.sprite = null;
            print("Image returned Null");
            return; 
        }
        image.sprite = sprite;
    }
}
