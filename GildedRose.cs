using GildenRose.SellItem;
using System.Collections.Generic;
using System.Linq;

namespace GildenRose
{
    public class GildedRose
    {
        IEnumerable<ISellItem> _items;

        public GildedRose(IList<Item> items)
        {
            _items = items.Select(item => ResolveSellItem(item));
        }

        public void UpdateQuality()
        {
            foreach (ISellItem sellItem in _items)
            {
                sellItem.UpdateQuality();
            }
        }

        private ISellItem ResolveSellItem(Item item)
        {
            return item.Name switch
            {
                "Sulfuras, Hand of Ragnaros" => new SulfurasItem(item),
                "Aged Brie" => new AgedBrieItem(item),
                "Backstage passes to a TAFKAL80ETC concert" => new BackStageItem(item),
                "Conjured Mana Cake" => new ConjuredManaCakeItem(item),
                _ => new OrdinarySellItem(item),
            };
        }
    }
}
