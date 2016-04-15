﻿using System;
using System.Collections.Generic;
using Farmhand;
using Farmhand.API;
using Farmhand.API.Crafting;
using Farmhand.API.Generic;
using Farmhand.API.Items;
using Farmhand.Logging;
using Farmhand.Registries;
using Farmhand.Registries.Containers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RecipeTestMod.Items;
using RecipeTestMod.Recipes;
using StardewValley;

namespace RecipeTestMod
{
    internal class RecipeTestMod : Mod
    {
        public static RecipeTestMod Instance;
        
        public override void Entry()
        {
            Instance = this;
            
            Farmhand.Events.GameEvents.OnAfterLoadedContent += GameEvents_OnAfterLoadedContent;
            Farmhand.Events.PlayerEvents.OnFarmerChanged += PlayerEvents_OnFarmerChanged;
        }

        private void GameEvents_OnAfterLoadedContent(object sender, System.EventArgs e)
        {
            Farmhand.API.Items.Item.RegisterItem(Heart.Information);
            Farmhand.API.Items.Item.RegisterItem(PuppyTail.Information);
            VoidStar.Recipe.RequiredMaterials.Add(new ItemQuantityPair() { Count = 10, ItemId = Heart.Information.Id });
            VoidStar.Recipe.RequiredMaterials.Add(new ItemQuantityPair() { Count = 2, ItemId = PuppyTail.Information.Id });
            Farmhand.API.Crafting.CraftingRecipe.RegisterRecipe(VoidStar.Recipe);
        }
        
        private void PlayerEvents_OnFarmerChanged(object sender, System.EventArgs e)
        {
            Farmhand.API.Player.Player.AddRecipe(VoidStar.Recipe.PrivateName);
            Farmhand.API.Player.Player.AddObject(Heart.Information.Id);
            Farmhand.API.Player.Player.AddObject(PuppyTail.Information.Id);
        }
        
    }
}