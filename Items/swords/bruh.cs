using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace samextendedweaponry.Items.swords
{
	public class bruh : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hilarously light sword");
			Tooltip.SetDefault("s p e e d  o f  l i g h t");
		}

		public override void SetDefaults()
		{
			item.damage = 7777;
			item.melee = true;
			item.width = 120;
			item.height = 130;
			item.useTime = 3;
			item.useAnimation = 20;
			item.channel = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = Item.buyPrice(0, 22, 50, 0);
			item.rare = 9;
			item.UseSound = SoundID.Item15;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("bruh_slash");
			item.shootSpeed = 40f;
		}
public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 10000);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}