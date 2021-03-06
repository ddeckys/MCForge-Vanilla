﻿/*
Copyright 2011 MCForge
Dual-licensed under the Educational Community License, Version 2.0 and
the GNU General Public License, Version 3 (the "Licenses"); you may
not use this file except in compliance with the Licenses. You may
obtain a copy of the Licenses at
http://www.opensource.org/licenses/ecl2.php
http://www.gnu.org/licenses/gpl-3.0.html
Unless required by applicable law or agreed to in writing,
software distributed under the Licenses are distributed on an "AS IS"
BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
or implied. See the Licenses for the specific language governing
permissions and limitations under the Licenses.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCForge;

namespace CommandDll
{
    public class CmdReplaceAll : ICommand
    {
        public string Name { get { return "ReplaceAll"; } }
        public CommandTypes Type { get { return CommandTypes.building; } }
        public string Author { get { return "Gamemakergm"; } }
        public int Version { get { return 1; } }
        public string CUD { get { return ""; } }

        public void Use(Player p, string[] args)
        {
            List<Pos> stored = new List<Pos>();
            Pos pos = new Pos();
            int currentBlock = 0;
            byte type = 0;
            byte type2 = 0;
            if (args.Length != 2)
            {
                p.SendMessage("Invalid arguments!");
                Help(p);
                return;
            }
            try
            {
                type = Blocks.NameToByte(args[0]);
                type2 = Blocks.NameToByte(args[1]);
            }
            catch
            {
                p.SendMessage("Could not find block specified");
                return;
            }

            foreach (byte b in p.level.data)
            {
                if (b == type)
                {
                    Point3 meep = p.level.IntToPos(currentBlock);
                    pos.pos = meep;
                    stored.Add(pos);
                }
                currentBlock++;
            }

            //Permissions here.
            p.SendMessage(stored.Count + " blocks out of " + currentBlock + " are " + Blocks.ByteToName(type));

            //Blockqueue here

            foreach (Pos _pos in stored)
            {
                p.level.BlockChange((ushort)(_pos.pos.x), (ushort)(_pos.pos.z), (ushort)(_pos.pos.y), type2);
            }
            p.SendMessage("&4/replaceall finished!");
        }
        public void Help(Player p)
        {
            p.SendMessage("/replaceall [block] [block2] - Replaces all of [block] with [block2] in the map.");
        }
        public void Initialize()
        {
            string[] CommandStrings = new string[2] { "replaceall", "ra" };
            Command.AddReference(this, CommandStrings);
        }
        struct Pos
        {
            public Point3 pos;
        }
    }
}
