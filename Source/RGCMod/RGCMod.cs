using System;
using System.Collections;
using UnityEngine;
using Tasharen;
using TNet;

public class RGCMod : MonoBehaviour
{
	private bool toggle_GodMode = false;
	[NonSerialized]
	private float nextTick;

	void Start()
	{
		UIStatusBar.Show("RGCMod Loaded");
		UIGameChat.onCommand += rgc;
		this.nextTick = Time.time + 900f;
	}

	void Update()
	{
		SH();
		XH();
		if (this.nextTick < Time.time && MyPlayer.ship != null)
		{
			this.nextTick = Time.time + 900f;
			this.ZCR();
		}
		if (toggle_GodMode == true && TNManager.isAdmin)
        {
			if (MyPlayer.ship != null)
            {
				MyPlayer.ship.AdjustHP(1f);
				MyPlayer.ship.secondaryHealth = MyPlayer.ship.maxSailHealth;
            }
        }
	}


	void rgc(string text, ref bool handled)
	{
		if (text == "debugStats")
		{
			UIGameChat.AddMisc("MaxDamage" + MyPlayer.ship.maxDamage.ToString(), Color.white);
			UIGameChat.AddMisc("MaxSupport" + MyPlayer.ship.maxSupport.ToString(), Color.white);
			UIGameChat.AddMisc("Offensive Scale" + MyPlayer.ship.scaleOffense.ToString(), Color.white);
			UIGameChat.AddMisc("Defense Scale" + MyPlayer.ship.scaleDefense.ToString(), Color.white);
			UIGameChat.AddMisc("Support Scale" + MyPlayer.ship.scaleSupport.ToString(), Color.white);
			UIGameChat.AddMisc("Time Until next Tick" + (this.nextTick - Time.time).ToString(), Color.white);

			handled = true;
		}

		if (TNManager.isAdmin && text == "giveItems")
		{
			int level = MyPlayer.level;
			MyPlayer.AddItem(GameConfig.GenerateRandomHull(level, 5));
			MyPlayer.AddItem(GameConfig.GenerateRandomSails(level, 5));
			MyPlayer.AddItem(GameConfig.GenerateRandomAmmo(level, 5));
			MyPlayer.AddItem(GameConfig.GenerateRandomCannons(level, 5));
			MyPlayer.AddItem(GameConfig.GenerateRandomCaptain(level, 5));
			MyPlayer.AddItem(GameConfig.GenerateRandomCrew(level, 5));
			MyPlayer.AddItem(GameConfig.GenerateRandomSpecialist(level, 5));
			MyPlayer.AddItem(GameConfig.GenerateRandomSpecial(level));
			MyPlayer.syncNeeded = true;
			MyPlayer.Save();
			handled = true;
		}
		if (TNManager.isAdmin && text == "giveItems5")
		{
			int level = MyPlayer.level + 5;
			MyPlayer.AddItem(GameConfig.GenerateRandomHull(level, 20));
			MyPlayer.AddItem(GameConfig.GenerateRandomSails(level, 20));
			MyPlayer.AddItem(GameConfig.GenerateRandomAmmo(level, 20));
			MyPlayer.AddItem(GameConfig.GenerateRandomCannons(level, 20));
			MyPlayer.AddItem(GameConfig.GenerateRandomCaptain(level, 20));
			MyPlayer.AddItem(GameConfig.GenerateRandomCrew(level, 20));
			MyPlayer.AddItem(GameConfig.GenerateRandomSpecialist(level, 20));
			MyPlayer.AddItem(GameConfig.GenerateRandomSpecial(level));
			MyPlayer.syncNeeded = true;
			MyPlayer.Save();
			handled = true;
		}

		if (TNManager.isAdmin && text == "itemslevel12")
        {
			MyPlayer.AddItem(GameConfig.GenerateRandomHull(12, 5));
			MyPlayer.AddItem(GameConfig.GenerateRandomSails(12, 5));
			MyPlayer.AddItem(GameConfig.GenerateRandomAmmo(12, 5));
			MyPlayer.AddItem(GameConfig.GenerateRandomCannons(12, 5));
			MyPlayer.AddItem(GameConfig.GenerateRandomCaptain(12, 5));
			MyPlayer.AddItem(GameConfig.GenerateRandomCrew(12, 5));
			MyPlayer.AddItem(GameConfig.GenerateRandomSpecialist(12, 5));
			MyPlayer.AddItem(GameConfig.GenerateRandomSpecial(12));
			MyPlayer.syncNeeded = true;
			MyPlayer.Save();
			handled = true;
		}

		if (TNManager.isAdmin && text == "itemslevel16")
        {
			int itemlevel = 16;
			MyPlayer.AddItem(GameConfig.GenerateRandomHull(itemlevel, 5));
			MyPlayer.AddItem(GameConfig.GenerateRandomSails(itemlevel, 5));
			MyPlayer.AddItem(GameConfig.GenerateRandomAmmo(itemlevel, 5));
			MyPlayer.AddItem(GameConfig.GenerateRandomCannons(itemlevel, 5));
			MyPlayer.AddItem(GameConfig.GenerateRandomCaptain(itemlevel, 5));
			MyPlayer.AddItem(GameConfig.GenerateRandomCrew(itemlevel, 5));
			MyPlayer.AddItem(GameConfig.GenerateRandomSpecialist(itemlevel, 5));
			MyPlayer.AddItem(GameConfig.GenerateRandomSpecial(itemlevel));
			MyPlayer.syncNeeded = true;
			MyPlayer.Save();
			handled = true;
		}

		if (TNManager.isAdmin && text == "itemslevel20")
        {
			int itemlevel = 20;
			MyPlayer.AddItem(GameConfig.GenerateRandomHull(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomSails(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomAmmo(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomCannons(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomCaptain(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomCrew(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomSpecialist(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomSpecial(itemlevel));
			MyPlayer.syncNeeded = true;
			MyPlayer.Save();
			handled = true;
		}

		if (TNManager.isAdmin && text == "itemslevel25")
        {
			int itemlevel = 25;
			MyPlayer.AddItem(GameConfig.GenerateRandomHull(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomSails(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomAmmo(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomCannons(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomCaptain(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomCrew(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomSpecialist(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomSpecial(itemlevel));
			MyPlayer.syncNeeded = true;
			MyPlayer.Save();
			handled = true;
		}

		if(TNManager.isAdmin && text == "itemslevel30")
        {
			int itemlevel = 30;
			MyPlayer.AddItem(GameConfig.GenerateRandomHull(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomSails(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomAmmo(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomCannons(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomCaptain(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomCrew(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomSpecialist(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomSpecial(itemlevel));
			MyPlayer.syncNeeded = true;
			MyPlayer.Save();
			handled = true;
		}
		
		if(TNManager.isAdmin && text == "itemslevel300")
        {
			int itemlevel = 300;
			MyPlayer.AddItem(GameConfig.GenerateRandomHull(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomSails(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomAmmo(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomCannons(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomCaptain(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomCrew(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomSpecialist(itemlevel, 500));
			MyPlayer.AddItem(GameConfig.GenerateRandomSpecial(itemlevel));
			MyPlayer.syncNeeded = true;
			MyPlayer.Save();
			handled = true;
		}

		if (TNManager.isAdmin && text == "itemsquality")
        {
			int level = MyPlayer.level;
			MyPlayer.AddItem(GameConfig.GenerateRandomHull(level, 5000));
			MyPlayer.AddItem(GameConfig.GenerateRandomSails(level, 5000));
			MyPlayer.AddItem(GameConfig.GenerateRandomAmmo(level, 5000));
			MyPlayer.AddItem(GameConfig.GenerateRandomCannons(level, 5000));
			MyPlayer.AddItem(GameConfig.GenerateRandomCaptain(level, 5000));
			MyPlayer.AddItem(GameConfig.GenerateRandomCrew(level, 5000));
			MyPlayer.AddItem(GameConfig.GenerateRandomSpecialist(level, 5000));
			MyPlayer.AddItem(GameConfig.GenerateRandomSpecial(level));
			MyPlayer.syncNeeded = true;
			MyPlayer.Save();
			handled = true;
		}

		if (TNManager.isAdmin && text == "itemsquality2")
		{
			int level = MyPlayer.level + 5;
			MyPlayer.AddItem(GameConfig.GenerateRandomHull(level, 5000));
			MyPlayer.AddItem(GameConfig.GenerateRandomSails(level, 5000));
			MyPlayer.AddItem(GameConfig.GenerateRandomAmmo(level, 5000));
			MyPlayer.AddItem(GameConfig.GenerateRandomCannons(level, 5000));
			MyPlayer.AddItem(GameConfig.GenerateRandomCaptain(level, 5000));
			MyPlayer.AddItem(GameConfig.GenerateRandomCrew(level, 5000));
			MyPlayer.AddItem(GameConfig.GenerateRandomSpecialist(level, 5000));
			MyPlayer.AddItem(GameConfig.GenerateRandomSpecial(level));
			MyPlayer.syncNeeded = true;
			MyPlayer.Save();
			handled = true;
		}


		if (TNManager.isAdmin && text == "giveXP")
		{

			MyPlayer.AwardXP(10000f);
			handled = true;
		}
		if (TNManager.isAdmin && text == "giveSmallXP")
        {
			MyPlayer.AwardXP(1000f);
			handled = true;
        }

		if (TNManager.isAdmin && text == "kitStarter")
        {
			PlayerItem starterKit = new PlayerItem();
			starterKit.name = "Starter Kit";
			starterKit.info = "Comprised of all your families supplies before they were sent to gulag";
			starterKit.gold = 10000;
			starterKit.SetSalvage("gold", 7500);
			starterKit.SetSalvage("wood", 100);
			starterKit.SetSalvage("stone", 100);
			starterKit.SetSalvage("powder", 50);

			MyPlayer.AddItem(starterKit);
			handled = true;
        }

		if (TNManager.isAdmin && text == "kitGold")
        {
			PlayerItem kitGold = new PlayerItem();
			kitGold.name = "Gold Cache";
			kitGold.info = "A cache of gold, probably hidden treasure from a pirates plunder";
			kitGold.gold = 100000;
			kitGold.SetSalvage("gold", 10000);
			MyPlayer.AddItem(kitGold);
			handled = true;
        }

		if (TNManager.isAdmin && text == "kitXP")
        {
			PlayerItem kitXP = new PlayerItem();
			kitXP.name = "Books of Knowledge";
			kitXP.info = "A Cache of KNOWLEDGE, damn that's an old meme Arrrrgh!";
			kitXP.SetSalvage("xp", 5000);
			MyPlayer.AddItem(kitXP);
			handled = true;
        }

		if (TNManager.isAdmin && text == "tgm")
        {
			TGM();
			handled = true;
        }

		if (text == "downgrade")
		{


			DataNode inventory = MyPlayer.inventory;
			int level = MyPlayer.level;

			DataNode dataNode = MyPlayer.equipment;
			dataNode = MyPlayer.inventory;
			for (int j = 0; j < dataNode.children.size; j++)
			{
				PlayerItem playerItem2 = dataNode.children[j].Get<PlayerItem>();
				if (playerItem2 != null && playerItem2.level > level)
				{
					playerItem2.MakeLevel(level);
					UIGameChat.AddMisc("Item: " + playerItem2.name + " which is NOW level " + playerItem2.level, Color.white);
				}
			}

			handled = true;
		}

	}
	private static string GetItemDescription(PlayerItem item, PlayerItem compareTo, bool mentionTP)
	{
		string text = string.Empty;
		text = GameTools.GetItemStats(item, compareTo);
		return text.Replace("\n", " | ");
	}

	private void TGM()
    {
		toggle_GodMode = !toggle_GodMode;
		if (toggle_GodMode == true)
        {
			UIStatusBar.Show("Godmode Enabled");
        }else
        {
			UIStatusBar.Show("Godmode Disabled");
        }
    }

	void SH()

	{

		UISprite fg = NGUITools.Draw<UISprite>("fg", delegate (UISprite sp)
		{
			sp.depth = -100000; ;
			//			sp.atlas = Resources.Load<UIAtlas>("UI/Atlas - Windward");
			//			sp.spriteName = "Flat";
			//			sp.type = UISprite.Type.Sliced;
			//			sp.color = new Color(0.25f, 1f, 0f, 1f);
			//			sp.alpha = 1f;
			sp.pivot = UIWidget.Pivot.TopLeft;
			sp.SetAnchor(0.52f, -100,
				0.06f, 10,
				0.52f, 100,
				0.06f, 20);

			UISprite spa = sp.gameObject.AddWidget<UISprite>(0);
			spa.depth = -1;
			spa.atlas = Resources.Load<UIAtlas>("UI/Atlas - Windward");
			spa.spriteName = "Flat";
			spa.type = UISprite.Type.Sliced;
			spa.color = new Color(0.25f, 1f, 0f, 1f);
			spa.pivot = UIWidget.Pivot.TopLeft;
			spa.SetAnchor(0f, 0,
				0f, 0,
				0.65f, 0,
				1f, 0);

			UISprite bg = sp.gameObject.AddWidget<UISprite>(0);
			bg.depth = -1;
			bg.atlas = spa.atlas;
			bg.spriteName = "Flat";
			bg.type = UISprite.Type.Sliced;
			bg.color = new Color(0.2f, 0.2f, 0.2f, 1f);
			bg.pivot = UIWidget.Pivot.TopLeft;
			bg.SetAnchor(0f, 0,
				0f, 0,
				0.65f, 0,
				1f, 0);

			UILabel lbl = sp.gameObject.AddWidget<UILabel>(2);
			lbl.name = "Speed";
			lbl.pivot = UIWidget.Pivot.BottomLeft;
			lbl.bitmapFont = Resources.Load<UIFont>("UI/Font - Qlassik22");
			lbl.fontSize = 14;
			lbl.effectStyle = UILabel.Effect.Shadow;
			lbl.gradientBottom = new Color(0.5f, 0.5f, 0.5f, 1f);
			lbl.SetAnchor(0f, 5,
				1f, 2,
				0f, sp.width - 10,
				1f, 30);

			UILabel lbl2 = sp.gameObject.AddWidget<UILabel>(2);
			lbl2.name = "Hull";
			lbl2.pivot = UIWidget.Pivot.BottomLeft;
			lbl2.bitmapFont = Resources.Load<UIFont>("UI/Font - Qlassik22");
			lbl2.fontSize = 14;
			lbl2.effectStyle = UILabel.Effect.Shadow;
			lbl2.gradientBottom = new Color(0.5f, 0.5f, 0.5f, 1f);
			lbl2.SetAnchor(0f, -65,
				0f, 3,
				0f, sp.width - 10,
				1f, 30);

			UILabel lbl3 = sp.gameObject.AddWidget<UILabel>(2);
			lbl3.name = "Sails";
			lbl3.pivot = UIWidget.Pivot.BottomLeft;
			lbl3.bitmapFont = Resources.Load<UIFont>("UI/Font - Qlassik22");
			lbl3.fontSize = 14;
			lbl3.effectStyle = UILabel.Effect.Shadow;
			lbl3.gradientBottom = new Color(0.5f, 0.5f, 0.5f, 1f);
			lbl3.SetAnchor(0f, 135,
				0f, 3,
				0f, sp.width - 10,
				1f, 30);

			UISlider slider = sp.gameObject.AddComponent<UISlider>();
			slider.backgroundWidget = bg;
			slider.foregroundWidget = spa;
		});

		GameShip ship = MyPlayer.ship;

		if (ship != null && ship.isActive)
		{
			fg.alpha = 1f;

			UISlider slider = fg.GetComponent<UISlider>();
			slider.value = Mathf.Abs(ship.relativeMovementSpeed);
			Transform child = slider.transform.FindChild("Speed");

			if (child != null)
			{
				UILabel lbl = child.GetComponent<UILabel>();
				if (lbl != null) lbl.text = ship.movementVelocity.magnitude.ToString("F1");
			}

			Transform child2 = slider.transform.FindChild("Hull");

			if (child != null)
			{
				UILabel lbl2 = child2.GetComponent<UILabel>();
				if (lbl2 != null)
					lbl2.text = (ship.health * ship.maxHealth).ToString("F0") + "/" + ship.maxHealth.ToString("F0");
			}

			Transform child3 = slider.transform.FindChild("Sails");

			if (child != null)
			{
				UILabel lbl3 = child3.GetComponent<UILabel>();
				if (lbl3 != null)
					lbl3.text = (ship.secondaryHealth * ship.maxSailHealth).ToString("F0") + "/" + ship.maxSailHealth.ToString("F0");
			}


		}
		else fg.alpha = 0f;

	}
	void XH()
	{

		UISprite xphud = NGUITools.Draw<UISprite>("xphud", delegate (UISprite xpa)
		{
			//			sp.atlas = Resources.Load<UIAtlas>("UI/Atlas - Windward");
			//			sp.spriteName = "Flat";
			//			sp.type = UISprite.Type.Sliced;
			//			sp.color = new Color(0.25f, 1f, 0f, 1f);
			//			sp.alpha = 1f;
			xpa.pivot = UIWidget.Pivot.TopLeft;
			xpa.SetAnchor(0.05f, 0,
				0.97f, -10,
				0.05f, 300,
				0.97f, 5);

			UILabel xplbl = xpa.gameObject.AddWidget<UILabel>(2);
			xplbl.name = "XP";
			xplbl.pivot = UIWidget.Pivot.BottomLeft;
			xplbl.bitmapFont = Resources.Load<UIFont>("UI/Font - Qlassik22");
			xplbl.fontSize = 14;
			xplbl.effectStyle = UILabel.Effect.Shadow;
			xplbl.gradientBottom = new Color(0.5f, 0.5f, 0.5f, 1f);
			xplbl.SetAnchor(0f, 5,
				1f, 2,
				0f, xpa.width - 10,
				1f, 30);


			UILabel lblXP = xpa.gameObject.AddComponent<UILabel>();
		});

		GameShip ship = MyPlayer.ship;
		int xp = MyPlayer.xp;
		int num;
		int num2;
		int num3;
		GameConfig.GetPointsFromXP(xp, out num, out num2, out num3);

		if (ship != null && ship.isActive)
		{
			xphud.alpha = 1f;

			UILabel labelXP = xphud.GetComponent<UILabel>();
			Transform childXP = labelXP.transform.FindChild("XP");

			if (childXP != null)
			{
				UILabel lblXP = childXP.GetComponent<UILabel>();
				if (lblXP != null)
					lblXP.text = "(TP)" + MyPlayer.talentPoints.ToString() + " (XP) " + xp.ToString("N0") + " / " + num3.ToString("N0");
				if (GameWorld.region != null)
					lblXP.text = lblXP.text + " | " + Localization.Get("Region") + " #" + GameWorld.region.id.ToString();
			}

		}
		else
			xphud.alpha = 0f;
	}
	void ZCR()
	{

		int[] factionList = new int[GameConfig.factions.children.size];
		for (int i = 0; i < GameWorld.zones.Length; i++)
		{
			ZoneData zoneData = GameWorld.zones[i];
			factionList[zoneData.zoneOwner]++;
		}
		MyPlayer.ModifyResource("gold", factionList[MyPlayer.factionID] * 10 * MyPlayer.talentPoints, true);
		MyPlayer.AwardXP(factionList[MyPlayer.factionID] * 2.5f * MyPlayer.talentPoints);
		UIGameChat.AddMisc("Faction Control Reward - Gold: " + (factionList[MyPlayer.factionID] * 10 * MyPlayer.talentPoints).ToString() + " XP: " + (factionList[MyPlayer.factionID] * 2.5f * MyPlayer.talentPoints).ToString(), Color.white);
	}
}