using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour, IGrabble

{
    [SerializeField] public ItemData itemData;
    void Start()
    {
        var Uipos = Camera.main.WorldToScreenPoint(ScoreUpdate.Instance.transform.position);
        Debug.Log("UI Pos: " + Uipos);
    }
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
            ScoreUpdate.Instance.score += 10;
            ScoreUpdate.Instance.UpdateScoreInUi();
            StartCoroutine(LerpUI());
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

    IEnumerator LerpUI()
    {
        var Uipos = Camera.main.ScreenToWorldPoint(ScoreUpdate.Instance.transform.position);
        Uipos.z = 0;    
        Debug.Log("UI Pos: " + Uipos);
        float time = 0;
        float duration = 1f;
        while (time<duration)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, Uipos, time);
            yield return null;
        Debug.Log("Lerping to UI");
        }
        Destroy(gameObject);
    }
}
