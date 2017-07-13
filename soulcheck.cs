using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Terraria.ID;
using System;
using System.Reflection;
using System.Linq;
using Terraria.ModLoader;
using System.Collections.Generic;


namespace Fargowiltas
{
	class soulcheck : UIState
	{
		public UIPanel checklistPanel;
		public static bool visible = false;
		public static bool no = true;
		public UICheckbox inferno;
		public static bool yellow = true;
		public UICheckbox shield;
		public static bool bee = true;
		public UICheckbox movie;
		public static bool spid = true;
		public UICheckbox spooder;
		public static bool beet = true;
		public UICheckbox beetl;
		public static bool chloro = true;
		public UICheckbox fuck;
		public static bool junkle = true;
		public UICheckbox jungle;
		public static bool forbidden = true;
		public UICheckbox setthing;
		public static bool stardust = true;
		public UICheckbox guard;
		public static bool solar = true;
		public UICheckbox fireshield;
		public static bool shrooms = true;
		public UICheckbox sneak;
		public static bool ori = true;
		public UICheckbox fireball;
		public static bool spoopy = true;
		public UICheckbox scary;
		public static bool hunt = true;
		public UICheckbox hunter;
		public static bool spelunk = true;
		public UICheckbox spelunker;
		public static bool danger = true;
		public UICheckbox sense;
		public static bool light = true;
		public UICheckbox god;
		public static bool spore = true;
		public UICheckbox sac;
		public static bool sanic = true;
		public UICheckbox fast;
		public static bool brawl = true;
		public UICheckbox melee;
		public static bool splitter = true;
		public UICheckbox adam;
		public static bool useSpeed = true;
		public UICheckbox myth;
		
		public static int pagenumb = 1;
		public UIPageSelect left;
		public UIPageSelect right;
		private bool math;
		public override void OnInitialize()
		{
			// Is initialize called? (Yes it is called on reload) I want to reset nicely with new character or new loaded mods: visible = false;

			checklistPanel = new UIPanel();
			checklistPanel.SetPadding(10);
			checklistPanel.Left.Set(1000f, 0f);
			checklistPanel.Top.Set(450f, 0f);
			checklistPanel.Width.Set(180f, 0f);
			checklistPanel.Height.Set(600f, 0f);
			checklistPanel.BackgroundColor = new Color(73, 94, 171);
			checklistPanel.OnMouseDown += new UIElement.MouseEvent(DragOn);
			checklistPanel.OnMouseUp += new UIElement.MouseEvent(DragOff);
			base.Append(checklistPanel);
			
			inferno = new UICheckbox("Inferno buff", "",new Color(244, 121, 13), new Color(205, 80, 80), true, 1f, false); //first color tag is the color of the main text and the second color is the 3d part color if the 3d thing is commented out the second color doesnt come in to play but still keep it there
			inferno.OnSelectedChanged += (object o, EventArgs e) =>
			{
				no = !no;
			};
			checklistPanel.Append(inferno);
			
			shield = new UICheckbox("Hallowed shield", "",new Color(224, 221, 44), new Color(173, 94, 171), true, 1f, false);
			shield.Top.Set(25f, 0f);
			shield.OnSelectedChanged += (object o, EventArgs e) =>
			{
				yellow = !yellow;
			};
			checklistPanel.Append(shield);
			checklistPanel.Append(inferno);
			
			movie = new UICheckbox("Bee minion", "",new Color(242, 201, 21), new Color(173, 94, 171), true, 1f, false);
			movie.Top.Set(50f, 0f);
			movie.OnSelectedChanged += (object o, EventArgs e) =>
			{
				bee = !bee;
			};
			checklistPanel.Append(movie);
			
			spooder = new UICheckbox("Spider minion", "",new Color(114, 74, 25), new Color(173, 94, 171), true, 1f, false);
			spooder.Top.Set(75f, 0f);
			spooder.OnSelectedChanged += (object o, EventArgs e) =>
			{
				spid = !spid;
			};
			checklistPanel.Append(spooder);
			
			beetl = new UICheckbox("Beetles", "",new Color(88, 89, 153), new Color(173, 94, 171), true, 1f, false);
			beetl.Top.Set(100f, 0f);
			beetl.OnSelectedChanged += (object o, EventArgs e) =>
			{
				beet = !beet;
			};
			checklistPanel.Append(beetl);
			
			fuck = new UICheckbox("Leaf crystal", "",new Color(47, 224, 67), new Color(173, 94, 171), true, 1f, false);
			fuck.Top.Set(125f, 0f);
			fuck.OnSelectedChanged += (object o, EventArgs e) =>
			{
				chloro = !chloro;
			};
			checklistPanel.Append(fuck);
			
			jungle = new UICheckbox("Spore Explosion", "",new Color(12, 183, 32), new Color(173, 94, 171), true, 1f, false);
			jungle.Top.Set(150f, 0f);
			jungle.OnSelectedChanged += (object o, EventArgs e) =>
			{
				junkle = !junkle;
			};
			checklistPanel.Append(jungle);
			
			setthing = new UICheckbox("Forbidden storm", "",new Color(221, 186, 11), new Color(173, 94, 171), true, 1f, false);
			setthing.Top.Set(175f, 0f);
			setthing.OnSelectedChanged += (object o, EventArgs e) =>
			{
				forbidden = !forbidden;
			};
			checklistPanel.Append(setthing);
			
			guard = new UICheckbox("Stardust guardian", "",new Color(11, 221, 196), new Color(173, 94, 171), true, 1f, false);
			guard.Top.Set(200f, 0f);
			guard.OnSelectedChanged += (object o, EventArgs e) =>
			{
				stardust = !stardust;
			};
			checklistPanel.Append(guard);
			
			fireshield = new UICheckbox("Solar shield", "",new Color(229, 124, 11), new Color(173, 94, 171), true, 1f, false);
			fireshield.Top.Set(225f, 0f);
			fireshield.OnSelectedChanged += (object o, EventArgs e) =>
			{
				solar = !solar;
			};
			checklistPanel.Append(fireshield);
			
			sneak = new UICheckbox("Shroomite stealth", "",new Color(11, 42, 196), new Color(173, 94, 171), true, 1f, false);
			sneak.Top.Set(250f, 0f);
			sneak.OnSelectedChanged += (object o, EventArgs e) =>
			{
				shrooms = !shrooms;
			};
			checklistPanel.Append(sneak);
			
			fireball = new UICheckbox("Orichalcum fireball", "",new Color(211, 99, 192), new Color(173, 94, 171), true, 1f, false);
			fireball.Top.Set(275f, 0f);
			fireball.OnSelectedChanged += (object o, EventArgs e) =>
			{
				ori = !ori;
			};
			checklistPanel.Append(fireball);
			
			scary = new UICheckbox("Spooky scythes", "",new Color(37, 41, 68), new Color(173, 94, 171), true, 1f, false);
			scary.Top.Set(300f, 0f);
			scary.OnSelectedChanged += (object o, EventArgs e) =>
			{
				spoopy = !spoopy;
			};
			checklistPanel.Append(scary);
			
			hunter = new UICheckbox("Hunter buff", "",new Color(219, 143, 37), new Color(173, 94, 171), true, 1f, false);
			hunter.Top.Set(325f, 0f);
			hunter.OnSelectedChanged += (object o, EventArgs e) =>
			{
				hunt = !hunt;
			};
			checklistPanel.Append(hunter);
			
			spelunker = new UICheckbox("Spelunker buff", "",new Color(246, 255, 2), new Color(173, 94, 171), true, 1f, false);
			spelunker.Top.Set(350f, 0f);
			spelunker.OnSelectedChanged += (object o, EventArgs e) =>
			{
				spelunk= !spelunk;
			};
			checklistPanel.Append(spelunker);
			
			sense = new UICheckbox("Dangersense buff", "",new Color(209, 75, 27), new Color(173, 94, 171), true, 1f, false);
			sense.Top.Set(375f, 0f);
			sense.OnSelectedChanged += (object o, EventArgs e) =>
			{
				danger = !danger;
			};
			checklistPanel.Append(sense);
			
			god = new UICheckbox("Shine buff", "",new Color(247, 255, 48), new Color(173, 94, 171), true, 1f, false);
			god.Top.Set(400f, 0f);
			god.OnSelectedChanged += (object o, EventArgs e) =>
			{
				light = !light;
			};
			checklistPanel.Append(god);
			
			sac = new UICheckbox("Spore sac", "",new Color(93, 255, 0), new Color(173, 94, 171), true, 1f, false);
			sac.Top.Set(425f, 0f);
			sac.OnSelectedChanged += (object o, EventArgs e) =>
			{
				spore = !spore;
			};
			checklistPanel.Append(sac);
			
			fast = new UICheckbox("Super speed", "",new Color(255, 25, 52), new Color(173, 94, 171), true, 1f, false);
			fast.Top.Set(450f, 0f);
			fast.OnSelectedChanged += (object o, EventArgs e) =>
			{
				sanic = !sanic;
			};
			checklistPanel.Append(fast);
			
			melee = new UICheckbox("Melee speed", "",new Color(255, 178, 0), new Color(173, 94, 171), true, 1f, false);
			melee.Top.Set(475f, 0f);
			melee.OnSelectedChanged += (object o, EventArgs e) =>
			{
				brawl = !brawl;
			};
			checklistPanel.Append(melee);
			
			adam = new UICheckbox("Splitting Projectiles", "",new Color(224, 58, 58), new Color(173, 94, 171), true, 1f, false);
			adam.Top.Set(500f, 0f);
			adam.OnSelectedChanged += (object o, EventArgs e) =>
			{
				splitter = !splitter;
			};
			checklistPanel.Append(adam);
			
			myth = new UICheckbox("Increase Use Speed", "",new Color(81, 181, 113), new Color(173, 94, 171), true, 1f, false);
			myth.Top.Set(525f, 0f);
			myth.OnSelectedChanged += (object o, EventArgs e) =>
			{
				useSpeed = !useSpeed;
			};
			checklistPanel.Append(myth);
			
			//RIP PAGE SELECT
			/*left = new UIPageSelect(Fargowiltas.instance.GetTexture("checkMark"), Fargowiltas.instance.GetTexture("checkBox"), "");
			left.Top.Set(500f, 0f);
			left.Left.Set(25f, 0f);
			left.OnClick += (a, b) => 
			{
				UIPageSelect.ClickMe(a, b, ref pagenumb, false, 1);
				Remove();
			};
			checklistPanel.Append(left);//if im on later in the week and you need to add the yellow text for Prev and Next @ me and when i see it i will try to tell you how to do it
			right = new UIPageSelect(Fargowiltas.instance.GetTexture("checkMark"), Fargowiltas.instance.GetTexture("checkBox"), "");
			right.Top.Set(500f, 0f);
			right.Left.Set(100f, 0f);
			right.OnClick += (a, b) =>
			{
				UIPageSelect.ClickMe(a, b, ref pagenumb, true, 2);
				Remove();
			};
			checklistPanel.Append(right);//same situation as seen in left*/
		}
		public void Remove()
		{
			/*if (pagenumb == 1)
			{
				adam.Remove();
				checklistPanel.Append(inferno);
				checklistPanel.Append(shield);
				checklistPanel.Append(movie);
				checklistPanel.Append(spooder);
				checklistPanel.Append(beetl);
				checklistPanel.Append(fuck);
				checklistPanel.Append(jungle);
				checklistPanel.Append(setthing);
				checklistPanel.Append(guard);
				checklistPanel.Append(fireshield);
				checklistPanel.Append(sneak);
				checklistPanel.Append(fireball);
				checklistPanel.Append(scary);
				checklistPanel.Append(hunter);
				checklistPanel.Append(spelunker);
				checklistPanel.Append(sense);
				checklistPanel.Append(god);
				checklistPanel.Append(sac);
				checklistPanel.Append(fast);
				checklistPanel.Append(melee);
				
			}
			/*else
			{
				inferno.Remove();
				shield.Remove();
				movie.Remove();
				spooder.Remove();
				beetl.Remove();
				fuck.Remove();
				jungle.Remove();
				setthing.Remove();
				guard.Remove();
				fireshield.Remove();
				sneak.Remove();
				fireball.Remove();
				scary.Remove();
				hunter.Remove();
				spelunker.Remove();
				sense.Remove();
				god.Remove();
				sac.Remove();
				fast.Remove();
				melee.Remove();
				checklistPanel.Append(adam);
			}*/
		}
		internal void UpdateNeeded()
		{
			updateneeded = true;
		}
		private bool updateneeded;
		private Vector2 offset;
        public bool dragging = false;

        private void DragOn(UIMouseEvent evt, UIElement listeningElement)
        {
            offset = new Vector2(evt.MousePosition.X - checklistPanel.Left.Pixels, evt.MousePosition.Y - checklistPanel.Top.Pixels);
            dragging = true;
        }

        private void DragOff(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;

            checklistPanel.Left.Set(end.X - offset.X, 0f);
            checklistPanel.Top.Set(end.Y - offset.Y, 0f);

            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            if (checklistPanel.ContainsPoint(MousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                checklistPanel.Left.Set(MousePosition.X - offset.X, 0f);
                checklistPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
                Recalculate();
            }
        }
	}
}