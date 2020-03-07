using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item sellItem in Items)
            {
                //ignore sulfuras
                if (sellItem.Name.Equals("Sulfuras, Hand of Ragnaros"))
                    continue;

                sellItem.SellIn--;

                switch (sellItem.Name)
                {
                    case ("Aged Brie"):
                        if (CanIncreaseQuality(sellItem))
                        {
                            sellItem.Quality++;
                            if (sellItem.SellIn < 0 && CanIncreaseQuality(sellItem))
                            {
                                sellItem.Quality++;
                            }
                        }
                        break;
                    case ("Backstage passes to a TAFKAL80ETC concert"):
                        if (sellItem.SellIn < 0)
                        {
                            sellItem.Quality = 0;
                        }
                        else if (CanIncreaseQuality(sellItem))
                        {
                            sellItem.Quality++;

                            if (sellItem.SellIn < 10 && CanIncreaseQuality(sellItem))
                            {
                                sellItem.Quality++;
                            }

                            if (sellItem.SellIn < 5 && CanIncreaseQuality(sellItem))
                            {
                                sellItem.Quality++;
                            }
                        }
                        break;
                    default:
                        if (sellItem.Quality > 0)
                        {
                            sellItem.Quality--;
                        }
                        if (sellItem.SellIn < 0 && sellItem.Quality > 0)
                        {
                            sellItem.Quality--;
                        }
                        break;
                }
            }
        }

        private bool CanIncreaseQuality(Item sellItem)
        {
            return sellItem.Quality < 50;
        }
    }
}
