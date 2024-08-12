using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums;
using System.Collections.Generic;
using Kingmaker.EntitySystem.Stats;

namespace MoreBackgrounds.Backgrounds
{
    public class RedMantis
    {
        private static readonly string FeatName = "Red Mantis";
        private static readonly string FeatGuid = "9244f12c-7e83-42b0-840c-b8493ad669db";
        public static void Configure()
        {
            List<BlueprintCore.Utils.Blueprint<Kingmaker.Blueprints.BlueprintUnitFactReference>> profList = new List<BlueprintCore.Utils.Blueprint<Kingmaker.Blueprints.BlueprintUnitFactReference>>();
            profList.Add(FeatureRefs.SawtoothSabreProficiency.ToString());
            profList.Add(FeatureRefs.BlindFight.ToString());

            FeatureConfigurator.New(FeatName, FeatGuid)
                .SetDisplayName("RedMantis.Name")
                .SetDescription("RedMantis.Description")
                .AddClassSkill(StatType.SkillStealth)
                .AddClassSkill(StatType.SkillMobility)
                .AddStartingEquipment(null, new[] { WeaponCategory.SawtoothSabre, WeaponCategory.SawtoothSabre })
                .AddFacts(profList)
                .AddProficiencies(weaponProficiencies: new[] { WeaponCategory.SawtoothSabre })
                .AddBackgroundClassSkill(StatType.SkillStealth)
                .AddBackgroundClassSkill(StatType.SkillMobility)
                .AddBackgroundWeaponProficiency(WeaponCategory.SawtoothSabre, stackBonusType: ModifierDescriptor.Trait, stackBonus: ContextValues.Constant(1))
                .Configure(delayed: true);

            FeatureSelectionConfigurator.For(FeatureSelectionRefs.BackgroundsOblateSelection).AddToAllFeatures(FeatName).Configure();

        }
    }
}
