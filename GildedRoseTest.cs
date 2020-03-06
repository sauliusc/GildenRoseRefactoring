using Xunit;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace csharpcore
{
    public class GildedRoseTest
    {
        [Theory]
        //0 sellin corner cases
        [InlineData(1, 1, 3)]
        [InlineData(2, 0, 2)]
        [InlineData(3, -1, 0)]
        [InlineData(4, -2, 0)]
        public void CommonProductShouldDecreaseCorrectly(int daysToDecrease, int expectedSellIn, int expectedQuality)
        {
            GeneralSingleProductTest(new Item { Name = "product", SellIn = 2, Quality = 4 }, daysToDecrease, expectedSellIn, expectedQuality);
        }

        [Theory]
        //0 sellin corner cases
        [InlineData(1, 1, 1)]
        [InlineData(2, 0, 2)]
        [InlineData(3, -1, 4)]
        //50 quality corner cases
        [InlineData(25, -23, 48)]
        [InlineData(26, -24, 50)]
        [InlineData(27, -25, 50)]
        public void AgedBrieShouldDecreaseCorrectly(int daysToDecrease, int expectedSellIn, int expectedQuality)
        {
            GeneralSingleProductTest(new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 }, daysToDecrease, expectedSellIn, expectedQuality);
        }

        [Theory]
        //10 sellin corner cases
        [InlineData(1, 11, 24)]
        [InlineData(2, 10, 25)]
        [InlineData(3, 9, 27)]
        //5 sellin corner cases
        [InlineData(6, 6, 33)]
        [InlineData(7, 5, 35)]
        [InlineData(8, 4, 38)]
        //0 sellin corner cases
        [InlineData(11, 1, 47)]
        [InlineData(12, 0, 50)]
        [InlineData(13, -1, 0)]
        [InlineData(14, -2, 0)]
        public void BackstagepassesShouldDecreaseCorrectly(int daysToDecrease, int expectedSellIn, int expectedQuality)
        {
            GeneralSingleProductTest(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 23 }, daysToDecrease, expectedSellIn, expectedQuality);
        }

        [Theory]
        [InlineData(1, 2, 80)]
        public void SulfurasShouldNeverChange(int daysToDecrease, int expectedSellIn, int expectedQuality)
        {
            GeneralSingleProductTest(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 2, Quality = 80 }, daysToDecrease, expectedSellIn, expectedQuality);
        }

        [Theory]
        [InlineData(1, -2, 80)]
        public void NegativeSellInSulfurasShouldNeverChange(int daysToDecrease, int expectedSellIn, int expectedQuality)
        {
            GeneralSingleProductTest(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -2, Quality = 80 }, daysToDecrease, expectedSellIn, expectedQuality);
        }

        private void GeneralSingleProductTest(Item itemToTest, int daysToDecrease, int expectedSellIn, int expectedQuality)
        {
            GildedRose gildedRose = new GildedRose(new[] { itemToTest });
            RepeatUpdateQuality(gildedRose, daysToDecrease);
            itemToTest.SellIn.Should().Be(expectedSellIn);
            itemToTest.Quality.Should().Be(expectedQuality);
        }


        private void RepeatUpdateQuality(GildedRose gildenRose, int repeatCount)
        {
            for (int i = 0; i < repeatCount; i++)
            {
                gildenRose.UpdateQuality();
            }
        }
    }
}