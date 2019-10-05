using System;

namespace Design_Patterns.Creational
{
    abstract class ItemBase
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }

    abstract class ItemBuilderBase
    {
        protected ItemBase _item;

        public virtual ItemBase CreateItem()
        {
            SetName();
            SetPrice();

            return _item;
        }

        protected virtual void SetName()
        {
            // Get random name generator, and generate random name
        }

        protected abstract void SetPrice();
    }


    class ItemWeapon : ItemBase
    {
        public int Damage { get; set; }
    }

    class ItemBuilderWeapon : ItemBuilderBase
    {
        const int BASE_WEAPON_PRICE = 20;
        const int PRICE_PER_DAMAGE_POINT = 5;
        const int MIN_DAMAGE = 1;
        const int MAX_DAMAGE = 100;

        ItemWeapon Item
        {
            get => _item as ItemWeapon;
            set { _item = value; }
        }

        public ItemBuilderWeapon()
            => Item = new ItemWeapon();

        public override ItemBase CreateItem()
        {
            SetDamage();
            return base.CreateItem();
        }

        void SetDamage()
            => Item.Damage = new Random().Next(MIN_DAMAGE, MAX_DAMAGE);

        protected override void SetPrice()
            => _item.Price = BASE_WEAPON_PRICE + PRICE_PER_DAMAGE_POINT * Item.Damage;
    }
}
