using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionLeap : MonoBehaviour
{ 
    public GameObject VoidPlatforms;
    public GameObject RealPlatforms;
    // Start is called before the first frame updat
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Leap();
        }

    }

    public void Leap()
    {
        if (VoidPlatforms.activeSelf == true)
        {
            VoidPlatforms.SetActive(false);
            RealPlatforms.SetActive(true);
        }
        else if (RealPlatforms.activeSelf == true)
        {
            VoidPlatforms.SetActive(true);
            RealPlatforms.SetActive(false);
        }
    }
}
