using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Enums;
using MoreBackgrounds.Components;
using System;

namespace MoreBackgrounds.Backgrounds
{
    public class UrbanHunter
    {
        public static void Configure()
        {
            FeatureSelectionConfigurator.For(FeatureSelectionRefs.BackgroundsBaseSelection)
                .RemoveFromAllFeatures(a => a.Get() == FeatureRefs.BackgroundRekarthDLC2.Reference.Get())
                .Configure();

            FeatureConfigurator.For(FeatureRefs.BackgroundRekarthDLC2)
                .SetHideInUI(false)
                .SetHideNotAvailibleInUI(false)
                .RemoveComponents(a => a == FeatureRefs.BackgroundRekarthDLC2.Reference.Get().GetComponent<PrerequisiteFeature>())
                .AddStartingEquipment(null, new[] { WeaponCategory.Shortbow, WeaponCategory.Longbow })
                .ClearGroups()
                .Configure();

            FeatureSelectionConfigurator.For(FeatureSelectionRefs.BackgroundsStreetUrchinSelection)
                .AddToAllFeatures(FeatureRefs.BackgroundRekarthDLC2.ToString())
                .Configure(delayed: true);

        }
    }
}
