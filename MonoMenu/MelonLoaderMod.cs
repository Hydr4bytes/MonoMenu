using System;
using System.Collections.Generic;
using Il2CppSystem;
using MelonLoader;
using UnityEngine;
using Boneworks;
using BoneworksModdingToolkit;
using StressLevelZero.Interaction;
using StressLevelZero.Rig;
using StressLevelZero.UI;
using StressLevelZero.UI.Radial;
using MonoMenu.ElementStuff;

namespace MonoMenu
{
    public static class BuildInfo
    {
        public const string Name = "MonoMenu"; // Name of the Mod.  (MUST BE SET)
        public const string Author = "L4rs"; // Author of the Mod.  (Set as null if none)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class MonoMenu : MelonMod
    {
        public static List<MenuInterface> interfaces = new List<MenuInterface>();
        private static MenuInterface selectedMenu;
        AssetBundle UIBundle;
        GameObject MenuObject;

        public override void OnApplicationStart()
        {
            AssetBundles.LoadBundle("mono.menu", out UIBundle);
        }

        public override void OnLevelWasLoaded(int level)
        {
            MenuObject = CreateInterface();
            if (MenuObject != null)
            {
                AddMonoMenuButton();
            }
        }

		public void AddMonoMenuButton()
		{
			GameObject Rig = GameObject.Find("[RigManager (Default Brett)]");
			if (Rig)
			{
				Transform Panel = Rig.transform.Find("[UIRig]").Find("PLAYERUI").Find("panel_Default");
				if (!Panel)
					return;
				Transform Button_NW = Panel.transform.Find("button_Region_NW");
				if (Button_NW)
				{
					PageView pageView = Panel.GetComponent<PageView>();
					PageItemView pageItemView = Button_NW.GetComponent<PageItemView>();
					PopUpMenuView radial = GameObject.FindObjectOfType<PopUpMenuView>();
                    System.Action action = delegate ()
                    {
                        MenuObject.transform.position = radial.transform.position;
                        MenuObject.transform.rotation = radial.transform.rotation;
                        MenuObject.SetActive(!MenuObject.active);

                        radial.Deactivate();
                        radial.ForceHideCursor();
                    };
                    pageItemView.m_Data = new PageItem(BuildInfo.Name, PageItem.Directions.NORTHWEST, action);
                    pageView.m_HomePage.items.Add(pageItemView.m_Data);
				}
			}
		}

        private GameObject CreateInterface()
        {
            GameObject Asset = UIBundle.LoadAsset("Assets/MonoMenu.prefab").Cast<GameObject>();
            Asset = GameObject.Instantiate(MenuObject);
            Asset.SetActive(false);

            return Asset;
        }
    }
}
