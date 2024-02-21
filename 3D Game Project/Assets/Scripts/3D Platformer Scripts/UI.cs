using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI CoinsCountText;
    private int _coinAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        CoinsCountText.text = "Coins: " + _coinAmount.ToString();
    }

    public void UpdateCoinCount()
    {
        _coinAmount++;
        CoinsCountText.text = "Coins: " + _coinAmount.ToString();
    }
}
