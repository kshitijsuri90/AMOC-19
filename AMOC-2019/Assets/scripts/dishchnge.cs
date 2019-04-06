using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dishchnge : MonoBehaviour
{

    public GameObject[] myDishes;
    public Button next;
    public Button previous;
    public Button customize;
    public Button info;
    public Button review;
    private bool infoshow = true;
    private int dishNumber = 0;
    public int numberOfDishes = 4;

    public Text dishname;
    public Text dishinfo;
    public Image bgndimge;

    string[] nameofdish = new string[4] {"Fruit Cream Cake","Coffee","Ravioli","Pizza"};
    string[] aboutdish = new string[4] { "This light and fruity cake is made with a class vanilla sponge recipe, smothered in sweetened whipped cream and topped with your favourite fruits.", "Dried coffee seeds (referred to as 'beans') are roasted to varying degrees, depending on the desired flavor. Roasted beans are ground and then brewed with near-boiling water to produce the beverage known as coffee.", "Ravioli are a type of dumpling comprising a filling enveloped in thin pasta dough. Usually served in broth or with a sauce, they originated as a traditional food in Italian cuisine. ", "Pizza is a savory dish of Italian origin, consisting of a usually round, flattened base of leavened wheat-based dough topped with tomatoes, cheese, and various other ingredients baked at a high temperature, traditionally in a wood-fired oven." };


    // Start is called before the first frame update
    void Start()
    {
        //myDishes = new GameObject[3];
        for(int i=0;i<numberOfDishes;i++)
        {
            if(i==0)
            {
                myDishes[i].SetActive(true);
                if(infoshow)
                {
                    dishname.text = nameofdish[i];
                    dishinfo.text = aboutdish[i];
                }
            }
            else
            {
                myDishes[i].SetActive(false);
            }
        }
        next.onClick.AddListener(nextDish);
        previous.onClick.AddListener(prevDish);
        customize.onClick.AddListener(chngescene);
        info.onClick.AddListener(changeinfo);
        review.onClick.AddListener(tellreview);
    }

    void nextDish()
    {
        dishNumber++;
        dishNumber = dishNumber % numberOfDishes;
        for(int i=0;i<numberOfDishes;i++)
        {
            if(i==dishNumber)
            {
                myDishes[i].SetActive(true);
                if (infoshow)
                {
                    dishname.text = nameofdish[i];
                    dishinfo.text = aboutdish[i];
                }
            }
            else
            {
                myDishes[i].SetActive(false);
            }
        }
    }

    void prevDish()
    {
        dishNumber--;

        if(dishNumber<0)
        {
            dishNumber = numberOfDishes - 1;
        }
        for (int i = 0; i < numberOfDishes; i++)
        {
            if (i == dishNumber)
            {
                myDishes[i].SetActive(true);
                if (infoshow)
                {
                    dishname.text = nameofdish[i];
                    dishinfo.text = aboutdish[i];
                }
            }
            else
            {
                myDishes[i].SetActive(false);
            }
        }
    }


    void chngescene()
    {
        SceneManager.LoadScene("customization");
    }

    void changeinfo()
    {
        if(infoshow)
        {
            infoshow = false;
            bgndimge.enabled = false;
            dishname.enabled = false;
            dishinfo.enabled = false;
        }
        else
        {
            infoshow = true;
            bgndimge.enabled = true;
            dishname.enabled = true;
            dishinfo.enabled = true;
            dishname.text = nameofdish[dishNumber];
            dishinfo.text = aboutdish[dishNumber];
        }
    }


    void tellreview()
    {
        PlayerPrefs.SetInt("modelno", dishNumber);
        SceneManager.LoadScene("reviews");
    }
}
