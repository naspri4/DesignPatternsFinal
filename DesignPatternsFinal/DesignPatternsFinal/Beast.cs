﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsFinal
{
    abstract class Beast : Character
    {
        public Beast() : base() {}

        override
        public IAbility turn(Party team, Party enemies)
        {
            Random rand = new Random();
            double choice = rand.NextDouble();
            if (choice > .75)
                return this.moves[(int)MOVES.DEFEND];
            else
                return this.moves[(int)MOVES.ATTACK];
        }
        override
        public Item inventoryShow(Party team, Inventory inv)
        {
            return null;
        }

        override
        public Character aim(Party enemy)
        {
            Random rand = new Random();
            int choice = rand.Next(enemy.size());
            return enemy.getCharacter(choice);
        }

		override
		public Item defeat()
		{
			Random rand = new Random ();
			double selection = rand.NextDouble ();
			if (selection > .6) 
			{
				return RandomItemGenerator.getItem();
			}
			return null;
		}
	}
}
