﻿namespace AncientMysteries.Items
{
    [EditorGroup(group_Guns_Staffs)]
    [MetaImage(tex_Staff_ArcaneNova)]
    [MetaInfo(Lang.english, "Arcane Nova", "A staff fulfilled with mysteries from the universe")]
    [MetaInfo(Lang.schinese, "奥术新星", "一把充满了宇宙奥秘的法杖")]
    public partial class ArcaneNova : AMStaff
    {
        public StateBinding _animationFrameBinding = new(nameof(AnimationFrame));

        public SpriteMap _spriteMap;

        public byte AnimationFrame
        {
            get => (byte)_spriteMap._frame;
            set => _spriteMap._frame = value;
        }

        public override string GetLocalizedName(Lang lang) => lang switch
        {
            Lang.schinese => "奥术新星",
            _ => "Arcane Nova",
        };

        public override string GetLocalizedDescription(Lang lang) => lang switch
        {
            Lang.schinese => "一把充满了宇宙奥秘的法杖",
            _ => "A staff fulfilled with mysteries from the universe",
        };

        public ArcaneNova(float xval, float yval) : base(xval, yval)
        {
            _type = "gun";
            _spriteMap = this.ReadyToRunWithFrames(tex_Staff_ArcaneNova, 14, 37);
            SetBox(14, 37);
            _barrelOffsetTL = new Vec2(6f, 5f);
            _castSpeed = 0.007f;
            BarrelSmokeFuckOff();
            _flare.color = Color.Transparent;
            _fireWait = 0.5f;
            _fireSoundPitch = 0.9f;
            _kickForce = 0.25f;
            _fullAuto = true;
        }

        public override void OnReleaseSpell()
        {
            base.OnReleaseSpell();
            var firePos = owner.offDir == 1 ? new Vec2(barrelPosition.x, barrelPosition.y - 18) : new Vec2(barrelPosition.x, barrelPosition.y + 10);
            if (_castTime >= 1f)
            {
                var bullet = new ArcaneNova_Magic_Stage1(firePos, GetBulletVecDeg(owner.offDir == 1 ? 0 : 180, 3.5f), duck);
                Level.Add(bullet);
                SFX.PlaySynchronized("laserBlast", 5, -0.2f);
            }
        }
    }
}