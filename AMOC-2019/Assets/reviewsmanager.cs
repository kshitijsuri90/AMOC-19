using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class reviewsmanager : MonoBehaviour
{

    public Button nextreview;
    public Button prevreview;
    public Button backscene;
    public RawImage[] imagearray = new RawImage[5];
    public Text reviewtxt;
    public GameObject[] models;

    public string[,] reviewstring = new string[4, 3];
    public int[,] reviewrating = new int[4, 3];

    private int number = 0;
    private int modelnumber;

    // Start is called before the first frame update
    void Start()
    {
        reviewstring[0, 0] = "Best Fruit Cake I have ever had.";
        reviewstring[0, 1] = "A must try dish.";
        reviewstring[0, 2] = "Best cake in the world.";
        reviewstring[1, 0] = "This people make the best coffee in the world.";
        reviewstring[1, 1] = "You will forget other places after this coffee.";
        reviewstring[1, 2] = "Out of the world.";
        reviewstring[2, 0] = "Best raviolli I have ever had.";
        reviewstring[2, 1] = "A must try dish.";
        reviewstring[2, 2] = "Best raviolli in the world.";
        reviewstring[3, 0] = "This people make the best pizza in the world.";
        reviewstring[3, 1] = "You will forget other places after this pizza.";
        reviewstring[3, 2] = "Out of the world.";

        reviewrating[0, 0] = 4;
        reviewrating[0, 1] = 3;
        reviewrating[0, 2] = 4;
        reviewrating[1, 0] = 4;
        reviewrating[1, 1] = 4;
        reviewrating[1, 2] = 2;
        reviewrating[2, 0] = 5;
        reviewrating[2, 1] = 3;
        reviewrating[2, 2] = 4;
        reviewrating[3, 0] = 4;
        reviewrating[3, 1] = 3;
        reviewrating[3, 2] = 4;

        modelnumber = PlayerPrefs.GetInt("modelno");
       // modelnumber = 2;
        for(int i=0;i<4;i++)
        {
            if (i == modelnumber)
            {
                models[i].SetActive(true);
            }
            else
            {
                models[i].SetActive(false);
            }
        }

        reviewtxt.text = reviewstring[modelnumber, number];
        for(int i=0;i<5;i++)
        {
            if(i<reviewrating[modelnumber,number])
            {
                imagearray[i].enabled = true;
            }
            else
            {
                imagearray[i].enabled = false;
            }
        }


        nextreview.onClick.AddListener(nextrev);
        prevreview.onClick.AddListener(prerev);
        backscene.onClick.AddListener(backsc);


    }


    void nextrev()
    {
        number++;
        number = number % 3;
        reviewtxt.text = reviewstring[modelnumber, number];
        for (int i = 0; i < 5; i++)
        {
            if (i < reviewrating[modelnumber, number])
            {
                imagearray[i].enabled = true;
            }
            else
            {
                imagearray[i].enabled = false;
            }
        }
    }

    void prerev()
    {
        number--;
        if(number<0)
            number = 2;
        reviewtxt.text = reviewstring[modelnumber, number];
        for (int i = 0; i < 5; i++)
        {
            if (i < reviewrating[modelnumber, number])
            {
                imagearray[i].enabled = true;
            }
            else
            {
                imagearray[i].enabled = false;
            }
        }
    }


    void backsc()
    {
        SceneManager.LoadScene("SampleScene");
    }


}
