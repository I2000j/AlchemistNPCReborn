using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.Utilities;

namespace AlchemistNPCReborn.Items.Weapons
{
	public class EdgeOfChaos : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Edge of Chaos");
			Tooltip.SetDefault("Swing of this blade may tear reality in half"
			+"\nInflicts Chaos State debuff on hit");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Грань Хаоса");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Взмах этого меча может разорвать реальность надвое\nНакладывает Хаотическое Состояние на цель");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "混沌边缘");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "剑刃足以撕裂现实"
			+"\n攻击造成混沌状态Debuff");

		}

		public override void SetDefaults()
		{
			Item.damage = 33333;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 66;
			Item.height = 66;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(platinum: 1);
			Item.rare = 11;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.buffImmune[Mod.Find<ModBuff>("ChaosState").Type] = false;
			target.AddBuff(Mod.Find<ModBuff>("ChaosState").Type, 1800);
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),target.position.X, target.position.Y, 0f, 0f, Mod.Find<ModProjectile>("ExplosionAvenger").Type, damage, 0, Main.myPlayer);
		}
	}
}
