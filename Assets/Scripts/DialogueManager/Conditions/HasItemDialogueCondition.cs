using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBStuff.DialogueSystem;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace LostInTheSnow
{
    [DialogueId("has_item")]
    public class HasItemDialogueCondition : IDialogueConditionFunc
    {
        public bool Condition(object[] args)
        {
            GameObject player = args[0] as GameObject;
            if (player.tag != "Player")
            {
                return false;
            }

            Inventory playerInv = player.GetComponent<Inventory>();
            if (playerInv == null)
            {
                return false;
            }

            bool negation = (bool)((JValue)args[1]).Value;
            int itemId = Int32.Parse((((JValue)args[2]).Value.ToString()));

            if (itemId == -1 && playerInv.CurrentItem == null && !negation)
            {
                return true;
            }

            if (itemId != -1 && playerInv.CurrentItem == null && negation)
            {
                return true;
            }

            if (playerInv.CurrentItem == null)
            {
                return false;
            }

            if (itemId == playerInv.CurrentItem.Id && !negation)
            {
                return true;
            }


            if (itemId != playerInv.CurrentItem.Id && negation)
            {
                return true;
            }


            return false;
        }
    }
}
