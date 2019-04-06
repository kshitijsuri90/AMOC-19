using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConeChange : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public Material[] material;
    public Button Next;
    public Button Prev;
    Renderer renderer;
    int next = 1, prev = 0, curr = 0;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        Next.onClick.AddListener(prevConeColor);
        Prev.onClick.AddListener(nextConeColor);
        Debug.Log("Working 0");
    }


    void prevConeColor()
    {
        curr++;
        curr = curr % 3;

        if (curr == 0)
        {
            renderer.material = material[0];
        }
        else if (curr == 1)
        {
            renderer.material= material[1];
        }
        else
        {
            renderer.material = material[2];
        }
    }

    void nextConeColor()
    {
        next = curr;
        curr = prev;
        prev--;
        if (prev == -1)
        {
            prev = 2;
        }

        if (curr == 0)
        {
            renderer.material = material[0];
        }
        else if (curr == 1)
        {
            renderer.material = material[1];
        }
        else
        {
            renderer.material = material[2];
        }
    }
}
