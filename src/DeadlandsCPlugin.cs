using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using Fisobs.Core;

using BepInEx;
using System.Security.Permissions;
using TestMod;

// IMPORTANT
// This requires Fisobs to work!
// Big thx to Dual-Iron (on github) for help with Fisobs!
// This code was based off of Dual-Iron's Centishield as practice, I didn't make parts of this! (Probably add more details on that later)

#pragma warning disable CS0618 // Do not remove the following line.
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace TestMod
{


    // See https://rainworldmodding.miraheze.org/wiki/Downpour_Reference/Mod_Directories

    [BepInPlugin("Deadlands.DeadLandsCreautres", "DeadLandsCreatures", "0.1.0")]
    public class Plugin : BaseUnityPlugin
    {
        public void OnEnable()
        {
            Content.Register(new OpalCritob());
            On.Room.Loaded += Room_Loaded;


        }

        private void Room_Loaded(On.Room.orig_Loaded orig, Room self)
        {
                        orig(self);
            for (int i = 0; i < self.roomSettings.placedObjects.Count; i++)
            {
                if (self.roomSettings.placedObjects[i].type == OpalCritob.Opal)
                {
                    PlacedObject currentObject = self.roomSettings.placedObjects[i];
                    AbstractPhysicalObject cactusAbstr = new OpalAbstract(self.world, self.GetWorldCoordinate(currentObject.pos), self.game.GetNewID());
                    self.abstractRoom.AddEntity(cactusAbstr);
                    break;
                }
            }

        }
    }

}