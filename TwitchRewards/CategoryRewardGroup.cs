using System;
using System.Collections.Generic;
/*
AshuraStrike © 2025
Filename: CategoryRewardGroup.cs
*/
public class CPHInline
{
	bool DEBUG = false;
	private void logger(object s){
		if(DEBUG) CPH.LogInfo($"Category Reward Group: {s}");
	}

	private Dictionary<string, string> categoryNrewards;
	public void Init(){
		categoryNrewards = new Dictionary<string, string>();
		// Add categories and their reward group
		// categoryNrewards.Add("<Game name>","<Reward Group name>");
	}
	public bool Execute()
	{
		List<string> rewardGroup = new List<string>();
		string gameName = string.Empty;

		CPH.TryGetArg("rawInput", out gameName);
		logger($"gameName {gameName}");

		GameInfo gi = CPH.SetChannelGame(gameName);

		if(gi != null)
		{
			// Process dictionary
			logger($"gi.Name {gi.Name}");
			foreach (var kvp in categoryNrewards) {
				if(gi.Name.ToLower().Contains(kvp.Key.ToLower())){
					CPH.TwitchRewardGroupEnable(kvp.Value);
					rewardGroup.Add(kvp.Value);
					logger($"gi.Name: {gi.Name} contains: {kvp.Key}");
				}else{
					if(!rewardGroup.Contains(kvp.Value)){
						CPH.TwitchRewardGroupDisable(kvp.Value);
						logger($"rewardGroup DOESN'T contain: {kvp.Value}");
					}
				}
			}
			return true;
		}
		logger($"Could not find game named: {gameName}");
		return false;
	}
}