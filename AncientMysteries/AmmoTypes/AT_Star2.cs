﻿namespace AncientMysteries.AmmoTypes
{
    public sealed class AT_Star2 : AMAmmoType
    {
        public AT_Star2()
        {
            accuracy = 1f;
            range = 0.5f;
            penetration = 1f;
            rangeVariation = 0;
            bulletSpeed = 0.02f;
            bulletLength = 0;
            combustable = true;
            speedVariation = 0f;
            bulletType = typeof(Bullet_Star2);
            sprite = TexHelper.ModSprite(tex_Bullet_HolyStar2);
            sprite.CenterOrigin();
        }

        public override Bullet FireBullet(Vec2 position, Thing owner = null, float angle = 0, Thing firedFrom = null)
        {
            bulletColor = Color.DarkOrange;
            return base.FireBullet(position, owner, angle, firedFrom);
        }
    }
}