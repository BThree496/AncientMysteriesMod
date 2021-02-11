﻿using DuckGame;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AncientMysteries
{
    public static class NetHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NmFireGun(this Gun gun, Action<List<Bullet>> value, bool alsoAddThemToWorld = true)
        {
            var firedBullets = GlobalPool<List<Bullet>>.Rent();
            firedBullets.Clear();
            value(firedBullets);
            if (alsoAddThemToWorld)
            {
                foreach (var item in firedBullets)
                {
                    Level.Add(item);
                }
            }
            if (gun != null)
                gun.bulletFireIndex++;
            if (gun != null && Network.isActive)
            {
                NMFireGun gunEvent = new(gun, firedBullets, gun.bulletFireIndex, rel: false, 4);
                Send.Message(gunEvent, NetMessagePriority.ReliableOrdered);
            }
            firedBullets.Clear();
            GlobalPool<List<Bullet>>.Return(firedBullets);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NmFireGun(this Gun gun, Bullet value, bool alsoAddThemToWorld = true)
        {
            var firedBullets = GlobalPool<List<Bullet>>.Rent();
            firedBullets.Clear();
            firedBullets.Add(value);
            if (alsoAddThemToWorld)
            {
                Level.Add(value);
            }
            gun.bulletFireIndex++;
            if (Network.isActive)
            {
                NMFireGun gunEvent = new(gun, firedBullets, gun.bulletFireIndex, rel: false, 4);
                Send.Message(gunEvent, NetMessagePriority.ReliableOrdered);
            }
            firedBullets.Clear();
            GlobalPool<List<Bullet>>.Return(firedBullets);
        }
    }
}
