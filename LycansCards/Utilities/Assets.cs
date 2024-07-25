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
        static private readonly string assetsPath = Paths.PluginPath + "/" + LycansCards.PLUGIN_FOLDER + "/Assets/";
        public Texture2D LoadTexture(string texturePath)
        {
            Texture2D texture = new Texture2D(1, 1);
            ImageConversion.LoadImage(texture, File.ReadAllBytes(assetsPath + texturePath));
            return texture;
        }
    }
}