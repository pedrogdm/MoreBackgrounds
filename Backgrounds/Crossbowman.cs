using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using MoreBackgrounds.Components;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using System.Collections.Generic;

namespace MoreBackgrounds.Backgrounds
{
    public class Crossbowman
    {
        private static readonly string FeatName = "Crossbowman";
        private static readonly string FeatGuid = "EBEC6CF9-CBCC-4A63-BDF9-31345FFF123C";
        public static void Configure()
        {
            List<BlueprintCore.Utils.Blueprint<Kingmaker.Blueprints.BlueprintUnitFactReference>> profList = new List<BlueprintCore.Utils.Blueprint<Kingmaker.Blueprints.BlueprintUnitFactReference>>();
            profList.Add(FeatureRefs.LightCrossbowProficiency.ToString());
            profList.Add(FeatureRefs.HeavyRepeatingCrossbowProficiency.ToString());

            FeatureConfigurator.New(FeatName, FeatGuid)
                .SetDisplayName("Crossbowman.Name")
                .SetDescription("Crossbowman.Description")
                .AddClassSkill(StatType.SkillPerception)
                .AddClassSkill(StatType.SkillStealth)
                .AddStartingEquipment(null, new[] { WeaponCategory.LightCrossbow, WeaponCategory.HeavyCrossbow })
                .AddFacts(profList)
                .AddComponent<DeadshotComponent>()
                .AddBackgroundClassSkill(StatType.SkillPerception)
                .AddBackgroundClassSkill(StatType.SkillStealth)
                .AddBackgroundWeaponProficiency(WeaponCategory.LightCrossbow, stackBonusType: ModifierDescriptor.Trait, stackBonus: ContextValues.Constant(1))
                .AddBackgroundWeaponProficiency(WeaponCategory.HeavyCrossbow, stackBonusType: ModifierDescriptor.Trait, stackBonus: ContextValues.Constant(1))
                .Configure(delayed: true);

            FeatureSelectionConfigurator.For(FeatureSelectionRefs.BackgroundsWarriorSelection).AddToAllFeatures(FeatName).Configure();
        }
    }
}
