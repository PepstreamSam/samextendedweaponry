using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace samextendedweaponry.Items.guns
{
	public class bnkr : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("M.U.M.G. Multi Use Machine Gun"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display
			Tooltip.SetDefault(" a very good alternative to the Minishark press rigt click to shoot a grenade.");
		}

		public override void SetDefaults() {
			item.damage = 8; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.ranged = true; // sets the damage type to ranged
			item.width = 20; // hitbox width of the item
			item.height = 20; // hitbox height of the item
			item.useTime = 9; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 9; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 10; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = 10000; // how much the item sells for (measured in copper)
			item.rare = ItemRarityID.Green; // the color that the item's name will be in-game
			item.UseSound = SoundID.Item11; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.scale = 1f; //would be 25 % bigger
			item.shootSpeed = 16f; // the speed of the projectile (measured in pixels per frame)
			item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-7, 0);
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LeadBar, 10);
			recipe.AddIngredient(ItemID.Wood, 20);
			recipe.AddIngredient(ItemID.CopperBar, 18);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool AltFunctionUse(Player player) {
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.useStyle = ItemUseStyleID.HoldingOut;
				item.useTime = 35;
				item.useAnimation = 35;
				item.damage = 60;
				item.useAmmo = AmmoID.Bullet;
				item.shoot = ProjectileID.Grenade;
			}
			else
			{
				item.useStyle = ItemUseStyleID.HoldingOut;
				item.useTime = 9;
				item.useAnimation = 9;
				item.damage = 8;
				item.useAmmo = AmmoID.Bullet;
				item.shoot = ProjectileID.Bullet;
			}
			return base.CanUseItem(player);
		}

		public override bool ConsumeAmmo(Player player)
		{
			if (Main.rand.Next(5) == 0) { return false; } // if number is 0, don't use ammo also
			return true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse == 2)
			{
				type = ProjectileID.Grenade;
				return true; 
		}
		else return true;
				// (float)r.NextDouble() * 2f - 1f
				speedX += 0.3f * Main.rand.NextFloatDirection();
				speedY += 0.3f * Main.rand.NextFloatDirection();
			
		}
    }
}