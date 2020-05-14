namespace TI_xdt99_IDE
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_Settings = new System.Windows.Forms.TabPage();
            this.label20 = new System.Windows.Forms.Label();
            this.txt_Xdt_Projects = new System.Windows.Forms.TextBox();
            this.txt_ExtEmu_Image = new System.Windows.Forms.TextBox();
            this.txt_ExtWin_Image = new System.Windows.Forms.TextBox();
            this.txt_ExtEmu_List = new System.Windows.Forms.TextBox();
            this.txt_ExtWin_List = new System.Windows.Forms.TextBox();
            this.txt_ExtEmu_Object = new System.Windows.Forms.TextBox();
            this.txt_ExtWin_Object = new System.Windows.Forms.TextBox();
            this.txt_ExtEmu_Source = new System.Windows.Forms.TextBox();
            this.txt_ExtWin_Source = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_Xdt_Library = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_DmCopy_Image = new System.Windows.Forms.TextBox();
            this.txt_DmCopy_List = new System.Windows.Forms.TextBox();
            this.txt_DmCopy_Object = new System.Windows.Forms.TextBox();
            this.txt_DmCopy_Source = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Xdt_DmOptions_Diskfile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Xdt_AsOptions_Image = new System.Windows.Forms.TextBox();
            this.txt_Xdt_AsOptions_Rpk = new System.Windows.Forms.TextBox();
            this.txt_Xdt_DiskManager = new System.Windows.Forms.TextBox();
            this.txt_Xdt_AsOptions_Object = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Xdt_Base = new System.Windows.Forms.TextBox();
            this.txt_Xdt_Assembler = new System.Windows.Forms.TextBox();
            this.txt_Editor_Binary = new System.Windows.Forms.TextBox();
            this.txt_Editor_Options = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tab_IDE = new System.Windows.Forms.TabPage();
            this.txt_Source = new System.Windows.Forms.TextBox();
            this.txt_Project = new System.Windows.Forms.TextBox();
            this.chk_Assembler_Rpk = new System.Windows.Forms.CheckBox();
            this.btn_Emulator = new System.Windows.Forms.Button();
            this.grp_Emu_Cart = new System.Windows.Forms.GroupBox();
            this.opt_Emu_ExBasic = new System.Windows.Forms.RadioButton();
            this.opt_Emu_MiniMem = new System.Windows.Forms.RadioButton();
            this.opt_Emu_EditAss = new System.Windows.Forms.RadioButton();
            this.chk_Copy_AutoStart = new System.Windows.Forms.CheckBox();
            this.btn_New_Project = new System.Windows.Forms.Button();
            this.btn_New_Source = new System.Windows.Forms.Button();
            this.chk_Copy_all = new System.Windows.Forms.CheckBox();
            this.chk_Assembler_all = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.chk_Assembler_Object = new System.Windows.Forms.CheckBox();
            this.chk_Assembler_Image = new System.Windows.Forms.CheckBox();
            this.chk_Copy_Catalog = new System.Windows.Forms.CheckBox();
            this.chk_Copy_Image = new System.Windows.Forms.CheckBox();
            this.chk_Copy_Object = new System.Windows.Forms.CheckBox();
            this.chk_Copy_List = new System.Windows.Forms.CheckBox();
            this.chl_Copy_Source = new System.Windows.Forms.CheckBox();
            this.btn_DiskManager = new System.Windows.Forms.Button();
            this.btn_Assembler = new System.Windows.Forms.Button();
            this.btn_Editor = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.lst_Sourcefiles = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lst_Projects = new System.Windows.Forms.ListBox();
            this.tab_Command = new System.Windows.Forms.TabPage();
            this.tab_StdOut = new System.Windows.Forms.TabPage();
            this.tab_StdErr = new System.Windows.Forms.TabPage();
            this.txt_Command_Stack = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txt_Standard_Output = new System.Windows.Forms.TextBox();
            this.txt_Error_Output = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tab_Settings.SuspendLayout();
            this.tab_IDE.SuspendLayout();
            this.grp_Emu_Cart.SuspendLayout();
            this.tab_Command.SuspendLayout();
            this.tab_StdOut.SuspendLayout();
            this.tab_StdErr.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_Settings);
            this.tabControl1.Controls.Add(this.tab_IDE);
            this.tabControl1.Controls.Add(this.tab_Command);
            this.tabControl1.Controls.Add(this.tab_StdOut);
            this.tabControl1.Controls.Add(this.tab_StdErr);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1160, 612);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tab_Settings
            // 
            this.tab_Settings.Controls.Add(this.label20);
            this.tab_Settings.Controls.Add(this.txt_Xdt_Projects);
            this.tab_Settings.Controls.Add(this.txt_ExtEmu_Image);
            this.tab_Settings.Controls.Add(this.txt_ExtWin_Image);
            this.tab_Settings.Controls.Add(this.txt_ExtEmu_List);
            this.tab_Settings.Controls.Add(this.txt_ExtWin_List);
            this.tab_Settings.Controls.Add(this.txt_ExtEmu_Object);
            this.tab_Settings.Controls.Add(this.txt_ExtWin_Object);
            this.tab_Settings.Controls.Add(this.txt_ExtEmu_Source);
            this.tab_Settings.Controls.Add(this.txt_ExtWin_Source);
            this.tab_Settings.Controls.Add(this.label19);
            this.tab_Settings.Controls.Add(this.label14);
            this.tab_Settings.Controls.Add(this.label13);
            this.tab_Settings.Controls.Add(this.label12);
            this.tab_Settings.Controls.Add(this.txt_Xdt_Library);
            this.tab_Settings.Controls.Add(this.label11);
            this.tab_Settings.Controls.Add(this.label10);
            this.tab_Settings.Controls.Add(this.label9);
            this.tab_Settings.Controls.Add(this.label8);
            this.tab_Settings.Controls.Add(this.txt_DmCopy_Image);
            this.tab_Settings.Controls.Add(this.txt_DmCopy_List);
            this.tab_Settings.Controls.Add(this.txt_DmCopy_Object);
            this.tab_Settings.Controls.Add(this.txt_DmCopy_Source);
            this.tab_Settings.Controls.Add(this.label7);
            this.tab_Settings.Controls.Add(this.txt_Xdt_DmOptions_Diskfile);
            this.tab_Settings.Controls.Add(this.label6);
            this.tab_Settings.Controls.Add(this.label5);
            this.tab_Settings.Controls.Add(this.txt_Xdt_AsOptions_Image);
            this.tab_Settings.Controls.Add(this.txt_Xdt_AsOptions_Rpk);
            this.tab_Settings.Controls.Add(this.txt_Xdt_DiskManager);
            this.tab_Settings.Controls.Add(this.txt_Xdt_AsOptions_Object);
            this.tab_Settings.Controls.Add(this.label4);
            this.tab_Settings.Controls.Add(this.label3);
            this.tab_Settings.Controls.Add(this.label2);
            this.tab_Settings.Controls.Add(this.txt_Xdt_Base);
            this.tab_Settings.Controls.Add(this.txt_Xdt_Assembler);
            this.tab_Settings.Controls.Add(this.txt_Editor_Binary);
            this.tab_Settings.Controls.Add(this.txt_Editor_Options);
            this.tab_Settings.Controls.Add(this.label1);
            this.tab_Settings.Location = new System.Drawing.Point(4, 29);
            this.tab_Settings.Name = "tab_Settings";
            this.tab_Settings.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Settings.Size = new System.Drawing.Size(1152, 579);
            this.tab_Settings.TabIndex = 0;
            this.tab_Settings.Text = "Settings";
            this.tab_Settings.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(32, 145);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(66, 20);
            this.label20.TabIndex = 39;
            this.label20.Text = "Projects";
            // 
            // txt_Xdt_Projects
            // 
            this.txt_Xdt_Projects.Location = new System.Drawing.Point(160, 142);
            this.txt_Xdt_Projects.Name = "txt_Xdt_Projects";
            this.txt_Xdt_Projects.Size = new System.Drawing.Size(128, 26);
            this.txt_Xdt_Projects.TabIndex = 38;
            this.txt_Xdt_Projects.Text = "projects\\";
            // 
            // txt_ExtEmu_Image
            // 
            this.txt_ExtEmu_Image.Location = new System.Drawing.Point(930, 430);
            this.txt_ExtEmu_Image.Name = "txt_ExtEmu_Image";
            this.txt_ExtEmu_Image.Size = new System.Drawing.Size(64, 26);
            this.txt_ExtEmu_Image.TabIndex = 37;
            this.txt_ExtEmu_Image.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_ExtWin_Image
            // 
            this.txt_ExtWin_Image.Location = new System.Drawing.Point(860, 430);
            this.txt_ExtWin_Image.Name = "txt_ExtWin_Image";
            this.txt_ExtWin_Image.Size = new System.Drawing.Size(64, 26);
            this.txt_ExtWin_Image.TabIndex = 36;
            this.txt_ExtWin_Image.Text = "img";
            this.txt_ExtWin_Image.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_ExtEmu_List
            // 
            this.txt_ExtEmu_List.Location = new System.Drawing.Point(930, 398);
            this.txt_ExtEmu_List.Name = "txt_ExtEmu_List";
            this.txt_ExtEmu_List.Size = new System.Drawing.Size(64, 26);
            this.txt_ExtEmu_List.TabIndex = 35;
            this.txt_ExtEmu_List.Text = "L";
            this.txt_ExtEmu_List.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_ExtWin_List
            // 
            this.txt_ExtWin_List.Location = new System.Drawing.Point(860, 398);
            this.txt_ExtWin_List.Name = "txt_ExtWin_List";
            this.txt_ExtWin_List.Size = new System.Drawing.Size(64, 26);
            this.txt_ExtWin_List.TabIndex = 34;
            this.txt_ExtWin_List.Text = "txt";
            this.txt_ExtWin_List.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_ExtEmu_Object
            // 
            this.txt_ExtEmu_Object.Location = new System.Drawing.Point(930, 366);
            this.txt_ExtEmu_Object.Name = "txt_ExtEmu_Object";
            this.txt_ExtEmu_Object.Size = new System.Drawing.Size(64, 26);
            this.txt_ExtEmu_Object.TabIndex = 33;
            this.txt_ExtEmu_Object.Text = "O";
            this.txt_ExtEmu_Object.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_ExtWin_Object
            // 
            this.txt_ExtWin_Object.Location = new System.Drawing.Point(860, 366);
            this.txt_ExtWin_Object.Name = "txt_ExtWin_Object";
            this.txt_ExtWin_Object.Size = new System.Drawing.Size(64, 26);
            this.txt_ExtWin_Object.TabIndex = 32;
            this.txt_ExtWin_Object.Text = "obj";
            this.txt_ExtWin_Object.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_ExtEmu_Source
            // 
            this.txt_ExtEmu_Source.Location = new System.Drawing.Point(930, 334);
            this.txt_ExtEmu_Source.Name = "txt_ExtEmu_Source";
            this.txt_ExtEmu_Source.Size = new System.Drawing.Size(64, 26);
            this.txt_ExtEmu_Source.TabIndex = 31;
            this.txt_ExtEmu_Source.Text = "S";
            this.txt_ExtEmu_Source.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_ExtWin_Source
            // 
            this.txt_ExtWin_Source.Location = new System.Drawing.Point(860, 334);
            this.txt_ExtWin_Source.Name = "txt_ExtWin_Source";
            this.txt_ExtWin_Source.Size = new System.Drawing.Size(64, 26);
            this.txt_ExtWin_Source.TabIndex = 30;
            this.txt_ExtWin_Source.Text = "a99";
            this.txt_ExtWin_Source.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(32, 15);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(218, 20);
            this.label19.TabIndex = 28;
            this.label19.Text = "external Editor for source files";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(32, 305);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 20);
            this.label14.TabIndex = 27;
            this.label14.Text = "Disk Manager";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(32, 209);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 20);
            this.label13.TabIndex = 26;
            this.label13.Text = "Assembler";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(32, 177);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 20);
            this.label12.TabIndex = 25;
            this.label12.Text = "Libraries";
            // 
            // txt_Xdt_Library
            // 
            this.txt_Xdt_Library.Location = new System.Drawing.Point(160, 174);
            this.txt_Xdt_Library.Name = "txt_Xdt_Library";
            this.txt_Xdt_Library.Size = new System.Drawing.Size(128, 26);
            this.txt_Xdt_Library.TabIndex = 24;
            this.txt_Xdt_Library.Text = "lib\\";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(678, 433);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 20);
            this.label11.TabIndex = 23;
            this.label11.Text = "copy EA5 file";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(678, 401);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "copy list file";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(678, 369);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "copy EA3 file";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(678, 337);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "copy source file";
            // 
            // txt_DmCopy_Image
            // 
            this.txt_DmCopy_Image.Location = new System.Drawing.Point(294, 430);
            this.txt_DmCopy_Image.Name = "txt_DmCopy_Image";
            this.txt_DmCopy_Image.Size = new System.Drawing.Size(378, 26);
            this.txt_DmCopy_Image.TabIndex = 19;
            this.txt_DmCopy_Image.Text = "<prjname> -a <imgfile> -n <tiimgfile> -f DIS/VAR80";
            // 
            // txt_DmCopy_List
            // 
            this.txt_DmCopy_List.Location = new System.Drawing.Point(294, 398);
            this.txt_DmCopy_List.Name = "txt_DmCopy_List";
            this.txt_DmCopy_List.Size = new System.Drawing.Size(378, 26);
            this.txt_DmCopy_List.TabIndex = 18;
            this.txt_DmCopy_List.Text = "<prjname> -a <lstfile> -n <tilstfile> -f DIS/VAR80";
            // 
            // txt_DmCopy_Object
            // 
            this.txt_DmCopy_Object.Location = new System.Drawing.Point(294, 366);
            this.txt_DmCopy_Object.Name = "txt_DmCopy_Object";
            this.txt_DmCopy_Object.Size = new System.Drawing.Size(378, 26);
            this.txt_DmCopy_Object.TabIndex = 17;
            this.txt_DmCopy_Object.Text = "<prjname> -a <objfile> -n <tiobjfile> -f DIS/FIX80";
            // 
            // txt_DmCopy_Source
            // 
            this.txt_DmCopy_Source.Location = new System.Drawing.Point(294, 334);
            this.txt_DmCopy_Source.Name = "txt_DmCopy_Source";
            this.txt_DmCopy_Source.Size = new System.Drawing.Size(378, 26);
            this.txt_DmCopy_Source.TabIndex = 16;
            this.txt_DmCopy_Source.Text = "<prjname> -a <srcfile> -n <tisrcfile> -f DIS/VAR80";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(678, 305);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "create disk image file";
            // 
            // txt_Xdt_DmOptions_Diskfile
            // 
            this.txt_Xdt_DmOptions_Diskfile.Location = new System.Drawing.Point(294, 302);
            this.txt_Xdt_DmOptions_Diskfile.Name = "txt_Xdt_DmOptions_Diskfile";
            this.txt_Xdt_DmOptions_Diskfile.Size = new System.Drawing.Size(378, 26);
            this.txt_Xdt_DmOptions_Diskfile.TabIndex = 14;
            this.txt_Xdt_DmOptions_Diskfile.Text = "-X 2s2d40t <prjname>.dsk";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(678, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "create EA5 image file";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(678, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "create MESS .rpk file";
            // 
            // txt_Xdt_AsOptions_Image
            // 
            this.txt_Xdt_AsOptions_Image.Location = new System.Drawing.Point(294, 270);
            this.txt_Xdt_AsOptions_Image.Name = "txt_Xdt_AsOptions_Image";
            this.txt_Xdt_AsOptions_Image.Size = new System.Drawing.Size(378, 26);
            this.txt_Xdt_AsOptions_Image.TabIndex = 11;
            this.txt_Xdt_AsOptions_Image.Text = "-R -S -I <libpath> -i <srcfile>";
            // 
            // txt_Xdt_AsOptions_Rpk
            // 
            this.txt_Xdt_AsOptions_Rpk.Location = new System.Drawing.Point(294, 238);
            this.txt_Xdt_AsOptions_Rpk.Name = "txt_Xdt_AsOptions_Rpk";
            this.txt_Xdt_AsOptions_Rpk.Size = new System.Drawing.Size(378, 26);
            this.txt_Xdt_AsOptions_Rpk.TabIndex = 10;
            this.txt_Xdt_AsOptions_Rpk.Text = "-R -S -I <libpath> -c <srcfile>";
            // 
            // txt_Xdt_DiskManager
            // 
            this.txt_Xdt_DiskManager.Location = new System.Drawing.Point(160, 302);
            this.txt_Xdt_DiskManager.Name = "txt_Xdt_DiskManager";
            this.txt_Xdt_DiskManager.Size = new System.Drawing.Size(128, 26);
            this.txt_Xdt_DiskManager.TabIndex = 9;
            this.txt_Xdt_DiskManager.Text = "xdm99.py";
            // 
            // txt_Xdt_AsOptions_Object
            // 
            this.txt_Xdt_AsOptions_Object.Location = new System.Drawing.Point(294, 206);
            this.txt_Xdt_AsOptions_Object.Name = "txt_Xdt_AsOptions_Object";
            this.txt_Xdt_AsOptions_Object.Size = new System.Drawing.Size(378, 26);
            this.txt_Xdt_AsOptions_Object.TabIndex = 8;
            this.txt_Xdt_AsOptions_Object.Text = "-R -S -I <libpath> -L <lstfile> <srcfile>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "XDT99 Cross-Assembler";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(678, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "create EA3 object file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Base Dir";
            // 
            // txt_Xdt_Base
            // 
            this.txt_Xdt_Base.Location = new System.Drawing.Point(160, 110);
            this.txt_Xdt_Base.Name = "txt_Xdt_Base";
            this.txt_Xdt_Base.Size = new System.Drawing.Size(512, 26);
            this.txt_Xdt_Base.TabIndex = 4;
            this.txt_Xdt_Base.Text = "E:\\TI99\\xdt99\\";
            // 
            // txt_Xdt_Assembler
            // 
            this.txt_Xdt_Assembler.Location = new System.Drawing.Point(160, 206);
            this.txt_Xdt_Assembler.Name = "txt_Xdt_Assembler";
            this.txt_Xdt_Assembler.Size = new System.Drawing.Size(128, 26);
            this.txt_Xdt_Assembler.TabIndex = 3;
            this.txt_Xdt_Assembler.Text = "xas99.py";
            // 
            // txt_Editor_Binary
            // 
            this.txt_Editor_Binary.Location = new System.Drawing.Point(160, 38);
            this.txt_Editor_Binary.Name = "txt_Editor_Binary";
            this.txt_Editor_Binary.Size = new System.Drawing.Size(512, 26);
            this.txt_Editor_Binary.TabIndex = 2;
            this.txt_Editor_Binary.Text = "C:\\Program Files (x86)\\Notepad++\\notepad++.exe";
            // 
            // txt_Editor_Options
            // 
            this.txt_Editor_Options.Location = new System.Drawing.Point(678, 38);
            this.txt_Editor_Options.Name = "txt_Editor_Options";
            this.txt_Editor_Options.Size = new System.Drawing.Size(256, 26);
            this.txt_Editor_Options.TabIndex = 1;
            this.txt_Editor_Options.Text = "<srcfile>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Editor";
            // 
            // tab_IDE
            // 
            this.tab_IDE.Controls.Add(this.txt_Source);
            this.tab_IDE.Controls.Add(this.txt_Project);
            this.tab_IDE.Controls.Add(this.chk_Assembler_Rpk);
            this.tab_IDE.Controls.Add(this.btn_Emulator);
            this.tab_IDE.Controls.Add(this.grp_Emu_Cart);
            this.tab_IDE.Controls.Add(this.chk_Copy_AutoStart);
            this.tab_IDE.Controls.Add(this.btn_New_Project);
            this.tab_IDE.Controls.Add(this.btn_New_Source);
            this.tab_IDE.Controls.Add(this.chk_Copy_all);
            this.tab_IDE.Controls.Add(this.chk_Assembler_all);
            this.tab_IDE.Controls.Add(this.label18);
            this.tab_IDE.Controls.Add(this.label17);
            this.tab_IDE.Controls.Add(this.chk_Assembler_Object);
            this.tab_IDE.Controls.Add(this.chk_Assembler_Image);
            this.tab_IDE.Controls.Add(this.chk_Copy_Catalog);
            this.tab_IDE.Controls.Add(this.chk_Copy_Image);
            this.tab_IDE.Controls.Add(this.chk_Copy_Object);
            this.tab_IDE.Controls.Add(this.chk_Copy_List);
            this.tab_IDE.Controls.Add(this.chl_Copy_Source);
            this.tab_IDE.Controls.Add(this.btn_DiskManager);
            this.tab_IDE.Controls.Add(this.btn_Assembler);
            this.tab_IDE.Controls.Add(this.btn_Editor);
            this.tab_IDE.Controls.Add(this.label16);
            this.tab_IDE.Controls.Add(this.lst_Sourcefiles);
            this.tab_IDE.Controls.Add(this.label15);
            this.tab_IDE.Controls.Add(this.lst_Projects);
            this.tab_IDE.Location = new System.Drawing.Point(4, 29);
            this.tab_IDE.Name = "tab_IDE";
            this.tab_IDE.Padding = new System.Windows.Forms.Padding(3);
            this.tab_IDE.Size = new System.Drawing.Size(1152, 579);
            this.tab_IDE.TabIndex = 1;
            this.tab_IDE.Text = "IDE";
            this.tab_IDE.UseVisualStyleBackColor = true;
            // 
            // txt_Source
            // 
            this.txt_Source.Location = new System.Drawing.Point(368, 70);
            this.txt_Source.Name = "txt_Source";
            this.txt_Source.Size = new System.Drawing.Size(256, 26);
            this.txt_Source.TabIndex = 29;
            this.txt_Source.Text = "samplesource";
            // 
            // txt_Project
            // 
            this.txt_Project.Location = new System.Drawing.Point(368, 38);
            this.txt_Project.Name = "txt_Project";
            this.txt_Project.Size = new System.Drawing.Size(256, 26);
            this.txt_Project.TabIndex = 28;
            this.txt_Project.Text = "sampleproject";
            // 
            // chk_Assembler_Rpk
            // 
            this.chk_Assembler_Rpk.AutoSize = true;
            this.chk_Assembler_Rpk.Location = new System.Drawing.Point(526, 238);
            this.chk_Assembler_Rpk.Name = "chk_Assembler_Rpk";
            this.chk_Assembler_Rpk.Size = new System.Drawing.Size(50, 24);
            this.chk_Assembler_Rpk.TabIndex = 27;
            this.chk_Assembler_Rpk.Text = "rpk";
            this.chk_Assembler_Rpk.UseVisualStyleBackColor = true;
            // 
            // btn_Emulator
            // 
            this.btn_Emulator.Location = new System.Drawing.Point(368, 456);
            this.btn_Emulator.Name = "btn_Emulator";
            this.btn_Emulator.Size = new System.Drawing.Size(128, 32);
            this.btn_Emulator.TabIndex = 7;
            this.btn_Emulator.Text = "Emulator";
            this.btn_Emulator.UseVisualStyleBackColor = true;
            this.btn_Emulator.Click += new System.EventHandler(this.btn_Emulator_Click);
            // 
            // grp_Emu_Cart
            // 
            this.grp_Emu_Cart.Controls.Add(this.opt_Emu_ExBasic);
            this.grp_Emu_Cart.Controls.Add(this.opt_Emu_MiniMem);
            this.grp_Emu_Cart.Controls.Add(this.opt_Emu_EditAss);
            this.grp_Emu_Cart.Location = new System.Drawing.Point(368, 486);
            this.grp_Emu_Cart.Name = "grp_Emu_Cart";
            this.grp_Emu_Cart.Size = new System.Drawing.Size(171, 36);
            this.grp_Emu_Cart.TabIndex = 26;
            this.grp_Emu_Cart.TabStop = false;
            // 
            // opt_Emu_ExBasic
            // 
            this.opt_Emu_ExBasic.AutoSize = true;
            this.opt_Emu_ExBasic.Location = new System.Drawing.Point(120, 10);
            this.opt_Emu_ExBasic.Name = "opt_Emu_ExBasic";
            this.opt_Emu_ExBasic.Size = new System.Drawing.Size(49, 24);
            this.opt_Emu_ExBasic.TabIndex = 28;
            this.opt_Emu_ExBasic.Text = "XB";
            this.opt_Emu_ExBasic.UseVisualStyleBackColor = true;
            // 
            // opt_Emu_MiniMem
            // 
            this.opt_Emu_MiniMem.AutoSize = true;
            this.opt_Emu_MiniMem.Location = new System.Drawing.Point(61, 10);
            this.opt_Emu_MiniMem.Name = "opt_Emu_MiniMem";
            this.opt_Emu_MiniMem.Size = new System.Drawing.Size(53, 24);
            this.opt_Emu_MiniMem.TabIndex = 27;
            this.opt_Emu_MiniMem.Text = "MM";
            this.opt_Emu_MiniMem.UseVisualStyleBackColor = true;
            // 
            // opt_Emu_EditAss
            // 
            this.opt_Emu_EditAss.AutoSize = true;
            this.opt_Emu_EditAss.Checked = true;
            this.opt_Emu_EditAss.Location = new System.Drawing.Point(6, 10);
            this.opt_Emu_EditAss.Name = "opt_Emu_EditAss";
            this.opt_Emu_EditAss.Size = new System.Drawing.Size(49, 24);
            this.opt_Emu_EditAss.TabIndex = 26;
            this.opt_Emu_EditAss.TabStop = true;
            this.opt_Emu_EditAss.Text = "EA";
            this.opt_Emu_EditAss.UseVisualStyleBackColor = true;
            // 
            // chk_Copy_AutoStart
            // 
            this.chk_Copy_AutoStart.AutoSize = true;
            this.chk_Copy_AutoStart.Checked = true;
            this.chk_Copy_AutoStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Copy_AutoStart.Location = new System.Drawing.Point(458, 406);
            this.chk_Copy_AutoStart.Name = "chk_Copy_AutoStart";
            this.chk_Copy_AutoStart.Size = new System.Drawing.Size(92, 24);
            this.chk_Copy_AutoStart.TabIndex = 22;
            this.chk_Copy_AutoStart.Text = "autostart";
            this.chk_Copy_AutoStart.UseVisualStyleBackColor = true;
            // 
            // btn_New_Project
            // 
            this.btn_New_Project.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_New_Project.Location = new System.Drawing.Point(174, 540);
            this.btn_New_Project.Name = "btn_New_Project";
            this.btn_New_Project.Size = new System.Drawing.Size(22, 22);
            this.btn_New_Project.TabIndex = 21;
            this.btn_New_Project.Text = "+";
            this.btn_New_Project.UseVisualStyleBackColor = true;
            this.btn_New_Project.Click += new System.EventHandler(this.btn_New_Project_Click);
            // 
            // btn_New_Source
            // 
            this.btn_New_Source.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_New_Source.Location = new System.Drawing.Point(340, 540);
            this.btn_New_Source.Name = "btn_New_Source";
            this.btn_New_Source.Size = new System.Drawing.Size(22, 22);
            this.btn_New_Source.TabIndex = 20;
            this.btn_New_Source.Text = "+";
            this.btn_New_Source.UseVisualStyleBackColor = true;
            this.btn_New_Source.Click += new System.EventHandler(this.btn_New_Source_Click);
            // 
            // chk_Copy_all
            // 
            this.chk_Copy_all.AutoSize = true;
            this.chk_Copy_all.Checked = true;
            this.chk_Copy_all.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Copy_all.Location = new System.Drawing.Point(506, 293);
            this.chk_Copy_all.Name = "chk_Copy_all";
            this.chk_Copy_all.Size = new System.Drawing.Size(43, 24);
            this.chk_Copy_all.TabIndex = 19;
            this.chk_Copy_all.Text = "all";
            this.chk_Copy_all.UseVisualStyleBackColor = true;
            // 
            // chk_Assembler_all
            // 
            this.chk_Assembler_all.AutoSize = true;
            this.chk_Assembler_all.Checked = true;
            this.chk_Assembler_all.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Assembler_all.Location = new System.Drawing.Point(502, 185);
            this.chk_Assembler_all.Name = "chk_Assembler_all";
            this.chk_Assembler_all.Size = new System.Drawing.Size(43, 24);
            this.chk_Assembler_all.TabIndex = 18;
            this.chk_Assembler_all.Text = "all";
            this.chk_Assembler_all.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(368, 323);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 20);
            this.label18.TabIndex = 17;
            this.label18.Text = "copy:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(368, 215);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 20);
            this.label17.TabIndex = 16;
            this.label17.Text = "create:";
            // 
            // chk_Assembler_Object
            // 
            this.chk_Assembler_Object.AutoSize = true;
            this.chk_Assembler_Object.Checked = true;
            this.chk_Assembler_Object.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Assembler_Object.Location = new System.Drawing.Point(372, 238);
            this.chk_Assembler_Object.Name = "chk_Assembler_Object";
            this.chk_Assembler_Object.Size = new System.Drawing.Size(71, 24);
            this.chk_Assembler_Object.TabIndex = 15;
            this.chk_Assembler_Object.Text = "object";
            this.chk_Assembler_Object.UseVisualStyleBackColor = true;
            // 
            // chk_Assembler_Image
            // 
            this.chk_Assembler_Image.AutoSize = true;
            this.chk_Assembler_Image.Location = new System.Drawing.Point(449, 238);
            this.chk_Assembler_Image.Name = "chk_Assembler_Image";
            this.chk_Assembler_Image.Size = new System.Drawing.Size(71, 24);
            this.chk_Assembler_Image.TabIndex = 14;
            this.chk_Assembler_Image.Text = "image";
            this.chk_Assembler_Image.UseVisualStyleBackColor = true;
            // 
            // chk_Copy_Catalog
            // 
            this.chk_Copy_Catalog.AutoSize = true;
            this.chk_Copy_Catalog.Checked = true;
            this.chk_Copy_Catalog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Copy_Catalog.Location = new System.Drawing.Point(372, 406);
            this.chk_Copy_Catalog.Name = "chk_Copy_Catalog";
            this.chk_Copy_Catalog.Size = new System.Drawing.Size(80, 24);
            this.chk_Copy_Catalog.TabIndex = 12;
            this.chk_Copy_Catalog.Text = "catalog";
            this.chk_Copy_Catalog.UseVisualStyleBackColor = true;
            // 
            // chk_Copy_Image
            // 
            this.chk_Copy_Image.AutoSize = true;
            this.chk_Copy_Image.Location = new System.Drawing.Point(502, 376);
            this.chk_Copy_Image.Name = "chk_Copy_Image";
            this.chk_Copy_Image.Size = new System.Drawing.Size(71, 24);
            this.chk_Copy_Image.TabIndex = 11;
            this.chk_Copy_Image.Text = "image";
            this.chk_Copy_Image.UseVisualStyleBackColor = true;
            // 
            // chk_Copy_Object
            // 
            this.chk_Copy_Object.AutoSize = true;
            this.chk_Copy_Object.Checked = true;
            this.chk_Copy_Object.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Copy_Object.Location = new System.Drawing.Point(425, 376);
            this.chk_Copy_Object.Name = "chk_Copy_Object";
            this.chk_Copy_Object.Size = new System.Drawing.Size(71, 24);
            this.chk_Copy_Object.TabIndex = 10;
            this.chk_Copy_Object.Text = "object";
            this.chk_Copy_Object.UseVisualStyleBackColor = true;
            // 
            // chk_Copy_List
            // 
            this.chk_Copy_List.AutoSize = true;
            this.chk_Copy_List.Location = new System.Drawing.Point(372, 376);
            this.chk_Copy_List.Name = "chk_Copy_List";
            this.chk_Copy_List.Size = new System.Drawing.Size(47, 24);
            this.chk_Copy_List.TabIndex = 9;
            this.chk_Copy_List.Text = "list";
            this.chk_Copy_List.UseVisualStyleBackColor = true;
            // 
            // chl_Copy_Source
            // 
            this.chl_Copy_Source.AutoSize = true;
            this.chl_Copy_Source.Location = new System.Drawing.Point(372, 346);
            this.chl_Copy_Source.Name = "chl_Copy_Source";
            this.chl_Copy_Source.Size = new System.Drawing.Size(76, 24);
            this.chl_Copy_Source.TabIndex = 8;
            this.chl_Copy_Source.Text = "source";
            this.chl_Copy_Source.UseVisualStyleBackColor = true;
            // 
            // btn_DiskManager
            // 
            this.btn_DiskManager.Location = new System.Drawing.Point(368, 288);
            this.btn_DiskManager.Name = "btn_DiskManager";
            this.btn_DiskManager.Size = new System.Drawing.Size(128, 32);
            this.btn_DiskManager.TabIndex = 6;
            this.btn_DiskManager.Text = "Disk";
            this.btn_DiskManager.UseVisualStyleBackColor = true;
            this.btn_DiskManager.Click += new System.EventHandler(this.btn_DiskManager_Click);
            // 
            // btn_Assembler
            // 
            this.btn_Assembler.Location = new System.Drawing.Point(368, 180);
            this.btn_Assembler.Name = "btn_Assembler";
            this.btn_Assembler.Size = new System.Drawing.Size(128, 32);
            this.btn_Assembler.TabIndex = 5;
            this.btn_Assembler.Text = "Assemble";
            this.btn_Assembler.UseVisualStyleBackColor = true;
            this.btn_Assembler.Click += new System.EventHandler(this.btn_Assembler_Click);
            // 
            // btn_Editor
            // 
            this.btn_Editor.Location = new System.Drawing.Point(368, 122);
            this.btn_Editor.Name = "btn_Editor";
            this.btn_Editor.Size = new System.Drawing.Size(128, 32);
            this.btn_Editor.TabIndex = 4;
            this.btn_Editor.Text = "Edit";
            this.btn_Editor.UseVisualStyleBackColor = true;
            this.btn_Editor.Click += new System.EventHandler(this.btn_Editor_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(198, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(107, 20);
            this.label16.TabIndex = 3;
            this.label16.Text = "select source:";
            // 
            // lst_Sourcefiles
            // 
            this.lst_Sourcefiles.FormattingEnabled = true;
            this.lst_Sourcefiles.ItemHeight = 20;
            this.lst_Sourcefiles.Location = new System.Drawing.Point(202, 38);
            this.lst_Sourcefiles.Name = "lst_Sourcefiles";
            this.lst_Sourcefiles.Size = new System.Drawing.Size(160, 524);
            this.lst_Sourcefiles.TabIndex = 2;
            this.lst_Sourcefiles.SelectedIndexChanged += new System.EventHandler(this.lst_Sourcefiles_SelectedIndexChanged);
            this.lst_Sourcefiles.DoubleClick += new System.EventHandler(this.lst_Sourcefiles_DoubleClick);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(32, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 20);
            this.label15.TabIndex = 1;
            this.label15.Text = "select project:";
            // 
            // lst_Projects
            // 
            this.lst_Projects.FormattingEnabled = true;
            this.lst_Projects.ItemHeight = 20;
            this.lst_Projects.Location = new System.Drawing.Point(36, 38);
            this.lst_Projects.Name = "lst_Projects";
            this.lst_Projects.Size = new System.Drawing.Size(160, 524);
            this.lst_Projects.TabIndex = 0;
            this.lst_Projects.SelectedIndexChanged += new System.EventHandler(this.lst_Projects_SelectedIndexChanged);
            // 
            // tab_Command
            // 
            this.tab_Command.Controls.Add(this.label21);
            this.tab_Command.Controls.Add(this.txt_Command_Stack);
            this.tab_Command.Location = new System.Drawing.Point(4, 29);
            this.tab_Command.Name = "tab_Command";
            this.tab_Command.Size = new System.Drawing.Size(1152, 579);
            this.tab_Command.TabIndex = 2;
            this.tab_Command.Text = "Cmd";
            this.tab_Command.UseVisualStyleBackColor = true;
            // 
            // tab_StdOut
            // 
            this.tab_StdOut.Controls.Add(this.txt_Standard_Output);
            this.tab_StdOut.Controls.Add(this.label22);
            this.tab_StdOut.Location = new System.Drawing.Point(4, 29);
            this.tab_StdOut.Name = "tab_StdOut";
            this.tab_StdOut.Size = new System.Drawing.Size(1152, 579);
            this.tab_StdOut.TabIndex = 3;
            this.tab_StdOut.Text = "Out";
            this.tab_StdOut.UseVisualStyleBackColor = true;
            // 
            // tab_StdErr
            // 
            this.tab_StdErr.Controls.Add(this.txt_Error_Output);
            this.tab_StdErr.Controls.Add(this.label23);
            this.tab_StdErr.Location = new System.Drawing.Point(4, 29);
            this.tab_StdErr.Name = "tab_StdErr";
            this.tab_StdErr.Size = new System.Drawing.Size(1152, 579);
            this.tab_StdErr.TabIndex = 4;
            this.tab_StdErr.Text = "Err";
            this.tab_StdErr.UseVisualStyleBackColor = true;
            // 
            // txt_Command_Stack
            // 
            this.txt_Command_Stack.Location = new System.Drawing.Point(36, 38);
            this.txt_Command_Stack.Multiline = true;
            this.txt_Command_Stack.Name = "txt_Command_Stack";
            this.txt_Command_Stack.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Command_Stack.Size = new System.Drawing.Size(1080, 512);
            this.txt_Command_Stack.TabIndex = 31;
            this.txt_Command_Stack.WordWrap = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(32, 15);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(128, 20);
            this.label21.TabIndex = 32;
            this.label21.Text = "Command stack:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(32, 15);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(132, 20);
            this.label22.TabIndex = 29;
            this.label22.Text = "Standard Output:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(32, 15);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(101, 20);
            this.label23.TabIndex = 29;
            this.label23.Text = "Error Output:";
            // 
            // txt_Standard_Output
            // 
            this.txt_Standard_Output.Location = new System.Drawing.Point(36, 38);
            this.txt_Standard_Output.Multiline = true;
            this.txt_Standard_Output.Name = "txt_Standard_Output";
            this.txt_Standard_Output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Standard_Output.Size = new System.Drawing.Size(1080, 512);
            this.txt_Standard_Output.TabIndex = 32;
            this.txt_Standard_Output.WordWrap = false;
            // 
            // txt_Error_Output
            // 
            this.txt_Error_Output.Location = new System.Drawing.Point(36, 38);
            this.txt_Error_Output.Multiline = true;
            this.txt_Error_Output.Name = "txt_Error_Output";
            this.txt_Error_Output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Error_Output.Size = new System.Drawing.Size(1080, 512);
            this.txt_Error_Output.TabIndex = 32;
            this.txt_Error_Output.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 636);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tab_Settings.ResumeLayout(false);
            this.tab_Settings.PerformLayout();
            this.tab_IDE.ResumeLayout(false);
            this.tab_IDE.PerformLayout();
            this.grp_Emu_Cart.ResumeLayout(false);
            this.grp_Emu_Cart.PerformLayout();
            this.tab_Command.ResumeLayout(false);
            this.tab_Command.PerformLayout();
            this.tab_StdOut.ResumeLayout(false);
            this.tab_StdOut.PerformLayout();
            this.tab_StdErr.ResumeLayout(false);
            this.tab_StdErr.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_Settings;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_Xdt_Library;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_DmCopy_Image;
        private System.Windows.Forms.TextBox txt_DmCopy_List;
        private System.Windows.Forms.TextBox txt_DmCopy_Object;
        private System.Windows.Forms.TextBox txt_DmCopy_Source;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Xdt_DmOptions_Diskfile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Xdt_AsOptions_Image;
        private System.Windows.Forms.TextBox txt_Xdt_AsOptions_Rpk;
        private System.Windows.Forms.TextBox txt_Xdt_DiskManager;
        private System.Windows.Forms.TextBox txt_Xdt_AsOptions_Object;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Xdt_Base;
        private System.Windows.Forms.TextBox txt_Xdt_Assembler;
        private System.Windows.Forms.TextBox txt_Editor_Binary;
        private System.Windows.Forms.TextBox txt_Editor_Options;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tab_IDE;
        private System.Windows.Forms.CheckBox chl_Copy_Source;
        private System.Windows.Forms.Button btn_Emulator;
        private System.Windows.Forms.Button btn_DiskManager;
        private System.Windows.Forms.Button btn_Assembler;
        private System.Windows.Forms.Button btn_Editor;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ListBox lst_Sourcefiles;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListBox lst_Projects;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox chk_Assembler_Object;
        private System.Windows.Forms.CheckBox chk_Assembler_Image;
        private System.Windows.Forms.CheckBox chk_Copy_Catalog;
        private System.Windows.Forms.CheckBox chk_Copy_Image;
        private System.Windows.Forms.CheckBox chk_Copy_Object;
        private System.Windows.Forms.CheckBox chk_Copy_List;
        private System.Windows.Forms.Button btn_New_Project;
        private System.Windows.Forms.Button btn_New_Source;
        private System.Windows.Forms.CheckBox chk_Copy_all;
        private System.Windows.Forms.CheckBox chk_Assembler_all;
        private System.Windows.Forms.TextBox txt_ExtEmu_Image;
        private System.Windows.Forms.TextBox txt_ExtWin_Image;
        private System.Windows.Forms.TextBox txt_ExtEmu_List;
        private System.Windows.Forms.TextBox txt_ExtWin_List;
        private System.Windows.Forms.TextBox txt_ExtEmu_Object;
        private System.Windows.Forms.TextBox txt_ExtWin_Object;
        private System.Windows.Forms.TextBox txt_ExtEmu_Source;
        private System.Windows.Forms.TextBox txt_ExtWin_Source;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox grp_Emu_Cart;
        private System.Windows.Forms.RadioButton opt_Emu_ExBasic;
        private System.Windows.Forms.RadioButton opt_Emu_MiniMem;
        private System.Windows.Forms.RadioButton opt_Emu_EditAss;
        private System.Windows.Forms.CheckBox chk_Copy_AutoStart;
        private System.Windows.Forms.CheckBox chk_Assembler_Rpk;
        private System.Windows.Forms.TextBox txt_Source;
        private System.Windows.Forms.TextBox txt_Project;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txt_Xdt_Projects;
        private System.Windows.Forms.TabPage tab_Command;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txt_Command_Stack;
        private System.Windows.Forms.TabPage tab_StdOut;
        private System.Windows.Forms.TextBox txt_Standard_Output;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TabPage tab_StdErr;
        private System.Windows.Forms.TextBox txt_Error_Output;
        private System.Windows.Forms.Label label23;
    }
}

