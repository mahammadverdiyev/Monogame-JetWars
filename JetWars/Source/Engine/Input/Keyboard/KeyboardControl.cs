﻿#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
#endregion

namespace JetWars
{
    public class KeyBoardControl
    {

        public KeyboardState newKeyboard, oldKeyboard;

        public List<MEKey> pressedKeys = new List<MEKey>(), previousPressedKeys = new List<MEKey>();

        public virtual void Update()
        {
            newKeyboard = Keyboard.GetState();

            GetPressedKeys();
        }

        public void UpdateOld()
        {
            oldKeyboard = newKeyboard;

            previousPressedKeys = new List<MEKey>();
            for(int i=0;i<pressedKeys.Count;i++)
            {
                previousPressedKeys.Add(pressedKeys[i]);
            }
        }


        public bool GetPress(string KEY)
        {
            for(int i=0;i<pressedKeys.Count;i++)
            {
                if(pressedKeys[i].key == KEY)
                {
                    return true;
                }
            }

            return false;
        }


        public virtual void GetPressedKeys()
        {
            pressedKeys.Clear();
            for(int i=0; i<newKeyboard.GetPressedKeys().Length; i++)
            {
                pressedKeys.Add(new MEKey(newKeyboard.GetPressedKeys()[i].ToString(), 1));
            }
        }

    }
}
