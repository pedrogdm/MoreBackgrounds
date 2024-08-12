using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums;
using System.Collections.Generic;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using MoreBackgrounds.Components;

namespace MoreBackgrounds.Backgrounds
{
    public class KnightErrant
    {
        private static readonly string FeatName = "Knight Errant";
        private static readonly string FeatGuid = "9be57b5b-0178-4805-bfd7-9a947a4d7fe2";            

        public static void Configure()
        {
            List<BlueprintCore.Utils.Blueprint<Kingmaker.Blueprints.BlueprintUnitFactReference>> profList = 
                new List<BlueprintCore.Utils.Blueprint<Kingmaker.Blueprints.BlueprintUnitFactReference>>();
            profList.Add(FeatureRefs.LongswordProficiency.ToString());
            profList.Add(FeatureRefs.BastardSwordProficiency.ToString());

            FeatureConfigurator.New(FeatName, FeatGuid)
                .SetDisplayName("KnightErrant.Name")
                .SetDescription("KnightErrant.Description")
                .AddClassSkill(StatType.SkillKnowledgeWorld)
                .AddClassSkill(StatType.SkillMobility)
                .AddProficiencies(weaponProficiencies: new[] { WeaponCategory.Longsword, WeaponCategory.BastardSword })
                .AddStartingEquipment(null, new[] { WeaponCategory.Longsword, WeaponCategory.BastardSword })
                .AddFacts(profList)
                .AddComponent<KnightErrantComponent>()
                .AddBackgroundClassSkill(StatType.SkillKnowledgeWorld)
                .AddBackgroundClassSkill(StatType.SkillMobility)
                .AddBackgroundWeaponProficiency(WeaponCategory.Longsword, stackBonusType: ModifierDescriptor.Trait, stackBonus: ContextValues.Constant(1))
                .AddBackgroundWeaponProficiency(WeaponCategory.BastardSword, stackBonusType: ModifierDescriptor.Trait, stackBonus: ContextValues.Constant(1))
                .Configure(delayed: true);

            FeatureSelectionConfigurator.For(FeatureSelectionRefs.BackgroundsWandererSelection).AddToAllFeatures(FeatName).Configure();
        }
    }
}

