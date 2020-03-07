using csharpcore.SellItem;
using System.Collections.Generic;
using System.Linq;

namespace csharpcore
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
            switch (item.Name)
            {
                case "Sulfuras, Hand of Ragnaros":
                    return new SulfurasItem(item);
                case "Aged Brie":
                    return new AgedBrieItem(item);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackStageItem(item);
                default:
                    return new OrdinarySellItem(item);
            }
        }
    }
}
