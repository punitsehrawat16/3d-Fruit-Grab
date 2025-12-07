using JetBrains.Annotations;
using System.Collections.Generic;
using NUnit.Framework;  
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectedItemUi : MonoBehaviour
{
    public static CollectedItemUi Instance;

    [Header("References")]
    [SerializeField] private PlayerZoneDetector zone;

    [Header("References")]
    [SerializeField] private Button[] Buttons;
    [SerializeField] private TextMeshProUGUI objectiveDisplay;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {

        foreach (var button in Buttons)
        {
            button.gameObject.SetActive(false);
        }
    }
    public void UiUpdate(int item_no, ItemData data)
    {
        Buttons[item_no].gameObject.SetActive(true);
        Buttons[item_no].image.sprite = data.sprite;
        Debug.Log(data);

        Buttons[item_no].onClick.AddListener(() => { if (zone.inThrowZone) { PlayerInventory.Instance.EquippedItem(data); Buttons[item_no].gameObject.SetActive(false); } }

        );
    }
    public void UpdateObjective(ItemType itemType)
    {
        string name = itemType.ToString();
        objectiveDisplay.text = "Objective: Collect " + name;
    }
    public void ThrowObjective()
    {
        objectiveDisplay.text = "Move To Next Zone And Throw Items";
    }
}
