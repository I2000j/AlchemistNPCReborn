using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCReborn.Items.Weapons
{
	public class TurretStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Turret Staff");
			Tooltip.SetDefault("Summons deadly GLaDOS turret to fight for you");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Посох турели");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Призывает смертоносную турель ГЛаДОС");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "G姐炮塔召唤杖");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "召唤致命的G姐炮塔为你而战");
        
        }    
		
		public override void SetDefaults()
		{
			Item.damage = 66;
			Item.mana = 100;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.knockBack = 10;
			Item.value = Item.buyPrice(5, 0, 0, 0);
			Item.rare = 10;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Minions.Turret>();
			Item.DamageType = DamageClass.Summon;
			Item.sentry = true;
			Item.buffType = ModContent.BuffType<Buffs.Turret>();
			Item.buffTime = 3600;
		}

		//public virtual void UseStyle(Player player, Rectangle heldItemFrame)
    	//{
		//	if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
		//	{
		//		player.AddBuff(Item.buffType, 3600, true);
		//	}
		//}
	
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (!Main.dedServ)
			{
				SoundStyle soundStyle = new SoundStyle("AlchemistNPCReborn/Sounds/Item/PortalTurretDeploy", (SoundType) 0);
				SoundEngine.PlaySound(soundStyle, new Vector2?(((Entity) player).Center));
			}
			Vector2 SPos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			position = SPos;
			//if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Minions.Turret>()] < player.maxTurrets)
			//{
			//	return true;
			//}
			return true;
		}
	}
}
