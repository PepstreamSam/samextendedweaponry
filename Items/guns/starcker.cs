using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace samextendedweaponry.Items.guns
{
	public class starcker : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("StarSttacker"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display
			Tooltip.SetDefault("IM BULLET PROOF.");
		}

		public override void SetDefaults() {
			item.damage = 67; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.ranged = true; // sets the damage type to ranged
			item.width = 20; // hitbox width of the item
			item.height = 20; // hitbox height of the item
			item.scale = 1f;
			item.useTime = 12; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 12; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 10; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = 10000; // how much the item sells for (measured in copper)
			item.rare = ItemRarityID.Green; // the color that the item's name will be in-game
			item.UseSound = SoundID.Item11; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = ProjectileID.FallingStar; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 16f; // the speed of the projectile (measured in pixels per frame)
			item.useAmmo = AmmoID.FallenStar; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, 0);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			// Here we manually spawn the 2nd projectile, manually specifying the projectile type that we wish to shoot.
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.RocketSnowmanIII, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.FallingStar, damage, knockBack, player.whoAmI);
			// By returning true, the vanilla behavior will take place, which will shoot the 1st projectile, the one determined by the ammo.
			return true;


		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StarCannon, 1);
			recipe.AddIngredient(ItemID.ShroomiteBar, 15);
			recipe.AddIngredient(ItemID.Ectoplasm, 25);
			recipe.AddIngredient(ItemID.TitaniumBar, 20);
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			recipe.AddIngredient(ItemID.SoulofMight, 7);
			recipe.AddIngredient(ItemID.BeetleHusk, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}