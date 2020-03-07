namespace csharpcore.SellItem
{
    public class ConjuredManaCakeItem : BaseSellItem
    {
        public ConjuredManaCakeItem(Item item)
            :base(item)
        {

        }

        public override void UpdateQuality()
        {
            UpdateSellIn();
            
            if (SellItem.Quality == MinQuality)
            {
                return;
            }

            SellItem.Quality -= (QualityUpdateStep * 2);

            if (SellItem.SellIn < 0)
            {
                SellItem.Quality -= (QualityUpdateStep * 2);
            }

            if (SellItem.Quality < MinQuality)
            {
                SellItem.Quality = MinQuality;
            }
        }
    }
}
