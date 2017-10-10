using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class BuyManager : MonoBehaviour
{
    public ShopManager shopManager;
    public GameObject[] items;
    public int currentItemCode;

    public int currentCoin;
    int cost;

    public void Buy()
    {
        GetComponent<AudioSource>().Play();
        countCoin();
        disableItem();
        shopManager.btnToggleTextBox();
    }

    void countCoin()
    {
        currentCoin = PlayerPrefs.GetInt("Coin");
        cost = items[currentItemCode].GetComponent<Item>().itemCost;

        PlayerPrefs.SetInt("Coin", currentCoin - cost);
    }

    void disableItem()
    {
        string currentItemString = "Item" + currentItemCode.ToString();
        items[currentItemCode].GetComponent<Button>().interactable = false;
        items[currentItemCode].GetComponent<Item>().isBought = true;
        PlayerPrefs.SetInt(currentItemString, 1);
    }

}
