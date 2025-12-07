using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour, IGrabble

{
    [SerializeField] public ItemData itemData;
    public bool GrabbingItem()
    {
        var itemType = PlayerInventory.Instance.GetNextItemSeq();
        if (itemType == itemData.itemType)
        {
            Debug.Log("Item Grabbed: " + itemData.itemName);
            StartCoroutine(DestroyItemAfterDelay(0.1f));
            return true;
            
        }
        else
        {
            Debug.Log($"Need ItemType: {itemType} But Item ItemType:{itemData.itemType}"
                +"/nThis is not the item you need to grab right now.");
            return false;

        }
    }
    public ItemData GetItemData()
    {
        return itemData;
    }
    IEnumerator DestroyItemAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
