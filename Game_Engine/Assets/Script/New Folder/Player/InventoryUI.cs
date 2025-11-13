using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("슬롯 관련 설정")]
    public List<Transform> Slot;       // 각 슬롯 Transform 리스트
    public GameObject SlotItem;        // 슬롯 안에 들어갈 프리팹

    private List<GameObject> items = new List<GameObject>();  // 현재 표시 중인 아이템 목록

    [Header("아이템 아이콘 설정")]
    public Sprite dirtIcon;
    public Sprite grassIcon;
    public Sprite waterIcon;
    public Sprite diamondIcon;

    // 인벤토리 UI 갱신
    public void UpdateInventory(Inventory myInven)
    {
        // 1?? 기존 아이템 삭제
        foreach (var slotItem in items)
        {
            Destroy(slotItem);
        }
        items.Clear();

        // 2?? 인벤토리 데이터 순회
        int idx = 0;
        foreach (var item in myInven.items)
        {
            if (idx >= Slot.Count) break; // 슬롯 개수 초과 방지

            // 슬롯 프리팹 생성
            var go = Instantiate(SlotItem, Slot[idx].transform);
            go.transform.localPosition = Vector3.zero;
            items.Add(go);

            SlotItemPrefab sItem = go.GetComponent<SlotItemPrefab>();

            // 3?? 아이템 타입별 세팅
            Sprite icon = null;
            string label = "";

            switch (item.Key)
            {
                case BlockType.Dirt:
                    icon = dirtIcon;
                    label = "Dirt";
                    break;
                case BlockType.Grass:
                    icon = grassIcon;
                    label = "Grass";
                    break;
                case BlockType.Water:
                    icon = waterIcon;
                    label = "Water";
                    break;
              
            }

            // 4?? 프리팹에 데이터 반영
            if (sItem != null)
                sItem.ItemSetting(icon, label);

            idx++;
        }
    }
}