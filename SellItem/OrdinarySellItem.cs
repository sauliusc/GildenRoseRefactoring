namespace csharpcore.SellItem
{
    class OrdinarySellItem : BaseSellItem
    {
        public OrdinarySellItem(Item item) 
            :base(item)
        {

        }

        public override void UpdateQuality()
        {
            UpdateSellIn();
            TryDecreaseQuality();
            if (SellItem.SellIn < 0)
            {
                TryDecreaseQuality();
            }
        }
    }
}
