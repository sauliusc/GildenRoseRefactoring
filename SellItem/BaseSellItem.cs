namespace GildenRose.SellItem
{
    public abstract class BaseSellItem : ISellItem
    {
        protected Item SellItem { get; }
        protected int MinQuality { get; } = 0;
        protected int MaxQuality { get; } = 50;
        protected int QualityUpdateStep { get; } = 1;

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
            return SellItem.Quality < MaxQuality;
        }

        protected bool CanDecreaseQuality()
        {
            return SellItem.Quality > MinQuality;
        }

        protected void TryIncreaseQuality()
        {
            if (CanIncreaseQuality())
            {
                SellItem.Quality += QualityUpdateStep;
            }
        }

        protected void TryDecreaseQuality()
        {
            if (CanDecreaseQuality())
            {
                SellItem.Quality -= QualityUpdateStep;
            }
        }
    }
}
