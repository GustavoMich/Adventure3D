using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ebac.Core.Singleton;

namespace Itens
{

    public enum ItemType
    {
        COIN,
        LIFE_PACK
    }

    public class ItemManager : Singleton<ItemManager>
    {
        public List<ItemSetup> itemSetups;


        private void Start()
        {
            Reset();

        }

        private void Reset()
        {
            foreach(var i in itemSetups)
            {
                i.soint.value = 0;
            }
            
        }

        public void AddByType(ItemType itemType, int amount = 1)
        {
            if (amount < 0) return;
            itemSetups.Find(i => i.itemType == itemType).soint.value += amount;
            
        }

        public void RemoveByType(ItemType itemType, int amount = -1)
        {
            if (amount > 0) return;

            var item = itemSetups.Find(i => i.itemType == itemType);
            item.soint.value -= amount;

            if (item.soint.value < 0) item.soint.value = 0;

        }

        private void AddCoin()
        {
            AddByType(ItemType.COIN);
        }

        private void AddLifePack()
        {
            AddByType(ItemType.LIFE_PACK);
        }
    }

    [System.Serializable]
    public class ItemSetup
    {
        public ItemType itemType;
        public SOInt soint;
    }
}
