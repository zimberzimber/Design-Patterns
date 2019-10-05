using System;

namespace Design_Patterns.Creational
{
    enum MonsterType
    {
        Goblin = 1,
        Beholder = 2
    }

    interface IMonsterFactory
    {
        MonsterBase BuildMonster(MonsterType monsterType);
    }

    class MonsterFactory : IMonsterFactory
    {
        public MonsterBase BuildMonster(MonsterType monsterType)
        {
            switch(monsterType)
            {
                case MonsterType.Goblin:
                    return new Goblin();
                case MonsterType.Beholder:
                    return new Beholder();
                default:
                    throw new ArgumentException("Invalid monster type.", "monsterType");
            }
        }
    }

    abstract class MonsterBase
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }

        public abstract void Think();
    }

    class Goblin : MonsterBase
    {
        public override void Think()
        {
            // Attack player if in range
            // Otherwise move towards player
        }
    }

    class Beholder : MonsterBase
    {
        public override void Think()
        {
            // Move away from player if too close
            // Otherwise shoot at player
        }
    }
}