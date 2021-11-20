using UnityEngine;

public class BuyItemController : MonoBehaviour
{
    #region Variables

    // Public Variables

    // Private Variables

    #endregion Variables

    public static void BuyItem(string itemId)
    {
        PlayerPrefs.SetInt(itemId + "Purchased", 1);
    }

    public static bool CheckItemPurchased(string itemId)
    {
        return PlayerPrefs.GetInt(itemId + "Purchased") == 1;
    }
}