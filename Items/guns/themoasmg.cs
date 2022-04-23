using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace samextendedweaponry.Items.guns
{
	public class themoasmg : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("The M.O.A.SMGs"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display
			Tooltip.SetDefault("Making the mother of ALL SMGs jack, Can't shoot over every Minishark.");
		}

		public override void SetDefaults() {
			item.damage = 1096; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.ranged = true; // sets the damage type to ranged
			item.width = 80; // hitbox width of the item
			item.height = 100; // hitbox height of the item
			item.useTime = 1; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 1; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 10; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = 10000000; // how much the item sells for (measured in copper)
			item.rare = ItemRarityID.Green; // the color that the item's name will be in-game
			item.UseSound = SoundID.Item36; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = 1; //idk why but all the guns in the vanilla source have this
			item.scale = 1f;
			item.shootSpeed = 20f; // the speed of the projectile (measured in pixels per frame)
			item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-25, 0);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.Bullet) // or ProjectileID.WoodenArrowFriendly
			{
				type = ProjectileID.ChlorophyteBullet; // or ProjectileID.FireArrow;
			}
			return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.VortexSoldierBanner, 25);
			recipe.AddIngredient(ItemID.VortexLarvaBanner, 25);
			recipe.AddIngredient(ItemID.VortexHornetQueenBanner, 20);
			recipe.AddIngredient(ItemID.VortexHornetBanner, 25);
			recipe.AddIngredient(ItemID.LunarBar, 215);
			recipe.AddIngredient(ItemID.FragmentNebula, 200);
			recipe.AddIngredient(ItemID.FragmentSolar, 200);
			recipe.AddIngredient(ItemID.FragmentVortex, 215);
			recipe.AddIngredient(ItemID.FragmentStardust, 200);
			recipe.AddIngredient(ItemID.Megashark, 10);
			recipe.AddIngredient(ItemID.SDMG, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}