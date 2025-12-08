using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour, IGrabble

{
    [SerializeField] public ItemData itemData;
    [SerializeField]
    LeanTweenType easeType;
    
    
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
                + "/nThis is not the item you need to grab right now.");
            return false;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TargetSpawner"))
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            Debug.Log("Item Pos: " + pos);
    
            ScoreUpdate.Instance.PlayScoreAnimation(itemData, pos);
            StartCoroutine(DestroyItemAfterDelay(0.1f));
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
