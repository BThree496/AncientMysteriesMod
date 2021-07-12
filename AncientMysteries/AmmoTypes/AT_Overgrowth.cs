﻿namespace AncientMysteries.AmmoTypes
{
    public class AT_Overgrowth : AMAmmoType
    {
        public AT_Overgrowth()
        {
            bulletColor = Color.Transparent;
            bulletLength = 0f;
            sprite = t_OvergrowthSmall.ModSprite();
            bulletSpeed = 5f;
            accuracy = 0.3f;
            speedVariation = 2.5f;
            sprite.CenterOrigin();
        }

        public AT_Overgrowth(bool isBig)
        {
            if (isBig)
            {
                sprite = t_OvergrowthBig.ModSprite();
                bulletSpeed = 4f;
                accuracy = 0.4f;
                speedVariation = 3f;
                bulletLength = 0f;
            }
            else
            {
                sprite = t_OvergrowthSmall.ModSprite();
                bulletSpeed = 5f;
                accuracy = 0.3f;
                speedVariation = 2.5f;
                bulletLength = 0f;
            }
            rangeVariation = 50f;
        }
    }
}
