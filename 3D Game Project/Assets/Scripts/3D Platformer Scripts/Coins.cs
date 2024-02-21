using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Canvas").GetComponent<UI>().UpdateCoinCount();
            Destroy(this.gameObject, 0.2f);
        }
    }
}
