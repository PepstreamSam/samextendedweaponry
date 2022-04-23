using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace samextendedweaponry.Projectiles
{
	//ported from my tAPI mod because I'm lazy
	public class electrbolt : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public override void SetDefaults() {
			projectile.width = 12;
			projectile.height = 12;
			projectile.alpha = 255;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.ranged = true;
			aiType = ProjectileID.Bullet;
		}

		public override void AI() {
			if (projectile.alpha > 70) {
				projectile.alpha -= 15;
				if (projectile.alpha < 70) {
					projectile.alpha = 70;
				}
			}
			if (projectile.localAI[0] == 12f) {
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 12f;
			}
			Vector2 move = Vector2.Zero;
			float distance = 400f;
			bool target = false;
			for (int k = 0; k < 200; k++) {
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5) {
					Vector2 newMove = Main.npc[k].Center - projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance) {
						move = newMove;
						distance = distanceTo;
						target = true;
					}
				}
			}
			if (target) {
				AdjustMagnitude(ref move);
				projectile.velocity = (12 * projectile.velocity + move) / 12f;
				AdjustMagnitude(ref projectile.velocity);
			}
			if (projectile.alpha <= 100) {
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Electric);
				Main.dust[dust].velocity /= 12f;
			}
		}

		private void AdjustMagnitude(ref Vector2 vector) {
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 12f) {
				vector *= 12f / magnitude;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (Main.rand.NextBool()) {
				target.AddBuff(BuffID.Electrified, 300);

			}
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{

			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int i = 0; i < projectile.oldPos.Length; i++)
			{
				Vector2 drawPos = projectile.oldPos[i] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - i) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, new Rectangle(0, projectile.frame * Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type], Main.projectileTexture[projectile.type].Width, Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type]), color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}
	}

}