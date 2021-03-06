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

namespace MCForge
{
	/// <summary>
	/// The command class, used to store commands for players to use
	/// </summary>
	public class Command
	{
		internal static Dictionary<string, ICommand> Commands = new Dictionary<string, ICommand>();

		/// <summary>
		/// Add an array of referances to your command here
		/// </summary>
		/// <param name="command">the command that this referance... referances, you should most likely use 'this'</param>
		/// <param name="reference">the array of strings you want players to type to use your command</param>
		public static void AddReference(ICommand command, string[] reference)
		{
			foreach (string s in reference)
			{
				AddReference(command, s.ToLower());
			}
		}
		/// <summary>
		/// Add a referance to your command here
		/// </summary>
		/// <param name="command">the command that this referance... referances, you should most likely use 'this'</param>
		/// <param name="reference">the string you want player to type to use your command, you can use this method more than once :)</param>
		public static void AddReference(ICommand command, string reference)
		{
			if (Commands.ContainsKey(reference))
			{
				Server.Log("[ERROR]: Command " + command.Name + " tried to add a referance that already existed! (" + reference + ")", ConsoleColor.White, ConsoleColor.Red);
				return;
			}
			Commands.Add(reference.ToLower(), command);
		}
	}
}
