using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BepInEx;
using UnityEngine;

namespace LycansCards.Utilities
{
    public class Assets
    {

        //const cards
        private const string VILLAGER_CARD = "villager_card.png";
        private const string HUNTER_CARD = "hunter_card.png";
        private const string ALCHEMIST_CARD = "alchemist_card.png";
        private const string WEREWOLF_CARD = "werewolf_card.png";
        private const string CARD_BACK = "card_back.png";

        static private readonly string assetsPath = Paths.PluginPath + "/" + LycansCards.PLUGIN_FOLDER + "/Assets/";
        static public Texture2D LoadTexture(string texturePath)
        {
            Texture2D texture = new Texture2D(1, 1);
            ImageConversion.LoadImage(texture, File.ReadAllBytes(assetsPath + "/Textures/" + texturePath));
            return texture;
        }
    }
}