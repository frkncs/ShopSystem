using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    #region Variables

    // Public Variables

    // Private Variables
    [SerializeField] private Button[] itemPurchaseButtons;

    #endregion Variables

    private void Start()
    {
        UpdateUI();
    }

    public void BuyItem()
    {
        string itemId = EventSystem.current.currentSelectedGameObject.name;

        if (itemId != null)
        {
            if (!BuyItemController.CheckItemPurchased(itemId))
            {
                BuyItemController.BuyItem(itemId);
                ItemPurchaseCompleted();
            }
            else
            {
                ItemAlreadyPurchased();
            }
        }
        else
        {
            ItemPurchaseFailed();
        }
    }

    private void UpdateUI()
    {
        foreach (var item in itemPurchaseButtons)
        {
            if (BuyItemController.CheckItemPurchased(item.name))
            {
                item.transform.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
                item.image.color = Color.grey;
                item.enabled = false;
            }
        }
    }

    private void ItemPurchaseCompleted()
    {
        Debug.Log("Item purchased successfully!");
        UpdateUI();
    }

    private void ItemPurchaseFailed()
    {
        Debug.Log("Item purchase failed!");
    }

    private void ItemAlreadyPurchased()
    {
        Debug.Log("Item is already purchased!");
    }
}