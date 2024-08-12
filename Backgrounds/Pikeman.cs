using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums;
using Kingmaker.EntitySystem.Stats;
using System.Collections.Generic;

namespace MoreBackgrounds.Backgrounds
{
    public class Pikeman
    {
        private static readonly string FeatName = "Pikeman";
        private static readonly string FeatGuid = "201C20DD-769A-418C-A99F-E1A637D5A60F";
        public static void Configure()
        {
            List<BlueprintCore.Utils.Blueprint<Kingmaker.Blueprints.BlueprintUnitFactReference>> profList = new List<BlueprintCore.Utils.Blueprint<Kingmaker.Blueprints.BlueprintUnitFactReference>>();
            profList.Add(FeatureRefs.LongSpearProficiency.ToString());
            profList.Add(FeatureRefs.GlaiveProficiency.ToString());
            profList.Add(FeatureRefs.FauchardProficiency.ToString());
            profList.Add(FeatureRefs.LungeFeature.ToString());

            FeatureConfigurator.New(FeatName, FeatGuid)
                .SetDisplayName("Pikeman.Name")
                .SetDescription("Pikeman.Description")
                .AddClassSkill(StatType.SkillAthletics)
                .AddStartingEquipment(null, new[] { WeaponCategory.Longspear, WeaponCategory.Glaive, WeaponCategory.Bardiche, WeaponCategory.Fauchard })
                .AddFacts(profList)
                .AddProficiencies(weaponProficiencies: new[] { WeaponCategory.Longspear, WeaponCategory.Glaive, WeaponCategory.Bardiche, WeaponCategory.Fauchard })
                .AddBackgroundClassSkill(StatType.SkillAthletics)
                .AddBackgroundWeaponProficiency(WeaponCategory.Longspear, stackBonusType: ModifierDescriptor.Trait, stackBonus: ContextValues.Constant(1))
                .AddBackgroundWeaponProficiency(WeaponCategory.Glaive, stackBonusType: ModifierDescriptor.Trait, stackBonus: ContextValues.Constant(1))
                .AddBackgroundWeaponProficiency(WeaponCategory.Bardiche, stackBonusType: ModifierDescriptor.Trait, stackBonus: ContextValues.Constant(1))
                .AddBackgroundWeaponProficiency(WeaponCategory.Fauchard, stackBonusType: ModifierDescriptor.Trait, stackBonus: ContextValues.Constant(1))
                .Configure(delayed: true);

            FeatureSelectionConfigurator.For(FeatureSelectionRefs.BackgroundsWarriorSelection).AddToAllFeatures(FeatName).Configure();
        }
    }
}
