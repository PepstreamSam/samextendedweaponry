using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace samextendedweaponry.Items.bows
{
	public class raybow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Ray bow"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display
			Tooltip.SetDefault("Shoots a laser when used with normal arrows.");
		}

		public override void SetDefaults() {
			item.damage = 70; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.ranged = true; // sets the damage type to ranged
			item.width = 20; // hitbox width of the item
			item.height = 20; // hitbox height of the item
			item.useTime = 10; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 10; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 10; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = 10000000; // how much the item sells for (measured in copper)
			item.scale = 1f;
			item.rare = ItemRarityID.Green; // the color that the item's name will be in-gamepenis vagina boobies tiddies ass cock dick boobs thighs feet butt pp vgner cock and ball gtorture from wikipedia the free ecnyclopedia cbt is qa sexual activity involving torture of the male genitals}
			item.UseSound = SoundID.Item93; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = 10; //idk why but all the guns in the vanilla source have thir
			item.shootSpeed = 16f; // the speed of the projectile (measured in pixels per frame)
			item.useAmmo = AmmoID.Arrow; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, 0);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.WoodenArrowFriendly) // or ProjectileID.WoodenArrowFriendly
			{
				type = ProjectileID.LaserMachinegunLaser; // or ProjectileID.FireArrow;
			}
			
				int numberProjectiles = 2 + Main.rand.Next(1); // 4 or 5 shots
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5)); // 30 degree spread.
																													// If you want to randomize the speed to stagger the projectiles
																													// float scale = 1f - (Main.rand.NextFloat() * .3f);
																													// perturbedSpeed = perturbedSpeed * scale; 
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
				}
				return true;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PulseBow, 1);
			recipe.AddIngredient(ItemID.IronBar, 20);
			recipe.AddIngredient(ItemID.MartianConduitPlating, 25);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}