namespace GildenRose.SellItem
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

            if (CanDecreaseQuality())
            {
                TryDecreaseQuality();

                if (SellItem.SellIn < 0)
                {
                    TryDecreaseQuality();
                }
            }
        }
    }
}
