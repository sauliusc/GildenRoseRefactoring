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

                //increase quality logic
                if (sellItem.Name.Equals("Aged Brie") || sellItem.Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
                {
                    if (CanIncreaseQuality(sellItem))
                    {
                        sellItem.Quality = sellItem.Quality + 1;

                        if (sellItem.Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
                        {
                            if (sellItem.SellIn < 10 && CanIncreaseQuality(sellItem))
                            {
                                sellItem.Quality++;
                            }

                            if (sellItem.SellIn < 5 && CanIncreaseQuality(sellItem))
                            {
                                sellItem.Quality++;
                            }
                        }
                    }
                }
                else
                {
                    if (sellItem.Quality > 0)
                    {
                        sellItem.Quality--;
                    }
                }

                //quality changes if SellIn < 0
                if (sellItem.SellIn < 0)
                {
                    if (sellItem.Name.Equals("Aged Brie"))
                    {
                        if (sellItem.Quality < 50)
                        {
                            sellItem.Quality++;
                        }
                    }

                    else
                    {
                        if (sellItem.Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
                        {
                            sellItem.Quality = 0;
                        }
                        else
                        {
                            if (sellItem.Quality > 0)
                            {
                                sellItem.Quality--;
                            } 
                        }
                    }
                }
            }
        }

        private bool CanIncreaseQuality(Item sellItem)
        {
            return sellItem.Quality < 50;
        }
    }
}
