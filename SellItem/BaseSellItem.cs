namespace csharpcore.SellItem
{
    public abstract class BaseSellItem : ISellItem
    {
        protected Item SellItem { get; }

        public BaseSellItem(Item sellItem)
        {
            SellItem = sellItem;
        }

        abstract public void UpdateQuality();

        protected void UpdateSellIn()
        {
            SellItem.SellIn--;
        }

        protected bool CanIncreaseQuality()
        {
            return SellItem.Quality < 50;
        }

        protected bool CanDecreaseQuality()
        {
            return SellItem.Quality > 0;
        }

        protected void TryIncreaseQuality()
        {
            if (CanIncreaseQuality())
            {
                SellItem.Quality++;
            }
        }

        protected void TryDecreaseQuality()
        {
            if (CanDecreaseQuality())
            {
                SellItem.Quality--;
            }
        }
    }
}
