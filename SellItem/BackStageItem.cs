namespace csharpcore.SellItem
{
    public class BackStageItem : BaseSellItem
    {
        public BackStageItem(Item sellItem)
            :base(sellItem)
        {
        }

        public override void UpdateQuality()
        {
            UpdateSellIn();
            if (SellItem.SellIn < 0)
            {
                SellItem.Quality = 0;
                return;
            }
            TryIncreaseQuality();
            if (SellItem.SellIn < 10)
            {
                TryIncreaseQuality();
            }
            if (SellItem.SellIn < 5)
            {
                TryIncreaseQuality();
            }
        }
    }
}
