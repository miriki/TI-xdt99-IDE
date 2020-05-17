using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace TI_xdt99_IDE
{

    public partial class Form1 : Form
    {

        //  ********************************************************************
        // **********************************************************************
        // ***                                                                ***
        // ***   variables, conctants etc.                                    ***
        // ***                                                                ***
        // **********************************************************************
        //  ********************************************************************

        private static readonly string[] keywords =
        {
            "<libpath>", "<lstfile>", "<srcfile>", "<prjname>", "<tisrcfile>",
            "<tiobjfile>", "<tilstfile>", "<tiimgfile>", "<prjdisk>", "<objfile>",
            "<imgfile>", "<runfile>", "<tirunfile>", "<tiprjname>", "<ticart>",
            "<basfile>"
        };

        private static readonly string[] basload1 =
        {
            "100 CALL CLEAR",
            "110 CALL INIT",
            "120 DIM T$(5)",
            "130 T$(1)=\"Dis/Fix\"",
            "140 T$(2)=\"Dis/Var\"",
            "150 T$(3)=\"Int/Fix\"",
            "160 T$(4)=\"Int/Var\"",
            "170 T$(5)=\"Program\"",
            "180 X$=\"          \"",
            "",
            "1000 OPEN #1:\"DSK1.\", INPUT, RELATIVE, INTERNAL",
            "1010 INPUT #1: A$, I, J, K",
            "1020 A$ = A$ & SEG$( X$, 1, 10 - LEN( A$ ))",
            "1030 B$ = STR$( K )",
            "1040 B$ = SEG$( X$, 1, 4 - LEN( B$ )) & B$",
            "1050 C$ = STR$( J - K )",
            "1060 C$ = SEG$( X$, 1, 4 - LEN( C$ )) & C$",
            "1070 PRINT A$;\"   F:\";B$;\"   U:\";C$",
            "1080 PRINT \"Filename   Size Type       P\"",
            "1090 PRINT \"---------- ---- ---------- -\"",
            "",
            "2000 FOR L = 1 TO 127",
            "2010 INPUT #1: A$, I, J, K",
            "2020 IF LEN( A$ ) = 0 THEN 3000",
            "2030 A$ = A$ & SEG$( X$, 1, 10 - LEN( A$ ))",
            "2040 B$ = STR$( J )",
            "2050 B$ = SEG$( X$, 1, 4 - LEN( B$ )) & B$",
            "2060 C$ = T$(I)",
            "2070 D$ = \"\"",
            "2080 IF ABS( I ) = 5 THEN 2100",
            "2090 D$ = STR$( K )",
            "2100 D$ = D$ & SEG$( X$, 1, 3 - LEN( D$ ))",
            "2110 C$ = C$ & D$",
            "2120 D$ = \" \"",
            "2130 IF I > 0 THEN 2150",
            "2140 D$ = \"P\"",
            "2150 PRINT A$;\" \";B$;\" \";C$;\" \";D$;",
            "2160 NEXT L",
            "",
            "3000 PRINT \"---------- ---- ---------- -\"",
            "3010 CLOSE #1"
        };
        private static readonly string[] basload2 =
        {
            "",
            "4000 A$ = \"<tiobjfile>\"",
            "4010 B$ = \"<tiimgfile>\"",
            "4020 PRINT",
            "4030 PRINT \"Loading \" & A$",
            "4040 PRINT \"Please wait ...\"",
            "4050 CALL LOAD( \"DSK1.\" & A$ )",
            "4060 CALL LINK( B$ )"
        };

        //  ********************************************************************
        // **********************************************************************
        // ***                                                                ***
        // ***   constructor / destructor                                     ***
        // ***                                                                ***
        // **********************************************************************
        //  ********************************************************************

        public Form1()
        {
            InitializeComponent();
        }

        //  ********************************************************************
        // **********************************************************************
        // ***                                                                ***
        // ***   private helper                                               ***
        // ***                                                                ***
        // **********************************************************************
        //  ********************************************************************

        // replace <libpath> <lstfile> <srcfile> <prjname> <tisrcfile> 
        // <tiobjfile> <tilstfile> <tiimgfile> <prjdisk> <objfile> 
        // <imgfile> <runfile> <tirunfile> <tiprjname>
        private string replacePatterns(string raw)
        {
            string Result;
            int n;
            string[] keyvalues = {};
            string s;
            int f;

            // Console.WriteLine("replacePatterns: '" + raw + "'");

            Result = raw;

            string src9 = txt_Source.Text.ToUpper(); if (src9.Length > 9) { src9 = src9.Substring(0, 9); }
            string prj10 = txt_Project.Text; if (prj10.Length > 10 ) { prj10 = prj10.Substring(0, 10); }
            string ees1 = txt_ExtEmu_Source.Text; if (ees1.Length > 1) {ees1 = ees1.Substring(0, 1); }
            string eeo1 = txt_ExtEmu_Object.Text; if (eeo1.Length > 1) { eeo1 = eeo1.Substring(0, 1); }
            string eel1 = txt_ExtEmu_List.Text; if (eel1.Length > 1) { eel1 = eel1.Substring(0, 1); }
            string eei1 = txt_ExtEmu_Image.Text; if (eei1.Length > 1) { eei1 = eei1.Substring(0, 1); }

            n = keywords.Length;
            Array.Resize(ref keyvalues, n);
            for (int i = 0; i < n; i++)
            {
                if (i == 0) //libpath
                {
                    s = txt_Xdt_Base.Text + txt_Xdt_Library.Text;
                }
                else if (i == 1) //lstfile
                {
                    s = txt_Source.Text + "." + txt_ExtWin_List.Text;
                }
                else if (i == 2) //srcfile
                {
                    s = txt_Source.Text + "." + txt_ExtWin_Source.Text;
                }
                else if (i == 3) //prjname
                {
                    s = prj10;
                }
                else if (i == 4) //tisrcfile
                {
                    s = src9 + ees1;
                }
                else if (i == 5) //tiobjfile
                {
                    s = src9 + eeo1;
                }
                else if (i == 6) //tilstfile
                {
                    s = src9 + eel1;
                }
                else if (i == 7) //tiimgfile
                {
                    s = src9 + eei1;
                }
                else if (i == 8) //prjdisk
                {
                    s = prj10 + "." + txt_ExtWin_Disk.Text;
                }
                else if (i == 9) //objfile
                {
                    s = txt_Source.Text + "." + txt_ExtWin_Object.Text;
                }
                else if (i == 10) //imgfile
                {
                    s = txt_Source.Text + "." + txt_ExtWin_Image.Text;
                }
                else if (i == 11) //runfile
                {
                    s = "load.prg";
                }
                else if (i == 12) //tirunfile
                {
                    s = "LOAD";
                }
                else if (i == 13) //tiprjname
                {
                    s = prj10.ToUpper();
                }
                else if (i == 14) //ticart
                {
                    if (opt_Emu_EditAss.Checked)
                    {
                        s = "EditAss";
                    }
                    else if (opt_Emu_MiniMem.Checked)
                    {
                        s = "MiniMem";
                    }
                    else if (opt_Emu_ExBasic.Checked)
                    {
                        s = "ExBasic";
                    }
                    else
                    {
                        s = "";
                    }
                }
                else if (i == 15) //basfile
                {
                    s = "load.b99";
                }
                else
                {
                    // ...
                    s = "";
                }
                keyvalues[i] = s;
            }

            for (int i = 0; i < n; i++)
            {
                f = Result.IndexOf(keywords[i]);
                if (f >= 0)
                {
                    Result = Result.Substring(0, f) + keyvalues[i] + Result.Substring(f + keywords[i].Length);
                }
            }

            // Console.WriteLine("replacePatterns return: '" + Result + "'");

            return Result;

        }

        private static readonly string cmd = "C:\\WINDOWS\\system32\\cmd.exe";
        private static readonly string cmd1 = "cmd";
        private static readonly string pyt = "C:\\Python27\\python.exe";
        private static readonly string pyt1 = "python";
        private bool runExternal( string bin, string opt, string wrk, bool end )
        {
            bool Result;
            int runmod = 0;
            int n;
            string ext;
            string stdout="";
            string stderr="";

            Result = false;

            Console.WriteLine("runExternal: bin [" + bin + "], opt [" + opt + "], wrk [" + wrk + "]");

            n = bin.Length-1;
            while ((n>=0) & (bin.Substring(n,1)!="."))
            {
                n = n - 1;
            }
            ext = bin.Substring(n+1);
            if (ext=="exe")
            {
                runmod = 30;
            }
            else if (ext=="py")
            {
                runmod = 21;
            }
            Console.WriteLine("  trying runmod: " + runmod.ToString());

            ProcessStartInfo psi = new ProcessStartInfo();
            if (runmod == 10) // ok
            {
                psi.WorkingDirectory = wrk;
                psi.FileName = cmd;
                psi.Arguments = "/k " + pyt + " " + bin + " " + opt;
                // c:\win\cmd.exe   -   /k c:\prg\python.exe e:\pyt\script.py opt1 opt2 ...
            }
            else if (runmod == 11) // ok, but: "System.InvalidOperationException" in System.dll
            {
                psi.WorkingDirectory = wrk;
                psi.FileName = cmd1;
                psi.Arguments = "/k " + pyt1 + " " + bin + " " + opt;
                // cmd   -   /k python e:\pyt\script.py opt1 opt2 ...
            }
            else if (runmod == 20) // ok, but: "System.InvalidOperationException" in System.dll
            {
                psi.WorkingDirectory = wrk;
                psi.FileName = pyt;
                psi.Arguments = bin + " " + opt;
                // c:\prg\python.exe   -   e:\pyt\script.py opt1 opt2 ...
            }
            else if (runmod == 21) // ok, but: "System.InvalidOperationException" in System.dll
            {
                psi.WorkingDirectory = wrk;
                psi.FileName = pyt1;
                psi.Arguments = bin + " " + opt;
                // python   -   e:\pyt\script.py opt1 opt2 ...
            }
            else if (runmod == 30) // error: "System.ComponentModel.Win32Exception" in System.dll
            {
                psi.WorkingDirectory = wrk;
                psi.FileName = bin;
                psi.Arguments = opt;
                // e:\pyt\script.py   -   opt1 opt2 ...
            }
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            // psi.RedirectStandardInput = false;
            psi.WindowStyle = ProcessWindowStyle.Normal;
            try
            {
                Console.WriteLine("  psi Filename [" + psi.FileName + "], Arguments [" + psi.Arguments + "]");
                txt_Command_Stack.Text = txt_Command_Stack.Text + psi.FileName + " " + psi.Arguments + "\r\n";
                using (Process run = Process.Start(psi))
                {
                    if (end)
                    {
                        stdout = run.StandardOutput.ReadToEnd();
                        stderr = run.StandardError.ReadToEnd();
                        run.WaitForExit();
                    }
                }
                Console.WriteLine("StdOut: "+stdout);
                if (stdout != "")
                {
                    txt_Standard_Output.Text = txt_Standard_Output.Text + stdout + "\r\n";
                }
                Console.WriteLine("StdErr: "+stderr);
                if (stderr != "")
                {
                    txt_Error_Output.Text = txt_Error_Output.Text + stderr + "\r\n";
                }
            }
            catch
            {
                // ...
            }

            return Result;

        }

        private List<string> getProjectList()
        {
            List<string> Result;
            string s;
            string[] d;
            Result = new List<string>();
            s = txt_Xdt_Base.Text + txt_Xdt_Projects.Text;
            if (s.Substring(s.Length) != "\\")
            {
                s = s + "\\";
            }
            d = Directory.GetDirectories(s, "*", SearchOption.TopDirectoryOnly);
            for (int i=0; i<d.Length; i++)
            {
                Result.Add(d[i].Substring(s.Length));
            }
            return Result;
        }

        private List<string> getSourceList()
        {
            List<string> Result;
            string s;
            string[] f;
            Result = new List<string>();
            s = txt_Xdt_Base.Text + txt_Xdt_Projects.Text + txt_Project.Text;
            if ( s.Substring (s.Length) != "\\")
            {
                s = s + "\\";
            }
            f = Directory.GetFiles(s, "*." + txt_ExtWin_Source.Text, SearchOption.TopDirectoryOnly);
            for (int i = 0; i < f.Length; i++)
            {
                Result.Add(f[i].Substring(s.Length, f[i].Length - s.Length - txt_ExtWin_Source.Text.Length - 1));
            }
            return Result;
        }

        private bool refreshProjectList()
        {
            bool Result;
            List<string> l;
            string s;
            Result = false;
            s = txt_Project.Text;
            lst_Projects.DataSource = null;
            l = getProjectList();
            lst_Projects.DataSource = l;
            for (int n=0; n<lst_Projects.Items.Count; n++)
            {
                if ( lst_Projects.Items[n].ToString() == s )
                {
                    lst_Projects.SelectedIndex = n;
                }
            }
            return Result;
        }

        private bool refreshSourceList()
        {
            bool Result;
            List<string> l;
            string s;
            Result = false;
            s = txt_Source.Text;
            lst_Sourcefiles.DataSource = null;
            l = getSourceList();
            lst_Sourcefiles.DataSource = l;
            for (int n = 0; n < lst_Sourcefiles.Items.Count; n++)
            {
                if (lst_Sourcefiles.Items[n].ToString() == s)
                {
                    lst_Sourcefiles.SelectedIndex = n;
                }
            }
            return Result;
        }

        // start external editor with source file according to lst_sourcefiles
        private bool startEditor()
        {
            bool Result;
            string wrk;
            string bin;
            string opt;
            Result = false;
            bin = replacePatterns(txt_Editor_Binary.Text);
            opt = replacePatterns(txt_Editor_Options.Text);
            wrk = replacePatterns(txt_Xdt_Base.Text + txt_Xdt_Projects.Text + txt_Project.Text);
            Result = runExternal(bin, opt, wrk,false);
            return Result;
        }

        // start assembler with source file according to lst_sourcefiles
        // loop through all sources if chk_assemble_all is set
        // generate object file if chk_assemble_object is set
        // generate image file if chk_assemble_image is set
        // generate mess rpk if chk_assemble_mess is set
        private bool startAssembler()
        {
            bool Result;
            string wrk;
            string bin;
            string opt;
            List<string> src;
            string sav;
            Result = false;
            src = new List<string>();
            txt_Standard_Output.Text = "";
            txt_Error_Output.Text = "";
            if (chk_Assembler_all.Checked)
            {
                foreach (string s in lst_Sourcefiles.Items)
                {
                    src.Add(s);
                }
            }
            else
            {
                src.Add(txt_Source.Text);
            }
            wrk = replacePatterns(txt_Xdt_Base.Text + txt_Xdt_Projects.Text + txt_Project.Text);
            bin = replacePatterns(txt_Xdt_Base.Text + txt_Xdt_Assembler.Text);
            sav = txt_Source.Text;
            foreach (string s in src)
            {
                txt_Source.Text = s;
                if (chk_Assembler_Object.Checked)
                {
                    opt = replacePatterns(txt_Xdt_AsOptions_Object.Text);
                    Result = runExternal(bin, opt, wrk, true);
                }
                if (chk_Assembler_Image.Checked)
                {
                    opt = replacePatterns(txt_Xdt_AsOptions_Image.Text);
                    Result = runExternal(bin, opt, wrk, true);
                }
                if (chk_Assembler_Rpk.Checked)
                {
                    opt = replacePatterns(txt_Xdt_AsOptions_Rpk.Text);
                    Result = runExternal(bin, opt, wrk, true);
                }
            }
            txt_Source.Text = sav;
            if (txt_Standard_Output.Text != "")
            {
                MessageBox.Show("See results...");
                tabControl1.SelectedTab = tab_StdOut;
            }
            if (txt_Error_Output.Text != "")
            {
                MessageBox.Show("There were errors!");
                tabControl1.SelectedTab = tab_StdErr;
            }
            return Result;
        }

        // create disk image with the disk manager tool
        // copy source file to disk if chk_copy_source is set
        // copy list file to disk if chk_copy_list is set
        // copy object file to disk if chk_copy_object is set
        // copy image file to disk if chk_copy_image is set
        // copy all above to disk if chk_copy_all is set
        // create / copy catalog tool to disk if chk_copy_catalog is set
        // create / copy autostart tool if chk_copy_autostart is set
        private bool startDiskManager()
        {
            bool Result;
            string wrk;
            string bin;
            string opt;
            List<string> src;
            string sav;
            Result = false;
            src = new List<string>();
            txt_Standard_Output.Text = "";
            txt_Error_Output.Text = "";
            if (chk_Assembler_all.Checked)
            {
                foreach (string s in lst_Sourcefiles.Items)
                {
                    src.Add(s);
                }
            }
            else
            {
                src.Add(txt_Source.Text);
            }
            wrk = replacePatterns(txt_Xdt_Base.Text + txt_Xdt_Projects.Text + txt_Project.Text);
            bin = replacePatterns(txt_Xdt_Base.Text + txt_Xdt_DiskManager.Text);
            opt = replacePatterns(txt_Xdt_DmCreate_Diskfile.Text);
            Result = runExternal(bin, opt, wrk, true);
            sav = txt_Source.Text;
            foreach (string s in src)
            {
                txt_Source.Text = s;
                if (chk_Copy_Source.Checked)
                {
                    opt = replacePatterns(txt_Xdt_DmCopy_Source.Text);
                    Result = runExternal(bin, opt, wrk, true);
                }
                if (chk_Copy_List.Checked)
                {
                    opt = replacePatterns(txt_Xdt_DmCopy_List.Text);
                    Result = runExternal(bin, opt, wrk, true);
                }
                if (chk_Copy_Object.Checked)
                {
                    opt = replacePatterns(txt_Xdt_DmCopy_Object.Text);
                    Result = runExternal(bin, opt, wrk, true);
                }
                if (chk_Copy_Image.Checked)
                {
                    opt = replacePatterns(txt_Xdt_DmCopy_Image.Text);
                    Result = runExternal(bin, opt, wrk, true);
                }
            }
            txt_Source.Text = sav;
            if (chk_Copy_Catalog.Checked)
            {
                sav = txt_Xdt_Base.Text + txt_Xdt_Projects.Text + txt_Project.Text + "\\load.b99";
                using (StreamWriter bas = new StreamWriter(sav))
                {
                    for (int n = 0; n < basload1.Length; n++)
                    {
                        bas.WriteLine(basload1[n]);
                    }
                    if (chk_Copy_AutoStart.Checked)
                    {
                        for (int n = 0; n < basload2.Length; n++)
                        {
                            bas.WriteLine(replacePatterns(basload2[n]));
                        }
                    }
                }
                bin = replacePatterns(txt_Xdt_Base.Text + txt_Xdt_BasConv.Text);
                opt = replacePatterns(txt_Xdt_BasConv_Load.Text);
                Result = runExternal(bin, opt, wrk, true);
                bin = replacePatterns(txt_Xdt_Base.Text + txt_Xdt_DiskManager.Text);
                opt = replacePatterns(txt_Xdt_DmCopy_Run.Text);
                Result = runExternal(bin, opt, wrk, true);
            }
            opt = replacePatterns(txt_Xdt_DmShow_Directory.Text);
            Result = runExternal(bin, opt, wrk, true);
            if (txt_Standard_Output.Text != "")
            {
                // MessageBox.Show("See results...");
                tabControl1.SelectedTab = tab_StdOut;
            }
            if (txt_Error_Output.Text != "")
            {
                MessageBox.Show("There were errors!");
                tabControl1.SelectedTab = tab_StdErr;
            }
            return Result;
        }

        // start the emulator
        // use cartridge editass, minimem or exbasic acc. to radiogroup grp_emu_cart
        // using püt_emu_editass, opt_emu_minimem and opt_emu_exbasic
        private bool startEmulator()
        {
            bool Result;
            string bin;
            string opt;
            string wrk;
            Result = false;

            bin = "E:\\TI99\\mame64.exe";
            opt = replacePatterns("ti99_4ev -gromport single -cart <ticart> -ioport peb -ioport:peb:slot2 evpc -ioport:peb:slot8 hfdc -ioport:peb:slot8:hfdc:f1 525dd -ioport:peb:slot8:hfdc:f2 525dd -ioport:peb:slot8:hfdc:h1 generic -flop1 disk/<prjdisk> -flop2 disk/flopdsk2.dsk -hard1 hard/harddsk1.chd");
            wrk = "E:\\TI99\\";
            runExternal(bin, opt, wrk, true);

            return Result;
        }

        private bool saveSettingsXdt()
        {
            bool Result;
            Result = false;
            try
            {
                Properties.Settings.Default["Editor_Binary"] = txt_Editor_Binary.Text;
                Properties.Settings.Default["Editor_Options"] = txt_Editor_Options.Text;
                Properties.Settings.Default["Xdt_Base"] = txt_Xdt_Base.Text;
                Properties.Settings.Default["Xdt_Projects"] = txt_Xdt_Projects.Text;
                Properties.Settings.Default["Xdt_Library"] = txt_Xdt_Library.Text;
                Properties.Settings.Default["Xdt_Assembler"] = txt_Xdt_Assembler.Text;
                Properties.Settings.Default["Xdt_AsOptions_Object"] = txt_Xdt_AsOptions_Object.Text;
                Properties.Settings.Default["Xdt_AsOptions_Rpk"] = txt_Xdt_AsOptions_Rpk.Text;
                Properties.Settings.Default["Xdt_AsOptions_Image"] = txt_Xdt_AsOptions_Image.Text;
                Properties.Settings.Default["Xdt_BasConv"] = txt_Xdt_BasConv.Text;
                Properties.Settings.Default["Xdt_BasConv_Load"] = txt_Xdt_BasConv_Load.Text;
                Properties.Settings.Default["Xdt_DiskManager"] = txt_Xdt_DiskManager.Text;
                Properties.Settings.Default["Xdt_DmCreate_Diskfile"] = txt_Xdt_DmCreate_Diskfile.Text;
                Properties.Settings.Default["Xdt_DmCopy_Source"] = txt_Xdt_DmCopy_Source.Text;
                Properties.Settings.Default["Xdt_DmCopy_List"] = txt_Xdt_DmCopy_List.Text;
                Properties.Settings.Default["Xdt_DmCopy_Object"] = txt_Xdt_DmCopy_Object.Text;
                Properties.Settings.Default["Xdt_DmCopy_Image"] = txt_Xdt_DmCopy_Image.Text;
                Properties.Settings.Default["Xdt_DmCopy_Run"] = txt_Xdt_DmCopy_Run.Text;
                Properties.Settings.Default["Xdt_DmShow_Directory"] = txt_Xdt_DmShow_Directory.Text;
                Properties.Settings.Default["ExtWin_Source"] = txt_ExtWin_Source.Text;
                Properties.Settings.Default["ExtWin_Object"] = txt_ExtWin_Object.Text;
                Properties.Settings.Default["ExtWin_List"] = txt_ExtWin_List.Text;
                Properties.Settings.Default["ExtWin_Rpk"] = txt_ExtWin_Rpk.Text;
                Properties.Settings.Default["ExtWin_Image"] = txt_ExtWin_Image.Text;
                Properties.Settings.Default["ExtWin_BasT"] = txt_ExtWin_BasT.Text;
                Properties.Settings.Default["ExtWin_Basb"] = txt_ExtWin_BasB.Text;
                Properties.Settings.Default["ExtWin_Disk"] = txt_ExtWin_Disk.Text;
                Properties.Settings.Default["ExtEmu_Source"] = txt_ExtEmu_Source.Text;
                Properties.Settings.Default["ExtEmu_Object"] = txt_ExtEmu_Object.Text;
                Properties.Settings.Default["ExtEmu_List"] = txt_ExtEmu_List.Text;
                Properties.Settings.Default["ExtEmu_Image"] = txt_ExtEmu_Image.Text;
                Properties.Settings.Default["Emu_Load"] = txt_Emu_Load.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("settings saved");
                Result = true;
            }
            catch
            {
                MessageBox.Show("error saving settings !");
            }
            return Result;
        }

        private bool loadSettingsXdt()
        {
            bool Result;
            string s;
            Result = false;

            try
            {
                s = Properties.Settings.Default["Editor_Binary"].ToString(); if (s != "")
                    { txt_Editor_Binary.Text = s; }
                s = Properties.Settings.Default["Editor_Options"].ToString(); if (s != "")
                    { txt_Editor_Options.Text = s; }
                s = Properties.Settings.Default["Xdt_Base"].ToString(); if (s != "")
                    { txt_Xdt_Base.Text = s; }
                s = Properties.Settings.Default["Xdt_Projects"].ToString(); if (s != "")
                    { txt_Xdt_Projects.Text = s; }
                s = Properties.Settings.Default["Xdt_Library"].ToString(); if (s != "")
                    { txt_Xdt_Library.Text = s; }
                s = Properties.Settings.Default["Xdt_Assembler"].ToString(); if (s != "")
                    { txt_Xdt_Assembler.Text = s; }
                s = Properties.Settings.Default["Xdt_AsOptions_Object"].ToString(); if (s != "")
                    { txt_Xdt_AsOptions_Object.Text = s; }
                s = Properties.Settings.Default["Xdt_AsOptions_Rpk"].ToString(); if (s != "")
                    { txt_Xdt_AsOptions_Rpk.Text = s; }
                s = Properties.Settings.Default["Xdt_AsOptions_Image"].ToString(); if (s != "")
                    { txt_Xdt_AsOptions_Image.Text = s; }
                s = Properties.Settings.Default["Xdt_BasConv"].ToString(); if (s != "")
                    { txt_Xdt_BasConv.Text = s; }
                s = Properties.Settings.Default["Xdt_BasConv_Load"].ToString(); if (s != "")
                    { txt_Xdt_BasConv_Load.Text = s; }
                s = Properties.Settings.Default["Xdt_DiskManager"].ToString(); if (s != "")
                    { txt_Xdt_DiskManager.Text = s; }
                s = Properties.Settings.Default["Xdt_DmCreate_Diskfile"].ToString(); if (s != "")
                    { txt_Xdt_DmCreate_Diskfile.Text = s; }
                s = Properties.Settings.Default["Xdt_DmCopy_Source"].ToString(); if (s != "")
                    { txt_Xdt_DmCopy_Source.Text = s; }
                s = Properties.Settings.Default["Xdt_DmCopy_List"].ToString(); if (s != "")
                    { txt_Xdt_DmCopy_List.Text = s; }
                s = Properties.Settings.Default["Xdt_DmCopy_Object"].ToString(); if (s != "")
                    { txt_Xdt_DmCopy_Object.Text = s; }
                s = Properties.Settings.Default["Xdt_DmCopy_Image"].ToString(); if (s != "")
                    { txt_Xdt_DmCopy_Image.Text = s; }
                s = Properties.Settings.Default["Xdt_DmCopy_Run"].ToString(); if (s != "")
                    { txt_Xdt_DmCopy_Run.Text = s; }
                s = Properties.Settings.Default["Xdt_DmShow_Directory"].ToString(); if (s != "")
                    { txt_Xdt_DmShow_Directory.Text = s; }
                s = Properties.Settings.Default["ExtWin_Source"].ToString(); if (s != "")
                    { txt_ExtWin_Source.Text = s; }
                s = Properties.Settings.Default["ExtWin_Object"].ToString(); if (s != "")
                    { txt_ExtWin_Object.Text = s; }
                s = Properties.Settings.Default["ExtWin_List"].ToString(); if (s != "")
                    { txt_ExtWin_List.Text = s; }
                s = Properties.Settings.Default["ExtWin_Rpk"].ToString(); if (s != "")
                    { txt_ExtWin_Rpk.Text = s; }
                s = Properties.Settings.Default["ExtWin_Image"].ToString(); if (s != "")
                    { txt_ExtWin_Image.Text = s; }
                s = Properties.Settings.Default["ExtWin_BasT"].ToString(); if (s != "")
                    { txt_ExtWin_BasT.Text = s; }
                s = Properties.Settings.Default["ExtWin_Basb"].ToString(); if (s != "")
                    { txt_ExtWin_BasB.Text = s; }
                s = Properties.Settings.Default["ExtWin_Disk"].ToString(); if (s != "")
                    { txt_ExtWin_Disk.Text = s; }
                s = Properties.Settings.Default["ExtEmu_Source"].ToString(); if (s != "")
                    { txt_ExtEmu_Source.Text = s; }
                s = Properties.Settings.Default["ExtEmu_Object"].ToString(); if (s != "")
                    { txt_ExtEmu_Object.Text = s; }
                s = Properties.Settings.Default["ExtEmu_List"].ToString(); if (s != "")
                    { txt_ExtEmu_List.Text = s; }
                s = Properties.Settings.Default["ExtEmu_Image"].ToString(); if (s != "")
                    { txt_ExtEmu_Image.Text = s; }
                s = Properties.Settings.Default["Emu_Load"].ToString(); if (s != "")
                    { txt_Emu_Load.Text = s; }
                Result = true;
            }
            catch
            {
                MessageBox.Show("error loading settings !");
            }

            return Result;
        }

        private bool saveSettingsMame()
        {
            bool Result;
            Result = false;

            return Result;
        }

        private bool loadSettingsMame()
        {
            bool Result;
            Result = false;

            return Result;
        }

        private bool saveSettingsIde()
        {
            bool Result;
            Result = false;

            return Result;
        }

        private bool loadSettingsIde()
        {
            bool Result;
            Result = false;

            return Result;
        }

        //  ********************************************************************
        // **********************************************************************
        // ***                                                                ***
        // ***   lifetime cycle events                                        ***
        // ***                                                                ***
        // **********************************************************************
        //  ********************************************************************

        // +--------------------------------------------------------------------+
        // | buttons                                                            |
        // +--------------------------------------------------------------------+

        private void btn_Editor_Click(object sender, EventArgs e)
        {

            startEditor();

        }

        private void btn_Assembler_Click(object sender, EventArgs e)
        {
            startAssembler();
        }

        private void btn_DiskManager_Click(object sender, EventArgs e)
        {
            startDiskManager();
        }

        private void btn_Emulator_Click(object sender, EventArgs e)
        {
            startEmulator();
        }

        private void btn_Ok_Xdt_Click(object sender, EventArgs e)
        {
            saveSettingsXdt();
        }

        private void btn_Ok_Mame_Click(object sender, EventArgs e)
        {
            saveSettingsMame();
        }

        // create new project sub folder
        private void btn_New_Project_Click(object sender, EventArgs e)
        {
            // ...
        }

        // create new source file
        // use an optional template file, create empty file otherwise
        private void btn_New_Source_Click(object sender, EventArgs e)
        {
            // ...
        }

        // +--------------------------------------------------------------------+
        // | listboxes                                                          |
        // +--------------------------------------------------------------------+

        // update lst_sourcefiles acc. to lst_projects subdir
        // set txt_project to selected project
        private void lst_Projects_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i;
            string s;
            i = lst_Projects.SelectedIndex;
            if (i >= 0)
            {
                s = lst_Projects.SelectedItem.ToString();
                txt_Project.Text = s;
            }
            refreshSourceList();
        }

        // set txt_source to selected source file
        // show details about selected file in project subdir
        private void lst_Sourcefiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i;
            string s;
            i = lst_Sourcefiles.SelectedIndex;
            if ( i >= 0)
            {
                s = lst_Sourcefiles.SelectedItem.ToString();
                txt_Source.Text = s;
            }
        }

        // start editor with actual source file
        private void lst_Sourcefiles_DoubleClick(object sender, EventArgs e)
        {
            int i;
            i = lst_Sourcefiles.SelectedIndex;
            if (i >= 0)
            {
                startEditor();
            }
        }

        // +--------------------------------------------------------------------+
        // | other                                                              |
        // +--------------------------------------------------------------------+

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            refreshProjectList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadSettingsXdt();
            loadSettingsMame();
            loadSettingsIde();
        }

    }

}
