
using Microsoft.Xna.Framework;
using System.ComponentModel;
using System.Media;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Security.Cryptography.X509Certificates;
using IL.Terraria.DataStructures;
using System.Collections.Generic;
using DacernChallenge;
//using Dacern.misc;

namespace DacernChallenge.Tiles
{
    public class Playerofmod : ModPlayer
    {
        public override void PostUpdate()
        {
            // player.lifeRegen += (int)(ModContent.GetInstance<Hec>().LRU);
            //player.allDamage += (int)(ModContent.GetInstance<Hec>().DU);
            player.statLifeMax2 += (int)(ModContent.GetInstance<Hec>().MHPM);
            player.statDefense += (int)(ModContent.GetInstance<Hec>().DPM);
            player.armorPenetration += (int)(ModContent.GetInstance<Hec>().APPM);
            /*if (ModContent.GetInstance<Hec>().ExtraChallenge)
            {
                player.lifeRegen += 3;
                player.allDamage += 0.2f;
                player.statDefense += 5;
            }*/
        }
        int lomya = 0;
        public override void PostItemCheck()
        {

            if ((int)(ModContent.GetInstance<Jec>().IGT) != 0)
            {
                lomya++;
                if (lomya == (int)(ModContent.GetInstance<Jec>().IGT))
                {
                    player.QuickSpawnItem(Main.rand.Next(1, ItemLoader.ItemCount), (int)(ModContent.GetInstance<Jec>().IGC));
                    lomya = 0;
                }
            }
        }
    }
    public class itemmodos : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (ModContent.GetInstance<Hec>().Crit)
            {
                item.crit = 100;
            }
            if (ModContent.GetInstance<Hec>().Auto)
            {
                item.autoReuse = true;
            }
            item.scale *= (int)(ModContent.GetInstance<Hec>().IS);
            item.damage *= (int)(ModContent.GetInstance<Hec>().DU);
            item.knockBack += (int)(ModContent.GetInstance<Hec>().iKBm);
            //npc.defense *= (int)(ModContent.GetInstance<Hec>().DPMN);
        }
    }
    public class NPCGlobe : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            //npc.lifeRegen += (int)(ModContent.GetInstance<Hec>().LRU);
            npc.damage *= (int)(ModContent.GetInstance<Hec>().DUN);
            npc.lifeMax *= (int)(ModContent.GetInstance<Hec>().MHPMN);
            npc.defense *= (int)(ModContent.GetInstance<Hec>().DPMN);
        }
    }
    
    public class NPCSummonTile : GlobalTile
    {
        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if ((int)(ModContent.GetInstance<Iec>().NPT) != 0)
            {
                if (Main.rand.Next((int)(ModContent.GetInstance<Iec>().NPT)) == 0)
                {
                    base.KillTile(i, j, type, ref fail, ref effectOnly, ref noItem);
                    Tile tile = Framing.GetTileSafely(i, j);


                    if (fail == false)
                    {
                        NPC.NewNPC(i * 16, j * 16, Main.rand.Next(1, NPCLoader.NPCCount), (int)(ModContent.GetInstance<Iec>().NPC));
                    }
                }
            }
        }
    }
  /*  public class ProjSummonTile : GlobalTile
    {
        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if ((int)(ModContent.GetInstance<Iec>().NPT) != 0)
            {
                if (Main.rand.Next((int)(ModContent.GetInstance<Iec>().NPT)) == 0)
                {
                    base.KillTile(i, j, type, ref fail, ref effectOnly, ref noItem);
                    Tile tile = Framing.GetTileSafely(i, j);


                    Vector2 position = player.Center;
                    Vector2 targetPos = Main.MouseWorld;
                    Vector2 direction = targetPos - position;
                    direction.Normalize();
                    float speed = 10f;
                    int type = ProjectileID.Leaf;
                    float rotation = MathHelper.ToRadians(0);
                    for (int i = 0; i < 1; i++)
                    {
                        Projectile.NewProjectile(position, (speed * direction).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / 2)), type, 15, 0f, Main.myPlayer);
                    }
                    if (fail == false)
                    {
                        Projectile.NewProjectile(i * 16, j * 16, Main.rand.Next(1, ProjectileLoader.ProjectileCount), 1);
                    }
                }
            }
        }
    }*/
    public class ItemSummonTile : GlobalTile
    {
        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if ((int)(ModContent.GetInstance<Iec>().IT) != 0)
            {
                if (Main.rand.Next((int)(ModContent.GetInstance<Iec>().IT)) == 0)
                {
                    base.KillTile(i, j, type, ref fail, ref effectOnly, ref noItem);
                    Tile tile = Framing.GetTileSafely(i, j);


                    if (fail == false)
                    {
                        Item.NewItem(i * 16, j * 16, 16, 16, Main.rand.Next(1, ItemLoader.ItemCount), (int)(ModContent.GetInstance<Iec>().IC));
                    }
                }
            }
        }
    }
}


/*public class ThiccShotgun : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("overboard.");

    }
    public override void SetDefaults()
    {

        item.damage = 24;
        item.ranged = true;
        item.width = 40;
        item.height = 20;
        item.useStyle = ItemUseStyleID.HoldingOut;
        item.useTime = 60;
        item.useAnimation = 60;
        item.useStyle = 5;
        item.noMelee = true;
        item.knockBack = 6.5f;
        item.value = 50000;
        item.rare = 2;
        item.UseSound = SoundID.Item36;
        item.autoReuse = true;
        item.shoot = 1;
        item.shootSpeed = 7f;
        item.useAmmo = AmmoID.Bullet;
    }

    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
    {
        int numberProjectiles = 13 + Main.rand.Next(2); // 4 or 5 shots
        for (int i = 0; i < numberProjectiles; i++)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20)); // 30 degree spread.
                                                                                                            // If you want to randomize the speed to stagger the projectiles
                                                                                                            // float scale = 1f - (Main.rand.NextFloat() * .3f);
                                                                                                            // perturbedSpeed = perturbedSpeed * scale; 
            Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
        }
        return false; // return false because we don't want tmodloader to shoot projectile
    }
    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(ItemID.BlackDye, 3);
        recipe.AddIngredient(ItemID.Shotgun, 5);
        recipe.AddTile(TileID.anvils);

        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}*/




























/*public class EndlessLuminiteArrowQuiver : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("It's time for the REAL fun to begin now...");
    }

    public override void SetDefaults()
    {
        item.damage = 15;
        item.ranged = true;
        item.width = 8;
        item.height = 8;
        item.consumable = false;             //You need to set the item consumable so that the ammo would automatically consumed
        item.knockBack = 3.5f;
        item.shoot = 639;   //The projectile shoot when your weapon using this ammo
        item.shootSpeed = 3f;
        item.ammo = AmmoID.Arrow;
    {
public override void AddRecipes()
{
    ModRecipe recipe = new ModRecipe(mod); ModRecipe recipe = new ModRecipe(mod);
                    recipe.AddIngredient(ItemID.EndlessQuiver, 1);
                    recipe.AddIngredient(ItemID.MoonlordArrow, 3996);
                    recipe.SetResult(this);
                    recipe.AddRecipe();
    recipe.AddTile(TileID.Anvils);
    recipe.SetResult(this);
    recipe.AddRecipe();
}

        }
    }
}*/



/*public class Sound : ModSound
{
    public override void PlaySound(ref SoundEffectInstance, SoundInstance, float volume, float pan, SoundType type)
    {
        soundInstance = sound.CreateInstance();
        soundInstance.Volume = volume * 0.5f;
        soundInstance.Pan = pan;
        soundInstance.Pitch = -1.0f;
        Main.PlaySoundInstance(SongMusic);
    }
}*/

/*  public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
 *  
{

    target.AddBuff(70, 180, false); //The debuff inflicted is the modded debuff Ethereal Flames. 180 is the duration in frames: Terraria runs at 60 FPS, so that's 3 seconds (180/60=3). To change the modded debuff, change EtherealFlames to whatever the buff is called; to add a vanilla debuff, change mod.BuffType("EtherealFlames") to a number based on the terraria buff IDs. Some useful ones are 20 for poison, 24 for On Fire!, 39 for Cursed Flames, 69 for Ichor, and 70 for Venom.

}*/
//item.shoot = mod.ProjectileType("NovaBullet");
//          item.useAmmo = AmmoID.Bullet;
//recipe.AddIngredient(ModContent.ItemType<Hilt>(), 1);
//item.shoot = mod.ProjectileType("Voidp");



/*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
       { 
            if (Main.rand.NextBool(15))
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            }
            else
            {
                type = ProjectileID.BulletHighVelocity;
            }   return true;
        }*/
