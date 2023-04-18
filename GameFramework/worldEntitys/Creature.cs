using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework.Extra;
using GameFramework.Item;
using static GameFramework.IWorldEntity;

namespace GameFramework.worldEntitys
{
    public abstract class Creature : IWorldEntity
    {
        /// <summary>
        /// An entity that can act in the world
        /// </summary>
        /// <param name="posistion"></param>
        public Creature(Posistion posistion)
        {
            Posistion = posistion;
            AttackInventory = new ();
            DefenceInventory = new ();
            GameEngine.GameTickAct += Act;
            GameEngine.GameTickTakeDamage += TakeDamage;
            GameEngine.World.WorldEntities.Add(this);
        }

        /// <summary>
        /// The cretures health points
        /// </summary>
        public abstract int HP { get; set; }

        /// <summary>
        /// the creatures name
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The creatures posistion in the world
        /// </summary>
        public Posistion Posistion { get; set; }

        /// <summary>
        /// The creature's global orientation
        /// </summary>
        public IWorldEntity.Orientation Orientation { get; set; }

        /// <summary>
        /// A list of the attack items the creatures holds
        /// </summary>
        public List<AttackItem> AttackInventory { get; set; }

        /// <summary>
        /// A list of the defence items the creatures holds
        /// </summary>
        public List<DefenceItem> DefenceInventory { get; set; }

        /// <summary>
        /// The list index of the active atteac item
        /// </summary>
        public int ActiveAttackItemIndex { get; set; }
        
        /// <summary>
        /// Generates damage area from the creatures first weapon
        /// </summary>
        public void Attack()
        {
            if (AttackInventory.Count - 1 < ActiveAttackItemIndex)
                return;
            AttackItem? weapon = AttackInventory[ActiveAttackItemIndex];
                weapon.Attack(Posistion, Orientation);
            GameEngine.TraceSource.TraceEvent(
                System.Diagnostics.TraceEventType.Verbose,
                GameEngine.NextTraceId,
                $"{this.Name} made and attack."
            );
        }

        /// <summary>
        /// The things a creature does eatch game tick
        /// </summary>
        public abstract void Act();

        /// <summary>
        /// Counts up all the damage area damage minus the defence.
        /// </summary>
        private void TakeDamage()
        {
            int dmg = GameEngine.World.WorldEntities
                .Where(e => e is DamgeArea && e.Posistion == Posistion)
                .Select(e => (DamgeArea)e)
                .Sum(e => e.Damage);

            int defenceVal = DefenceInventory
                .Sum(i => i.Defence);

            int actualDmg = dmg - defenceVal;

            if (actualDmg < 0)
                actualDmg = 0;

            HP -= dmg;
            GameEngine.TraceSource.TraceEvent(
                    System.Diagnostics.TraceEventType.Verbose,
                    GameEngine.NextTraceId,
                    $"{this.Name} took {dmg} point of damage."
                );

            if (HP <= 0)
            {
                List<IItem> items = new List<IItem>();
                items.AddRange(AttackInventory);
                items.AddRange(DefenceInventory);
                new LootBag(Posistion, items);
                GameEngine.World.WorldEntities.Remove(this);
                GameEngine.GameTickAct -= Act;
                GameEngine.GameTickTakeDamage -= TakeDamage;
            }
        }

        /// <summary>
        /// Makes the creature move one position in a given direction
        /// </summary>
        /// <param name="orientation">The direction to move</param>
        protected void Move(Orientation orientation)
        {
            Orientation = orientation;
            switch (orientation)
            {
                case Orientation.North:
                    Posistion = new Posistion(Posistion.X, Posistion.Y + 1);
                    break;
                case Orientation.East:
                    Posistion = new Posistion(Posistion.X + 1, Posistion.Y);
                    break;
                case Orientation.South:
                    Posistion = new Posistion(Posistion.X, Posistion.Y - 1);
                    break;
                case Orientation.West:
                    Posistion = new Posistion(Posistion.X - 1, Posistion.Y);
                    break;
            }
        }
    }
}
