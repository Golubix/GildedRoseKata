using System;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != null && Items[i].Name.Trim() != "")
                {
                    int qualityUpdateStep = 0;

                    switch (Items[i].Name.Trim())
                    {
                        case "Aged Brie":

                            //Does it increase in its quality twice as fast after the SellIn date has passed?
                            qualityUpdateStep = (Items[i].SellIn <= 0 ? 2 : 1);
                            break;
                        case "Sulfuras, Hand of Ragnaros":

                            //Do nothing.
                            break;
                        case "Conjured Mana Cake":

                            qualityUpdateStep = (Items[i].SellIn <= 0 ? -4 : -2);
                            break;
                        case "Backstage passes to a TAFKAL80ETC concert":

                            qualityUpdateStep = (Items[i].SellIn <= 0 ? -Items[i].Quality :
                                (Items[i].SellIn <= 5 ? 3 :
                                    (Items[i].SellIn <= 10 ? 2 : 1)));
                            break;
                        default:

                            qualityUpdateStep = (Items[i].SellIn <= 0 ? -2 : -1);
                            break;
                    }

                    //Update Quality and SellIn.
                    if (Items[i].Name.Trim() != "Sulfuras, Hand of Ragnaros")
                    {
                        Items[i].Quality = Math.Min(Math.Max(0, Items[i].Quality + qualityUpdateStep), 50);
                        Items[i].SellIn = Items[i].SellIn - 1;
                    }
                }
            }
        }
    }
}
