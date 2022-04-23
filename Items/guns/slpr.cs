using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace samextendedweaponry.Items.guns
{
	public class slpr : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("SLPR Twin Cannon"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display
			Tooltip.SetDefault("shoots two homin' rockeds' at you r 'nemies.");
		}

		public override void SetDefaults() {
			item.damage = 135; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.ranged = true; // sets the damage type to ranged
			item.width = 20; // hitbox width of the item
			item.height = 20; // hitbox height of the item
			item.useTime = 7; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 12; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 10; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = 1000000; // how much the item sells for (measured in copper)
			item.rare = ItemRarityID.Green; // the color that the item's name will be in-game
			item.UseSound = SoundID.Item97; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = ProjectileID.Puppy; //idk why but all the guns in the vanilla source have this
			item.reuseDelay = 14;
			item.shootSpeed = 16f; // the speed of the projectile (measured in pixels per frame)
			item.useAmmo = AmmoID.Rocket; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 2 + Main.rand.Next(2); // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); // 30 degree spread.
																												// If you want to randomize the speed to stagger the projectiles
																												// float scale = 1f - (Main.rand.NextFloat() * .3f);
																												// perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false; // return false because we don't want tmodloader to shoot projectile
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-35, 0);
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RocketLauncher, 2);
			recipe.AddIngredient(ItemID.TitaniumBar, 15);
			recipe.AddIngredient(ItemID.HallowedBar, 11);
			recipe.AddIngredient(ItemID.BeetleHusk, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}