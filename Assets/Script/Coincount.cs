using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class Coincount : MonoBehaviour
{
    public Text CoinCountText;
    public Text CoinText;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoinCountText.text = count.ToString();
        CoinText.text = "Coins : " + count.ToString();
    }

    public void AddCount()
    {
        count++;

    }
}
