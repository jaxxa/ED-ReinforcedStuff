using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

using RimWorld;
using Verse;

namespace ED_ReinforcedStuff
{
    public class Building_MolecularReinforcmentCompressor : Building
    {

        public override void TickRare()
        {
            Log.Message("TickLong");

            base.TickRare();
            Thing _NewResource = ThingMaker.MakeThing(ThingDef.Named("PlasteelReinforced"));

                     // Meal meal = (Meal)ThingMaker.MakeThing(ThingDefOf.MealNutrientPaste, (ThingDef)null);
            GenPlace.TryPlaceThing(_NewResource, this.InteractionCell, ThingPlaceMode.Near);
            
        }
    }
}
