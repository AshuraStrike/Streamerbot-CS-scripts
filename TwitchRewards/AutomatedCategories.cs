using System;
using System.Collections.Generic;
/*
AshuraStrike © 2025
Filename: AutomatedCategories.cs
*/
public class CPHInline
{
	bool DEBUG = false;
	private void logger(object s){
		if(DEBUG) CPH.LogInfo($"AutomatedCategories: {s}");
	}

	private Dictionary<string, string> executableNcategories;
	public void Init(){
		executableNcategories = new Dictionary<string, string>();
		// executableNcategories.Add("<EXECUTABLE NAME>","<CATEGORY NAME>");
		executableNcategories.Add("Minecraft.Windows","Minecraft");
		executableNcategories.Add("Warframe.x64","Warframe");
	}
	public bool Execute()
	{
		string gameName = string.Empty;
		string executableName = string.Empty;
		CPH.TryGetArg("name", out executableName);

		// Automated Category
		if (executableName != null)
		{
			executableNcategories.TryGetValue(executableName, out gameName);
			logger($"Process watcher catched: {executableName}");
			if (gameName == null)
			{
				logger($"Not on the list!");
				return false;
			}

			logger($"Game name found: {gameName}");
			GameInfo gi = CPH.SetChannelGame(gameName);
			if (DEBUG && gi != null)
			{
				logger($"Category switched to: {gameName}");
			}
			else
			{
				logger($"Category with name: {gameName} NOT FOUND!!!");
			}
		}
		return true;
	}
}