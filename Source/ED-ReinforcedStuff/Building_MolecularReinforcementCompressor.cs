using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

using RimWorld;
using Verse;

namespace EnhancedDevelopment.ReinforcedStuff
{
    public class Building_MolecularReinforcementCompressor : Building
    {
        const int STUFF_AMMOUNT_REQUIRED = 10;

        CompPowerTrader m_Power;

        public override void SpawnSetup(Map map)
        {
            base.SpawnSetup(map);

            this.m_Power = base.GetComp<CompPowerTrader>();
        }

        public override void TickRare()
        {
            // Log.Message("TickRare");

            base.TickRare();

            if (this.m_Power.PowerOn)
            {
                this.TrySpawnReinforcedStuff();
            }
        }

        private void TrySpawnReinforcedStuff()
        {

            //Thing _NewResource = ThingMaker.MakeThing(ThingDef.Named("PlasteelReinforced"));
            Thing _OldResourceThing = this.GetValidThingStack();
            if (_OldResourceThing == null) { return; }

            ThingDef _NewResourceDef = this.GetReinforcedVersion(_OldResourceThing);
            if (_NewResourceDef == null) { return; }

            _OldResourceThing.SplitOff(10);

            Thing _NewResource = ThingMaker.MakeThing(_NewResourceDef);
            GenPlace.TryPlaceThing(_NewResource, this.InteractionCell, this.Map, ThingPlaceMode.Near);

        }

        private Thing GetValidThingStack()
        {
            List<IntVec3> _Cells = Enumerable.ToList<IntVec3>(Enumerable.Where<IntVec3>(GenAdj.CellsAdjacentCardinal((Thing)this), (Func<IntVec3, bool>)(c => GenGrid.InBounds(c, this.Map))));

            List<Thing> _closeThings = new List<Thing>();

            foreach (IntVec3 _Cell in _Cells)
            {
                _closeThings.AddRange(GridsUtility.GetThingList(_Cell, this.Map));
            }

            foreach (Thing _TempThing in _closeThings)
            {
                if (_TempThing.stackCount >= Building_MolecularReinforcementCompressor.STUFF_AMMOUNT_REQUIRED)
                {
                    ThingDef _ReinforcedVersion = this.GetReinforcedVersion(_TempThing);

                    if (_ReinforcedVersion != null)
                    {
                        return _TempThing;
                    }
                }
            }

            return null;
        }

        ThingDef GetReinforcedVersion(Thing sourceStuff)
        {
            //Log.Message("GetReinforcedVersion checking: " + sourceStuff.def.defName + " - " + sourceStuff.Stuff);

            //This will mostly work but will throw exceptions when trying to reinforce stuff that does not have a reinforced version.
            //return ThingDef.Named(sourceStuff.def.defName + "Reinforced");


            //SilverReinforced
            if (sourceStuff.def == ThingDefOf.Silver)
            {
                return ThingDef.Named("SilverReinforced");
            }
            
            //GoldReinforced
            if (sourceStuff.def == ThingDefOf.Gold)
            {
                return ThingDef.Named("GoldReinforced");
            }


            //SteelReinforced
            if (sourceStuff.def == ThingDefOf.Steel)
            {
                return ThingDef.Named("SteelReinforced");
            }

            //PlasteelReinforced
            if (sourceStuff.def == ThingDefOf.Plasteel)
            {
                return ThingDef.Named("PlasteelReinforced");
            }

            //WoodLogReinforced
            if (sourceStuff.def == ThingDefOf.WoodLog)
            {
                return ThingDef.Named("WoodLogReinforced");
            }

            //uraniumReinforced
            if (sourceStuff.def == ThingDef.Named("Uranium"))
            {
                return ThingDef.Named("UraniumReinforced");
            }
            //JadeReinforced
            if (sourceStuff.def == ThingDef.Named("Jade"))
            {
                return ThingDef.Named("JadeReinforced");
            }
            //BlocksSandstoneReinforced
            if (sourceStuff.def == ThingDef.Named("BlocksSandstone"))
            {
                return ThingDef.Named("BlocksSandstoneReinforced");
            }

            //BlocksGraniteReinforced
            if (sourceStuff.def == ThingDef.Named("BlocksGranite"))
            {
                return ThingDef.Named("BlocksGraniteReinforced");
            }

            //BlocksLimestoneReinforced
            if (sourceStuff.def == ThingDef.Named("BlocksLimestone"))
            {
                return ThingDef.Named("BlocksLimestoneReinforced");
            }

            //BlocksSlateReinforced
            if (sourceStuff.def == ThingDef.Named("BlocksSlate"))
            {
                return ThingDef.Named("BlocksSlateReinforced");
            }

            //BlocksMarbleReinforced
            if (sourceStuff.def == ThingDef.Named("BlocksMarble"))
            {
                return ThingDef.Named("BlocksMarbleReinforced");
            }

            return null;
        }

    }
}
