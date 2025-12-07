using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public Sprite sprite;
    public GameObject itemPrefab;
}

public enum ItemType
{
    Apple,
    Grape,
    Candy,
    carrot,
    ham,
    garlic,
    HamBurger,
    cake,
}