using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;

namespace MoreBackgrounds.Components
{
    [TypeId("5fe2f5e3-2353-4bf4-98e2-0dc89f8c4e64")]
    [AllowMultipleComponents]
    [ComponentName("+2 attack bonus when fighting defensively")]
    [AllowedOn(typeof(BlueprintUnitFact), false)]
    public class KnightErrantComponent : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateAttackBonusWithoutTarget>, IActivatableAbilityStartHandler, IActivatableAbilityWillStopHandler
    {
        private readonly BlueprintActivatableAbility FightDefensively = ActivatableAbilityRefs.FightDefensivelyToggleAbility.Reference.Get();

        private bool active;

        public void HandleActivatableAbilityStart(ActivatableAbility ability)
        {
            if (ability?.Blueprint == FightDefensively)
            {
                active = true;
            }
        }

        public void HandleActivatableAbilityWillStop(ActivatableAbility ability)
        {
            if (ability?.Blueprint == FightDefensively)
            {
                active = false;
            }
        }

        public void OnEventAboutToTrigger(RuleCalculateAttackBonusWithoutTarget evt) 
        { 
        }

        public void OnEventDidTrigger(RuleCalculateAttackBonusWithoutTarget evt)
        {
            if (active)
            {
                evt.AddModifier(2, Fact, ModifierDescriptor.UntypedStackable);
                evt.Result += 2;
            }
        }
    }
}
