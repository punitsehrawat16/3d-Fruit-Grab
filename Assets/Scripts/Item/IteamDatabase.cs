using NUnit.Framework;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Scriptable Objects/ItemDatabase")]
public class IteamDatabase : ScriptableObject
{
   public ItemData[] items;
}
