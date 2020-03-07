namespace csharpcore.SellItem
{
    public class AgedBrieItem : BaseSellItem
    {
        public AgedBrieItem(Item sellItem)
            :base(sellItem)
        {
        }

        public override void UpdateQuality()
        {
            UpdateSellIn();
            TryIncreaseQuality();
            if (SellItem.SellIn < 0)
            {
                TryIncreaseQuality();
            }
        }
    }
}
