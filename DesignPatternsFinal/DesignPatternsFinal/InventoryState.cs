﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsFinal
{
    public class InventoryState : State
    {
        private static InventoryState _inventoryState;
        private static System.Windows.Forms.Form InventoryForm;
        
        public InventoryState()
        {
            if (_inventoryState == null)
            {
                //InventoryForm = new InventoryViewForm();
                _inventoryState = this;
                inventoryState = _inventoryState;
            }
        }

        public void toInventory()
        {
        }

        override public System.Windows.Forms.Form StateView()
        {
            return InventoryForm;
        }

        internal static State initInventoryState()
        {
            if (_inventoryState == null)
                _inventoryState = new InventoryState();
            return _inventoryState;
        }
    }
}
