using System;
using System.Reflection;
using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using Verse;
using UnityEngine;
using System.Linq;

namespace NekoBoiNick.SarcophagusPatch
{
  [StaticConstructorOnStartup]
  class Main
  {
    static Main()
    {
      new Harmony("nekoboinick.vanilla.sarcophaguspatch").PatchAll(Assembly.GetExecutingAssembly());
      Log.Message("Vanilla Sarcophagus Patch initialized. This mod uses Harmony (all patches are destructive): RimWorld.QualityUtility.SendCraftNotification", false);
    }
  }

  [HarmonyPatch(typeof(QualityUtility), "SendCraftNotification")]
  class SarcophagusPatch
  {
    [HarmonyPrefix]
    static bool SendCraftNotification(Thing thing, Pawn worker)
    {
      if (worker == null)
      {
        return false;
      }
      CompQuality compQuality = thing.TryGetComp<CompQuality>();
      if (compQuality == null)
      {
        return false;
      }
      CompArt compArt = thing.TryGetComp<CompArt>();
      if (compArt == null || thing is Building_Grave)
      {
        if (compQuality.Quality == QualityCategory.Masterwork)
        {
          Find.LetterStack.ReceiveLetter("LetterCraftedMasterworkLabel".Translate(), "LetterCraftedMasterworkMessage".Translate(worker.LabelShort, thing.LabelShort, worker.Named("WORKER"), thing.Named("CRAFTED")), LetterDefOf.PositiveEvent, thing, null, null, null, null);
          return false;
        }
        if (compQuality.Quality == QualityCategory.Legendary)
        {
          Find.LetterStack.ReceiveLetter("LetterCraftedLegendaryLabel".Translate(), "LetterCraftedLegendaryMessage".Translate(worker.LabelShort, thing.LabelShort, worker.Named("WORKER"), thing.Named("CRAFTED")), LetterDefOf.PositiveEvent, thing, null, null, null, null);
          return false;
        }
      }
      else
      {
        if (compQuality.Quality == QualityCategory.Masterwork)
        {
          Find.LetterStack.ReceiveLetter("LetterCraftedMasterworkLabel".Translate(), "LetterCraftedMasterworkMessageArt".Translate(compArt.GenerateImageDescription(), worker.LabelShort, thing.LabelShort, worker.Named("WORKER"), thing.Named("CRAFTED")), LetterDefOf.PositiveEvent, thing, null, null, null, null);
          return false;
        }
        if (compQuality.Quality == QualityCategory.Legendary)
        {
          Find.LetterStack.ReceiveLetter("LetterCraftedLegendaryLabel".Translate(), "LetterCraftedLegendaryMessageArt".Translate(compArt.GenerateImageDescription(), worker.LabelShort, thing.LabelShort, worker.Named("WORKER"), thing.Named("CRAFTED")), LetterDefOf.PositiveEvent, thing, null, null, null, null);
        }
      }
      return false;
    }
  }
}