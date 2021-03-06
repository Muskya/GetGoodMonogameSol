﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGoodMonogame
{
    public class Projectile
    {
        //FIELDS
        public Texture2D projectileSprite;
        public Texture2D _texture; //Sprite of the projectile
        public Vector2 _position; //Position of the projectile
        public float _angle;

        public Rectangle _collisionBox;

        public bool _isOnScreen = true;
        public bool _hasHitEnemy = false;

        //POUR LE MOMENT, LES PROJECTILES NE SONT PAS "DETRUITS" LORSQU'ILS SORTENT DE L'ECRAN
        //CELA PEUT CREER DES PROBLEMES DE MEMOIRE A L'AVENIR. SI JAMAIS, IL FAUT SIMPLEMENT TROUVER UN MOYEN
        //DE SUPPRIMER DE LA LISTE DES PROJECTILES LE PROJECTILE COURANT SI JAMAIS SA POSITION.Y EST HORS DE L'ECRAN

        public static List<Projectile> projectilesOnScreen = new List<Projectile>();
        public static List<Projectile> projectilesBurst = new List<Projectile>(3);

        //METHODS
        public Projectile(Texture2D texture, Vector2 startPos)
        {
            this._texture = texture;
            this._position = startPos;
            this._collisionBox = new Rectangle((int)this._position.X + 12, (int)this._position.Y, (int)this._texture.Width - 24, (int)this._texture.Height);
        }

        public Projectile(Texture2D texture, Vector2 startPos, float angle)
            : this (texture, startPos)
        {
            this._angle = angle;
        }

        public void Update(GameTime gameTime)
        {
            if (this._position.Y < -30)
                _isOnScreen = false;
            else
                _isOnScreen = true;

            this._position.Y -= 5;

            this._collisionBox = new Rectangle((int)this._position.X + 12, (int)this._position.Y, (int)this._texture.Width - 24, (int)this._texture.Height);
        }

        public void UpdateAlt(GameTime gameTime, float angle)
        {
            if (this._position.Y < -30)
                _isOnScreen = false;
            else
                _isOnScreen = true;

            this._position.Y -= 5;

            if (angle > 0)
                this._position.X += 5;
            else if (angle < 0)
                this._position.X -= 5;

            this._collisionBox = new Rectangle((int)this._position.X + 12, (int)this._position.Y, (int)this._texture.Width - 24, (int)this._texture.Height);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this._texture, this._position, Color.White);
        }

        public void DrawAlt(GameTime gameTime, SpriteBatch spriteBatch, float angle)
        {
            spriteBatch.Draw(this._texture, this._position, null, Color.White, angle, Vector2.One, 1, SpriteEffects.None, 1);
        }

    }
}
