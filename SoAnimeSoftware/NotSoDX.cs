using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.Hack.Misc;
using SoAnimeSoftware.Hack.Visuals;
using SoAnimeSoftware.Utils;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoAnimeSoftware.GUI;
using SoAnimeSoftware.GUI.Elements;
using SoAnimeSoftware.Hack;
using SoAnimeSoftware.Hack.Misc.MovementRecorder;

namespace SoAnimeSoftware
{

    public partial class NotSoDX : Form
    {
        public NotSoDX()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SDK.CVar.Force("name", Encoding.Default.GetBytes("\n\xAD\xAD\xAD"));
        }

        private void crosshairRecoilCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.recoilCrosshair = crosshairRecoilCheckBox.Checked;
        }

        private void removeVisualRecoilCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.noVisualRecoil = removeVisualRecoilCheckBox.Checked;
        }

        private void NotSoDX_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void worldColorCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            Settings.worldColoring = worldColorCheckBox.Checked ? Status.ENABLED : Status.DISABLED;
            Hack.Misc.Checks.needUpdate = true;
        }

        private void debugCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.debugMode = debugCheckBox.Checked;
        }

        public static Color ColorSelection()
        {
            ColorDialog cd = new ColorDialog();
            cd.FullOpen = true;
            if (cd.ShowDialog() != DialogResult.OK)
                return ColorSelection();

            return cd.Color;
        }

        private void worldColorButton_Click(object sender, EventArgs e)
        {
            Color result = ColorSelection();
            worldColorButton.BackColor = result;
            Settings.worldColor = new FloatColor(result);
            Hack.Misc.Checks.needUpdate = true;
            //Settings.worldColoring = Settings.worldColoring == Status.ENABLED_DONE ? Status.ENABLED : Status.DISABLED;
        }

        private void staticColorButton_Click(object sender, EventArgs e)
        {
            Color result = ColorSelection();
            staticColorButton.BackColor = result;
            Settings.staticColor = new FloatColor(result);
            Hack.Misc.Checks.needUpdate = true;
            //Settings.worldColoring = Settings.worldColoring == Status.ENABLED_DONE ? Status.ENABLED : Status.DISABLED;
        }

        private void skyboxColorButton_Click(object sender, EventArgs e)
        {
            Color result = ColorSelection();
            skyboxColorButton.BackColor = result;
            Settings.skyboxColor = new FloatColor(result);
            Hack.Misc.Checks.needUpdate = true;
            //Settings.worldColoring = Settings.worldColoring == Status.ENABLED_DONE ? Status.ENABLED : Status.DISABLED;
        }

        private CancellationTokenSource _discordCts = new CancellationTokenSource(); 
        
        private void NotSoDX_Load(object sender, EventArgs e)
        {
            debugCheckBox.Checked = Settings.debugMode;
            for (int i = 0; i < Settings.bones.Length; i++)
            {
                hitboxList.SetItemChecked(i, Settings.bones[i]);
            }

            var ct = _discordCts.Token;

            Task.Run(() => Hack.Misc.Other.DiscordIntegration(ct),ct);
        }


        private void printButton_Click(object sender, EventArgs e)
        {
            Hack.Misc.Other.ConsolePrint(picTextBox.Text);
        }


        public unsafe static void Test()
        {
        }

        private void asusTrackBar_Scroll(object sender, EventArgs e)
        {
            Settings.asusProp = asusTrackBar.Value / 255f;
            Settings.worldColoring = Status.ENABLED;
            Hack.Misc.Checks.needUpdate = true;
        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CSGO.SDK.CVar.Force("name", textBox1.Text);
        }

        private void NotSoDX_FormClosed(object sender, FormClosedEventArgs e)
        {
            _discordCts.Cancel();
            
            Hack.Hooks.Unhook();

            //Hack.Visuals.SkinChanger.StickerUnhook();

            DebugHelper.HideConsoleWindow();
            Settings.unhook = true;
        }

        private void bhopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.bunnyHop = bhopCheckBox.Checked;
        }

        private void glowCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.glow = glowCheckBox.Checked;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Settings.styleGlow = (int) numericUpDown1.Value;
        }

        private void picCharComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.printChars = picCharComboBox.Text;
        }

        private void teamGlowButton_Click(object sender, EventArgs e)
        {
            Color color = ColorSelection();
            teamGlowButton.BackColor = color;
            Settings.teamGlowColor = new FloatColor(color);
        }

        private void enemyGlowButton_Click(object sender, EventArgs e)
        {
            Color color = ColorSelection();
            enemyGlowButton.BackColor = color;
            Settings.enemyGlowColor = new FloatColor(color);
        }

        private void hitSoundCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.hitSound = hitSoundCheckBox.Checked;
        }

        private void grenadePredictionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.grenadePrediction = grenadePredictionCheckBox.Checked;
        }

        private void fastCrouchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.fastCrouch = fastCrouchCheckBox.Checked;
        }

        private void espCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.esp = espCheckBox.Checked;
        }

        private void teamEspButtom_Click(object sender, EventArgs e)
        {
            Color color = ColorSelection();
            teamEspButtom.BackColor = color;
            Settings.teamEsp = new ByteColor(color);
        }

        private void enemyEspButton_Click(object sender, EventArgs e)
        {
            Color color = ColorSelection();
            enemyEspButton.BackColor = color;
            Settings.enemyEsp = new ByteColor(color);
        }

        private void overlayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.overlay = overlayCheckBox.Checked;
        }

        private void boxesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.boxes = boxesCheckBox.Checked;
        }

        private void outlineButton_Click(object sender, EventArgs e)
        {
            Color color = ColorSelection();
            outlineButton.BackColor = color;
            Settings.outlineEsp = new ByteColor(color);
        }


        private void chamsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.chams = chamsCheckBox.Checked;
        }


        private void teamChamsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.teamChams = teamChamsCheckBox.Checked;
        }

        private void enemyChamsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.enemyChams = enemyChamsCheckBox.Checked;
        }

        private void valorantCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.valorant = valorantCheckBox.Checked ? Status.ENABLED : Status.DISABLED;
            Checks.needUpdate = true;
        }

        private void minecraftCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.minecraft = minecraftCheckBox.Checked ? Status.ENABLED : Status.DISABLED;
            Checks.needUpdate = true;
        }

        private void voteLoggerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.voteLogger = voteLoggerCheckBox.Checked;
        }

        private void autoStrafeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.autoStrafe = autoStrafeCheckBox.Checked;
        }

        private void edgeJumpCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.edgeJump = edgeJumpCheckBox.Checked;
        }


        private void blockBotCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.blockBot = blockBotCheckBox.Checked;
        }

        private void doorSpammerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.doorSpammer = doorSpammerCheckBox.Checked;
        }


        private void aimbotCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.aimbot = aimbotCheckBox.Checked;
        }

        private void fovTrackBar_Scroll(object sender, EventArgs e)
        {
            float value = fovTrackBar.Value / 100f;
            fovValue.Text = value.ToString(CultureInfo.InvariantCulture);
            Settings.fov = value;
            Hack.Visuals.Perception.CircleOpacity = 255;
        }
        
        private void thirdPersonCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.thirdPerson = thirdPersonCheckBox.Checked;
        }

        private void viewmodelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.viewmodelOverride = viewmodelCheckBox.Checked;
            Hack.Visuals.Perception.ViewmodelOffset();

            Log.Debug(Settings.viewmodel_x, Settings.viewmodel_y, Settings.viewmodel_z);
        }

        private void xTrackBar_Scroll(object sender, EventArgs e)
        {
            Settings.viewmodel_x = xTrackBar.Value / 100f;
            Perception.ViewmodelOffset();
        }

        private void yTrackBar_Scroll(object sender, EventArgs e)
        {
            Settings.viewmodel_y = yTrackBar.Value / 100f;
            Perception.ViewmodelOffset();
        }

        private void zTrackBar_Scroll(object sender, EventArgs e)
        {
            Settings.viewmodel_z = zTrackBar.Value / 100f;
            Perception.ViewmodelOffset();
        }

        private void fovNumeric_ValueChanged(object sender, EventArgs e)
        {
            Settings.visualFov = (int) fovNumeric.Value;
        }

        private void fastStopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.fastStop = fastStopCheckBox.Checked;
        }

        private void teamEspCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.teamEspEnabled = teamEspCheckBox.Checked;
        }

        private void testConfigButton_Click(object sender, EventArgs e)
        {
            SDK.CVar.Force("cl_righthand", 0);
            
            Settings.worldColor = new FloatColor(Color.FromArgb(255, 128, 128, 255));
            Settings.skyboxColor = new FloatColor(Color.FromArgb(255, 255, 200, 255));
            Settings.staticColor = new FloatColor(Color.FromArgb(255, 183, 183, 255));

            Settings.worldColoring = Status.ENABLED;
            Settings.viewmodel_x = -13.13f; //-10,13 1,3 -0,78
            Settings.viewmodel_y = 1.3f;
            Settings.viewmodel_z = -0.78f;

            Settings.aimbot = true;
            Settings.fov = 4;
            Settings.autoStop = true;

            Settings.esp = true;
            Settings.boxes = true;

            Settings.chams = true;
            Settings.enemyChams = true;

            Settings.glow = false;
            Settings.styleGlow = 0;
            Settings.alphaGlow = 0.6f;
            Settings.enemyChamsVisible = new FloatColor(Color.White);
            Settings.enemyGlowColor = new FloatColor(Color.Red);

            Settings.viewmodelOverride = true;

            Settings.blockBot = true;
            Settings.doorSpammer = true;
            Settings.recoilCrosshair = true;
            Settings.bunnyHop = true;
            Settings.hitSound = true;
            Settings.grenadePrediction = true;
            Settings.fastStop = true;
            Settings.voteLogger = true;
            Settings.autoStrafe = true;
            Settings.edgeJump = true;
            Settings.visualFov = 103;
            Settings.spectatorList = true;
            Settings.flashReduce = true;
            Settings.fastCrouch = true;
            Settings.overlay = true;
            Settings.autoCrouch = false;
            Settings.autoAccept = true;
            Settings.rankReveal = true;
            
            Settings.knife = "BAYONET";
            Settings.silentMove = true;
            Settings.jumpBug = true;
            Settings.thirdPerson = true;
            Settings.backtrack = true;
            Settings.backTrackLT = true;

            Settings.voiceEvents = false;
            
            Hack.Visuals.Perception.CircleOpacity = 255;

            Hack.Misc.Checks.needUpdate = true;
            Settings.skinChanger = true;
            Hack.Visuals.SkinChanger.ForceFullupdate();
        }

        private void spectatorListCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.spectatorList = spectatorListCheckBox.Checked;
        }

        private void flashReduceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.flashReduce = flashReduceCheckBox.Checked;
        }

        private void teamGlowCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.teamGlow = teamGlowCheckBox.Checked;
        }


        private void morgenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.voiceEvents = morgenCheckBox.Checked;
        }


        private void autoAcceptCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.autoAccept = autoAcceptCheckBox.Checked;
        }

        private void rankRevealCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.rankReveal = rankRevealCheckBox.Checked;
        }

        private void silentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.silent = silentCheckBox.Checked;
        }


        private void updateSkinButton_Click(object sender, EventArgs e)
        {
            if (knifeComboBox.Text == string.Empty)
                return;
            Settings.knife = knifeComboBox.Text;
            Hack.Visuals.SkinChanger.ForceFullupdate();
        }

        private void skinsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.skinChanger = skinsCheckBox.Checked;
        }

        private void debugEventsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.debugEvents = debugEventsCheckBox.Checked;
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            MovementManager.Start();
        }

        private void button6_Click_4(object sender, EventArgs e)
        {
            MovementManager.Stop();
        }


        private void svPureCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.sv_pure_bypass = svPureCheckBox.Checked;
        }


        private void smoothTrackBar_Scroll(object sender, EventArgs e)
        {
            var value = smoothTrackBar.Value / 100f;
            smoothLabel.Text = value.ToString();
            Settings.smooth = value;
        }


        private void velCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.velocityTag = velCheckBox.Checked;
        }

        private void jumpBugCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.jumpBug = jumpBugCheckBox.Checked;
        }


        private void triggerBotFFCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.aimbotFF = triggerBotFFCheckBox.Checked;
        }


        private void chatBreakerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.chatBreaker = chatBreakerCheckBox.Checked;
        }


        private void fovValue_Click(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            SDK.Engine.SetClanTag(textBox4.Text);
        }


        private void noFallCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.noFall = noFallCheckBox.Checked;
        }


        private void visibleOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.visibleOnly = visibleOnlyCheckBox.Checked;
        }


        private void lifeBugCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.lifeBug = lifeBugCheckBox.Checked;
        }


        private void backtrackCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.backtrack = backtrackCheckBox.Checked;
        }

        private void passiveHCCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.passiveHC = passiveHCCheckBox.Checked;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            Settings.tracerDebug = checkBox6.Checked;
        }

        private void scopeOverlayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.removeScopeOverlay = scopeOverlayCheckBox.Checked;
        }

        public static Random rnd = new Random();

        private void button16_Click(object sender, EventArgs e)
        {
            Settings.color1 = new ByteColor(rnd.Next(255), rnd.Next(255), rnd.Next(255), 255);
            Settings.color2 = new ByteColor(rnd.Next(255), rnd.Next(255), rnd.Next(255), 255);
            Settings.color3 = new ByteColor(rnd.Next(255), rnd.Next(255), rnd.Next(255), 255);
            Settings.color4 = new ByteColor(rnd.Next(255), rnd.Next(255), rnd.Next(255), 255);
            Settings.needRebuildSkin = Status.ENABLED;
        }

        private void numericUpDown3_ValueChanged_2(object sender, EventArgs e)
        {
            Settings.skinId = (int) numericUpDown3.Value;
            Settings.needRebuildSkin = Status.ENABLED;
        }

        private void pearlTrackBar_Scroll(object sender, EventArgs e)
        {
            Settings.pearlescent = pearlTrackBar.Value / 100f;
            Settings.needRebuildSkin = Status.ENABLED;
        }

        private void hitboxList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            Settings.bones[e.Index] = e.NewValue == CheckState.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Settings.backTrackLT = checkBox1.Checked;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MovementManager.Replays.Refresh();
        }
    }
}