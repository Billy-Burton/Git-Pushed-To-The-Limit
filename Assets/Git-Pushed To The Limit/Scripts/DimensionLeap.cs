using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionLeap : MonoBehaviour
{
    //public GameObject VoidPlatforms;
    //public GameObject RealPlatforms;
    // Start is called before the first frame update

    //true = Reality, false = Void
    [Tooltip("Player Current Dimension: True = Reality, False = Void")]
    public bool dimension = true;
    public Player player;
    public GameObject playerLowerCheck;

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
            //VoidPlatforms.SetActive(false);
            //RealPlatforms.SetActive(true);
            dimension = true;
            player.gameObject.layer = 9;
            playerLowerCheck.gameObject.layer = 9;
            player.Immune = true;
            playerLowerCheck.gameObject.SetActive(false);
            StartCoroutine(ImmuneTimer());
        }

        else if (dimension == true)
        {
            //VoidPlatforms.SetActive(true);
            //RealPlatforms.SetActive(false);
            dimension = false;
            player.gameObject.layer = 10;
            playerLowerCheck.gameObject.layer = 10;
            player.Immune = true;
            playerLowerCheck.gameObject.SetActive(false);
            StartCoroutine(ImmuneTimer());

        }
    }
    IEnumerator ImmuneTimer()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        player.Immune = false;
        playerLowerCheck.gameObject.SetActive(true);
    }
}
