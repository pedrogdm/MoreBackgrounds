using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Items;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;

namespace MoreBackgrounds.Components
{
    [TypeId("53E28206-43B2-43F4-AECF-1829A8ADE4D3")]
    [AllowMultipleComponents]
    [ComponentName("Dex to damage stat for crossbow")]
    [AllowedOn(typeof(BlueprintUnitFact), false)]
    public class DeadshotComponent : UnitFactComponentDelegate, ISubscriber, IInitiatorRulebookSubscriber, IInitiatorRulebookHandler<RuleCalculateWeaponStats>, IRulebookHandler<RuleCalculateWeaponStats>
    {
        public void OnEventAboutToTrigger(RuleCalculateWeaponStats evt)
        {
            float Multiplier = 1f;

            ModifiableValueAttributeStat dexterity = evt.Initiator.Descriptor.Stats.Dexterity;

            if (dexterity.Bonus > 1)
            {
                if (evt.Weapon.Blueprint.Type.Category == WeaponCategory.HeavyCrossbow || evt.Weapon.Blueprint.Type.Category == WeaponCategory.LightCrossbow)
                {
                    evt.OverrideDamageBonusStat(StatType.Dexterity);
                    evt.OverrideDamageBonusStatMultiplier(Multiplier);
                }
            }
            else
            {
                evt.AddDamageModifier(1, new EntityFact(), descriptor: ModifierDescriptor.DexterityBonus);     
            }
        }

        public void OnEventDidTrigger(RuleCalculateWeaponStats evt)
        {
        }
    }
}
