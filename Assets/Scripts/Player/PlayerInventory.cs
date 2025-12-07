using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;
    [Header("References")]
    [SerializeField] private PlayerZoneDetector zone;

    [Header("Item Grabbing Details")]
    [SerializeField] private bool isItemInRange;
    [SerializeField] private LayerMask whatIsItem;
    [SerializeField] private float itemCheckDistance = 2f;
    [SerializeField] private Vector3 itemCheckPosition;

    [SerializeField] private ItemData currenEquipped;
    [SerializeField] private const string itemGrab = "Press G to grab item";

    //ITEM RELATED METHODS
    private ItemType[] itemTypes = { ItemType.cake, ItemType.HamBurger, ItemType.garlic, ItemType.ham, ItemType.Apple, ItemType.Grape, ItemType.Candy, ItemType.carrot };
    [Header("List's")]
    [SerializeField] private List<ItemData> inventoryItems = new List<ItemData>();
    [SerializeField] private List<ItemType> itemSequence = new List<ItemType>();
    [SerializeField] private int currentItemIndex = 0;

    private void Awake()
    {
        Instance = this;
        if (zone == null)
            zone = GetComponent<PlayerZoneDetector>();
        if (itemCheckPosition == null)
            itemCheckPosition = transform.position - new Vector3(0, 0.7f, 0);
    }
    private void Start()
    {
        CreateASequenceOfItems();
    }
    void CreateASequenceOfItems()
    {
        for (int i = 0; i < 8; i++)
        {
            ItemType itemType = itemTypes[Random.Range(0, itemTypes.Length)];
            while (itemSequence.Contains(itemType))
            {
                itemType = itemTypes[Random.Range(0, itemTypes.Length)];
            }
            itemSequence.Add(itemType);
            Debug.Log("Item in Sequence: " + itemType);
        }
        CollectedItemUi.Instance.UpdateObjective(itemSequence[0]);
    }
    private void Update()
    {
        GrabbingItem();
    }
    public ItemType GetNextItemSeq()
    {
        return itemSequence[inventoryItems.Count];
    }


    private void GrabbingItem()
    {

        RaycastHit hit;
        isItemInRange = Physics.Raycast(transform.position - itemCheckPosition, transform.forward, out hit, itemCheckDistance, whatIsItem);
        if (isItemInRange)
        {
            hit.collider.TryGetComponent<IGrabble>(out var grabble);
            if (grabble != null)
            {
                var itemData = grabble.GetItemData();
            }
        }
        if ((Input.GetKeyDown(KeyCode.G) && isItemInRange) && (zone.inCollectZone == true))
        {
            hit.collider.TryGetComponent<IGrabble>(out var grabble);
            if (grabble != null)
            {
                AddItemToInvetory(hit.collider.gameObject);
            }
        }
    }
    private void AddItemToInvetory(GameObject item)
    {
        item.TryGetComponent<IGrabble>(out var grabble);
        if (grabble != null)
        {
            if (grabble.GrabbingItem())
            {
                ItemData data = grabble.GetItemData();
                inventoryItems.Add(data);
                int currentItemIndex = inventoryItems.Count - 1;
                CollectedItemUi.Instance.UiUpdate(currentItemIndex, data);
                if (itemSequence.Count > inventoryItems.Count)
                    CollectedItemUi.Instance.UpdateObjective(itemSequence[inventoryItems.Count]);
                else
                    CollectedItemUi.Instance.ThrowObjective();
            }
        }
    }
    public void EquippedItem(ItemData data)
    {
        if (currenEquipped != null)
            return;
        currenEquipped = data;

        var gO = Instantiate(data.itemPrefab, transform.position + 2f * transform.forward, Quaternion.identity);
        gO.GetComponent<Rigidbody>().AddForce(transform.forward * 5f, ForceMode.VelocityChange);
        currenEquipped = null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position - itemCheckPosition, transform.position - itemCheckPosition + transform.forward * itemCheckDistance);
    }
}


public interface IGrabble
{
    public bool GrabbingItem();
    public ItemData GetItemData();
}
