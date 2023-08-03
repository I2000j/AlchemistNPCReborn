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
	public class LightOfCeraSumat : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("''The Light of Cera Sumat''");
			Tooltip.SetDefault("[c/00FF00:Legendary Sword] of Old Duke Ehld."
			+"\nTrue Melee sword"
			+"\nInflicts Curse of Light debuff"
			+"\nMakes enemies take 20% more damage from player"
			+"\n25% to take only half of the damage from debuffed enemy"
			+"\n[c/00FF00:Stats are growing up through post Moon Lord progression]"
			+"\nBoosted stats will be shown after the first swing");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Свет Сера Сумат''");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "[c/00FF00:Легендарный Меч] Старого Графа Эхлда\nОслабляет противников при ударе\nОслабленные противники получают на 20% больше урона\n25% шанс получить половину урона от ослабленных противников\n[c/00FF00:Показатели увеличивается по мере пост Мунлордного прохождения]");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "''塞拉苏门之光''");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "老公爵埃尔德的[c/00FF00:传奇之剑]"
			+"\n纯近战剑"
			+"\n造成诅咒之光Debuff"
			+"\n来自玩家的攻击对敌人多造成20%伤害"
			+"\n来自带有诅咒之光Debuff敌人的攻击有25%概率只造成一半伤害"
			+"\n[c/00FF00:属性随进程成长]"
			+"\n提升过后的属性将会在使用后显示");

		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Muramasa);
			Item.damage = 110;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(platinum: 1);
			Item.rare = 11;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override bool CanUseItem(Player player)
		{
			ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
			if (Calamity != null)
			{
				if ((bool)Calamity.Call("Downed", "profaned guardians"))
				{
					Item.damage = 120;
				}
				if ((bool)Calamity.Call("Downed", "providence"))
				{
					Item.damage = 150;
				}
				if ((bool)Calamity.Call("Downed", "polterghast"))
				{
					Item.damage = 222;
				}
				if ((bool)Calamity.Call("Downed", "dog"))
				{
					Item.damage = 300;
				}
				if ((bool)Calamity.Call("Downed", "yharon"))
				{
					Item.damage = 400;
				}
				if ((bool)Calamity.Call("Downed", "supreme calamitas"))
				{
					Item.damage = 500;
				}
			}
			return true;
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, Mod.Find<ModDust>("JustitiaPale").Type);
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.buffImmune[Mod.Find<ModBuff>("CurseOfLight").Type] = false;
			target.AddBuff(Mod.Find<ModBuff>("CurseOfLight").Type, 300);
			Vector2 vel1 = new Vector2(0, 0);
			vel1 *= 0f;
			Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),target.position.X, target.position.Y, vel1.X, vel1.Y, Mod.Find<ModProjectile>("ExplosionAvenger").Type, damage, 0, Main.myPlayer);
		}
		
		public override int ChoosePrefix (UnifiedRandom rand)
		{
			return 81;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod.Find<ModItem>("HolyAvenger").Type);
			//recipe.AddIngredient(Mod.Find<ModItem>("Pommel").Type);
			recipe.AddTile(Mod.Find<ModTile>("MateriaTransmutator").Type);
			recipe.Register();
		}
	}
}
