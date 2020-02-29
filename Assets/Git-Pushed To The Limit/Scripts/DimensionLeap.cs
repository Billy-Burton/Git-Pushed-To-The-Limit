using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionLeap : MonoBehaviour
{
    public GameObject VoidPlatforms;
    public GameObject RealPlatforms;
    // Start is called before the first frame update

    //true = Reality, false = Void
    public bool dimension = true;

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
        if (dimension == false)
        {
            VoidPlatforms.SetActive(false);
            RealPlatforms.SetActive(true);
            dimension = true;
        }

        else if (dimension == true)
        {
            VoidPlatforms.SetActive(true);
            RealPlatforms.SetActive(false);
            dimension = false;
        }
    }
}
