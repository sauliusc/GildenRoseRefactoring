﻿using Xunit;
using FluentAssertions;

namespace GildenRose.Tests
{
    public class GildedRoseTest
    {
        [Theory]
        //0 sellin corner cases
        [InlineData(1, 1, 4)]
        [InlineData(2, 0, 3)]
        [InlineData(3, -1, 1)]
        [InlineData(4, -2, 0)]
        public void CommonProductShouldDecreaseCorrectly(int daysToDecrease, int expectedSellIn, int expectedQuality)
        {
            GeneralSingleProductTest(new Item { Name = "product", SellIn = 2, Quality = 5 }, daysToDecrease, expectedSellIn, expectedQuality);
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
        [InlineData(1, 11, 25)]
        [InlineData(2, 10, 26)]
        [InlineData(3, 9, 28)]
        //5 sellin corner cases
        [InlineData(6, 6, 34)]
        [InlineData(7, 5, 36)]
        [InlineData(8, 4, 39)]
        ////0 sellin corner cases
        [InlineData(11, 1, 48)]
        [InlineData(12, 0, 50)]
        [InlineData(13, -1, 0)]
        [InlineData(14, -2, 0)]
        public void BackstagepassesShouldDecreaseCorrectly(int daysToDecrease, int expectedSellIn, int expectedQuality)
        {
            GeneralSingleProductTest(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 24 }, daysToDecrease, expectedSellIn, expectedQuality);
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

        [Theory]
        //0 sellin corner cases
        [InlineData(1, 1, 7)]
        [InlineData(2, 0, 5)]
        [InlineData(3, -1, 1)]
        [InlineData(4, -2, 0)]
        public void ConjuredShouldDecreaseCorrectly(int daysToDecrease, int expectedSellIn, int expectedQuality)
        {
            GeneralSingleProductTest(new Item { Name = "Conjured Mana Cake", SellIn = 2, Quality = 9 }, daysToDecrease, expectedSellIn, expectedQuality);
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