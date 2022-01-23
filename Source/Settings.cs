﻿using Verse;

namespace Celsius
{
    public class Settings : ModSettings
    {
        public static bool ShowTemperatureMap;
        public static bool FreezingAndMeltingEnabled;
        public static bool AutoignitionEnabled;
        public static float HeatConductivityMultiplier;
        public static float HeatConductivityFactor;
        public static float ConvectionConductivityEffect;
        public static float HeatPushMultiplier;
        public static float HeatPushEffect;
        public static float AirHeatCapacity;
        public static bool DebugMode = Prefs.LogVerbose;

        public const float HeatConductivityFactor_Base = 1;
        public const float ConvectionConductivityEffect_Default = 200;
        public const float HeatPushEffect_Base = 5;
        public const float AirHeatCapacity_Default = 3000;

        public Settings() => Reset();

        public override void ExposeData()
        {
            Scribe_Values.Look(ref ShowTemperatureMap, "ShowTemperatureMap");
            Scribe_Values.Look(ref FreezingAndMeltingEnabled, "FreezingAndMeltingEnabled", true);
            Scribe_Values.Look(ref AutoignitionEnabled, "AutoignitionEnabled", true);
            Scribe_Values.Look(ref HeatConductivityMultiplier, "HeatConductivityMultiplier", 1);
            Scribe_Values.Look(ref ConvectionConductivityEffect, "ConvectionConductivityEffect", ConvectionConductivityEffect_Default);
            Scribe_Values.Look(ref HeatPushMultiplier, "HeatPushMultiplier", 1);
            Scribe_Values.Look(ref AirHeatCapacity, "AirHeatCapacity", AirHeatCapacity_Default);
            Scribe_Values.Look(ref DebugMode, "DebugMode", forceSave: true);
        }

        public static void Reset()
        {
            FreezingAndMeltingEnabled = true;
            AutoignitionEnabled = true;
            HeatConductivityMultiplier = 1;
            HeatConductivityFactor = HeatConductivityMultiplier * HeatConductivityFactor_Base;
            ConvectionConductivityEffect = ConvectionConductivityEffect_Default;
            HeatPushMultiplier = 1;
            HeatPushEffect = HeatPushMultiplier * HeatPushEffect_Base;
            AirHeatCapacity = AirHeatCapacity_Default;
            TemperatureUtility.SettingsChanged();
        }
    }
}
