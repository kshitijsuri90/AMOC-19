using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class backsceneincustomization : MonoBehaviour
{

    public Button backscene;

    // Start is called before the first frame update
    void Start()
    {
        backscene.onClick.AddListener(prescene);
    }


    void prescene()
    {
        SceneManager.LoadScene("SampleScene");
    }


    
}
