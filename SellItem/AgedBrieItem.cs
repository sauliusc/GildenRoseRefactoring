namespace GildenRose.SellItem
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

            if (!CanIncreaseQuality())
            {
                return;
            }

            TryIncreaseQuality();

            if (SellItem.SellIn < 0)
            {
                TryIncreaseQuality();
            }
        }
    }
}
