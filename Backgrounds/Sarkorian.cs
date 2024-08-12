using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums;
using Kingmaker.EntitySystem.Stats;
using System.Collections.Generic;
using Kingmaker.TextTools;

namespace MoreBackgrounds.Backgrounds
{
    public class Sarkorian
    {
        private static readonly string FeatName = "Sarkorian Survivor";
        private static readonly string FeatGuid = "6dfba536-0a82-4be6-81d9-1b0c36e3be13";

        public static void Configure()
        {
            List<BlueprintCore.Utils.Blueprint<Kingmaker.Blueprints.BlueprintUnitFactReference>> profList = new List<BlueprintCore.Utils.Blueprint<Kingmaker.Blueprints.BlueprintUnitFactReference>>();
            profList.Add(FeatureRefs.GreataxeProficiency.ToString());
            profList.Add(FeatureRefs.GreatswordProficiency.ToString());
            profList.Add(FeatureRefs.FalchionProficiency.ToString());
            profList.Add(FeatureRefs.Diehard.ToString());

            FeatureConfigurator.New(FeatName, FeatGuid)
                .SetDisplayName("Sarkorian.Name")
                .SetDescription("Sarkorian.Description")
                .AddStartingEquipment(categoryItems: new[] { WeaponCategory.Greataxe, WeaponCategory.Greatsword, WeaponCategory.Falchion })
                .AddClassSkill(StatType.SkillLoreNature)
                .AddClassSkill(StatType.SkillAthletics)
                .AddFacts(profList)
                .AddProficiencies(weaponProficiencies: new[] { WeaponCategory.Greataxe, WeaponCategory.Greatsword, WeaponCategory.Falchion })
                .AddBackgroundClassSkill(StatType.SkillLoreNature)
                .AddBackgroundClassSkill(StatType.SkillAthletics)
                .AddBackgroundWeaponProficiency(WeaponCategory.Greataxe, stackBonusType: ModifierDescriptor.Trait, stackBonus: ContextValues.Constant(1))
                .AddBackgroundWeaponProficiency(WeaponCategory.Greatsword, stackBonusType: ModifierDescriptor.Trait, stackBonus: ContextValues.Constant(1))
                .AddBackgroundWeaponProficiency(WeaponCategory.Falchion, stackBonusType: ModifierDescriptor.Trait, stackBonus: ContextValues.Constant(1))
                .Configure(delayed: true);

            FeatureSelectionConfigurator.For(FeatureSelectionRefs.BackgroundsRegionalSelection).AddToAllFeatures(FeatName).Configure();
        }
    }
}
