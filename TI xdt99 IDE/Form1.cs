using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;

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
            "<basfile>", "<emu_machine>", "<emu_cart>", "<emu_gromport>", "<emu_joyport>",
            "<emu_cass1>", "<emu_cass2>", "<emu_disk1>", "<emu_disk2>", "<emu_disk3>",
            "<emu_disk4>", "<emu_hard1>", "<emu_hard2>", "<emu_hard3>", "<emu_rompath>",
            "<emu_ioport>", "<emu_peb2>", "<emu_peb3>", "<emu_peb4>", "<emu_peb5>",
            "<emu_peb6>", "<emu_peb7>", "<emu_peb8>", "<emu_fdc1>", "<emu_fdc2>",
            "<emu_fdc3>", "<emu_fdc4>", "<emu_hdc1>", "<emu_hdc2>", "<emu_hdc3>",
            "<emu_options>"
        };

        private static readonly string[] basload1 =
        {
            "100 CALL CLEAR",
            "110 CALL INIT"
        };
        private static readonly string[] basload2 =
        {
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
            "2100 D$ = SEG$( X$, 1, 3 - LEN( D$ )) & D$",
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
        private static readonly string[] basload3 =
        {
            "",
            "4000 A$ = \"<tiobjfile>\"",
            "4010 B$ = \"<tiimgfile>\"",
            "4020 PRINT",
            "4030 PRINT \"Loading \" & A$",
            "4040 PRINT \"Please wait ...\"",
            "4050 CALL LOAD( \"DSK1.\" & A$ )",
            "4060 PRINT \"Starting \" & B$",
            "4070 CALL LINK( B$ )"
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
            string fdc;
            string hdc;

            // Console.WriteLine("replacePatterns: '" + raw + "'");

            Result = raw;

            string src9 = txt_Source.Text.ToUpper(); if (src9.Length > 9) { src9 = src9.Substring(0, 9); }
            string prj10 = txt_Project.Text; if (prj10.Length > 10 ) { prj10 = prj10.Substring(0, 10); }
            string ees1 = txt_ExtEmu_Source.Text; if (ees1.Length > 1) {ees1 = ees1.Substring(0, 1); }
            string eeo1 = txt_ExtEmu_Object.Text; if (eeo1.Length > 1) { eeo1 = eeo1.Substring(0, 1); }
            string eel1 = txt_ExtEmu_List.Text; if (eel1.Length > 1) { eel1 = eel1.Substring(0, 1); }
            string eei1 = txt_ExtEmu_Image.Text; if (eei1.Length > 1) { eei1 = eei1.Substring(0, 1); }

            fdc = "";
            if ((cmb_Emu_Peb2.Text == "tifdc") | (cmb_Emu_Peb2.Text == "hfdc")) { fdc = "slot2:" + cmb_Emu_Peb2.Text; }
            if ((cmb_Emu_Peb3.Text == "tifdc") | (cmb_Emu_Peb3.Text == "hfdc")) { fdc = "slot3:" + cmb_Emu_Peb3.Text; }
            if ((cmb_Emu_Peb4.Text == "tifdc") | (cmb_Emu_Peb4.Text == "hfdc")) { fdc = "slot4:" + cmb_Emu_Peb4.Text; }
            if ((cmb_Emu_Peb5.Text == "tifdc") | (cmb_Emu_Peb5.Text == "hfdc")) { fdc = "slot5:" + cmb_Emu_Peb5.Text; }
            if ((cmb_Emu_Peb6.Text == "tifdc") | (cmb_Emu_Peb6.Text == "hfdc")) { fdc = "slot6:" + cmb_Emu_Peb6.Text; }
            if ((cmb_Emu_Peb7.Text == "tifdc") | (cmb_Emu_Peb7.Text == "hfdc")) { fdc = "slot7:" + cmb_Emu_Peb7.Text; }
            if ((cmb_Emu_Peb8.Text == "tifdc") | (cmb_Emu_Peb8.Text == "hfdc")) { fdc = "slot8:" + cmb_Emu_Peb8.Text; }
            if (cmb_Emu_Machine.Text != "geneve")
            {
                fdc = " -ioport:peb:" + fdc;
            }
            else
            {
                fdc = " -peb:" + fdc;
            }
            hdc = "";
            if ((cmb_Emu_Peb2.Text == "hfdc") | (cmb_Emu_Peb2.Text == "ide")) { hdc = "slot2:" + cmb_Emu_Peb2.Text; }
            if ((cmb_Emu_Peb3.Text == "hfdc") | (cmb_Emu_Peb3.Text == "ide")) { hdc = "slot3:" + cmb_Emu_Peb3.Text; }
            if ((cmb_Emu_Peb4.Text == "hfdc") | (cmb_Emu_Peb4.Text == "ide")) { hdc = "slot4:" + cmb_Emu_Peb4.Text; }
            if ((cmb_Emu_Peb5.Text == "hfdc") | (cmb_Emu_Peb5.Text == "ide")) { hdc = "slot5:" + cmb_Emu_Peb5.Text; }
            if ((cmb_Emu_Peb6.Text == "hfdc") | (cmb_Emu_Peb6.Text == "ide")) { hdc = "slot6:" + cmb_Emu_Peb6.Text; }
            if ((cmb_Emu_Peb7.Text == "hfdc") | (cmb_Emu_Peb7.Text == "ide")) { hdc = "slot7:" + cmb_Emu_Peb7.Text; }
            if ((cmb_Emu_Peb8.Text == "hfdc") | (cmb_Emu_Peb8.Text == "ide")) { hdc = "slot8:" + cmb_Emu_Peb8.Text; }
            if (cmb_Emu_Machine.Text != "geneve")
            {
                hdc = " -ioport:peb:" + hdc;
            }
            else
            {
                hdc = " -peb:" + hdc;
            }

            n = keywords.Length;
            Array.Resize(ref keyvalues, n);
            for (int i = 0; i < n; i++)
            {
                s = "";
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
                else if (i == 16) //emu_machine
                {
                    if (cmb_Emu_Machine.Text != "-----") { s = " " + cmb_Emu_Machine.Text; }
                }
                else if (i == 17) //emu_cart
                {
                    if (cmb_Emu_Machine.Text != "geneve")
                    {
                        if (cmb_Emu_Cartridge.Text != "-----") { s = " -cart " + cmb_Emu_Cartridge.Text; }
                        // if (cmb_Emu_Cartridge.Text != "-----") { s = " -cart " + cmb_Emu_Cartridge.Text; } else { s = " -cart \"\""; }
                    }
                }
                else if (i == 18) //emu_gromport
                {
                    if (cmb_Emu_Machine.Text != "geneve")
                    {
                        if (cmb_Emu_GromPort.Text != "-----") { s = " -gromport " + cmb_Emu_GromPort.Text; }
                        // if (cmb_Emu_GromPort.Text != "-----") { s = " -gromport " + cmb_Emu_GromPort.Text; } else { s = " -gromport \"\""; }
                    }
                }
                else if (i == 19) //emu_joyport
                {
                    s = "";
                    if (cmb_Emu_Machine.Text != "geneve")
                    {
                        if (cmb_Emu_JoyPort.Text != "-----") { s = " -joyport " + cmb_Emu_JoyPort.Text; }
                        // if (cmb_Emu_JoyPort.Text != "-----") { s = " -joyport " + cmb_Emu_JoyPort.Text; } else { s = " -joyport \"\""; }
                    }
                }
                else if (i == 20) //emu_cass1
                {
                    if (txt_Emu_CS1.Text != "") { s = " -cass1 " + txt_Emu_CS1.Text; }
                    // if (txt_Emu_CS1.Text != "") { s = " -cass1 " + txt_Emu_CS1.Text; } else { s = " -cass1 \"\""; }
                }
                else if (i == 21) //emu_cass2
                {
                    if (txt_Emu_CS2.Text != "") { s = " -cass2 " + txt_Emu_CS2.Text; }
                }
                else if (i == 22) //emu_disk1
                {
                    if (txt_Emu_DSK1.Text != "") { s = " -flop1 " + txt_Emu_DiskPath.Text + txt_Emu_DSK1.Text; }
                }
                else if (i == 23) //emu_disk2
                {
                    if (txt_Emu_DSK2.Text != "") { s = " -flop2 " + txt_Emu_DiskPath.Text + txt_Emu_DSK2.Text; }
                }
                else if (i == 24) //emu_disk3
                {
                    if (txt_Emu_DSK3.Text != "") { s = " -flop3 " + txt_Emu_DiskPath.Text + txt_Emu_DSK3.Text; }
                }
                else if (i == 25) //emu_disk4
                {
                    if (txt_Emu_DSK4.Text != "") { s = " -flop4 " + txt_Emu_DiskPath.Text + txt_Emu_DSK4.Text; }
                }
                else if (i == 26) //emu_hard1
                {
                    if (txt_Emu_WDS1.Text != "") { s = " -hard1 " + txt_Emu_HardPath.Text + txt_Emu_WDS1.Text; }
                }
                else if (i == 27) //emu_hard2
                {
                    if (txt_Emu_WDS2.Text != "") { s = " -hard2 " + txt_Emu_HardPath.Text + txt_Emu_WDS2.Text; }
                }
                else if (i == 28) //emu_hard2
                {
                    if (txt_Emu_WDS3.Text != "") { s = " -hard3 " + txt_Emu_HardPath.Text + txt_Emu_WDS3.Text; }
                }
                else if (i == 29) //emu_rompath
                {
                    s = txt_Emu_RomPath.Text;
                    if (txt_Emu_CartPath.Text != "" )
                    {
                        if ( s != "" ) { s = s + ";"; }
                        s = s + txt_Emu_CartPath.Text;
                    }
                    if ( s != "" ) { s = " -rp " + s; }
                }
                else if (i == 30) //emu_ioport
                {
                    if (cmb_Emu_Machine.Text != "geneve")
                    {
                        if (cmb_Emu_IoPort.Text != "-----") { s = " -ioport " + cmb_Emu_IoPort.Text; }
                    }
                }
                else if (i == 31) //emu_peb2
                {
                    if (cmb_Emu_Peb2.Text != "-----")
                    {
                        if (cmb_Emu_Machine.Text != "geneve")
                        {
                            s = " -ioport:peb:" + s;
                        }
                        else
                        {
                            s = " -peb:" + s;
                        }
                        s = s + "slot2 " + cmb_Emu_Peb2.Text;
                    }
                }
                else if (i == 32) //emu_peb3
                {
                    if (cmb_Emu_Peb3.Text != "-----")
                    {
                        if (cmb_Emu_Machine.Text != "geneve")
                        {
                            s = " -ioport:peb:" + s;
                        }
                        else
                        {
                            s = " -peb:" + s;
                        }
                        s = s + "slot3 " + cmb_Emu_Peb3.Text;
                    }
                }
                else if (i == 33) //emu_peb4
                {
                    if (cmb_Emu_Peb4.Text != "-----")
                    {
                        if (cmb_Emu_Machine.Text != "geneve")
                        {
                            s = " -ioport:peb:" + s;
                        }
                        else
                        {
                            s = " -peb:" + s;
                        }
                        s = s + "slot4 " + cmb_Emu_Peb4.Text;
                    }
                }
                else if (i == 34) //emu_peb5
                {
                    if (cmb_Emu_Peb5.Text != "-----")
                    {
                        if (cmb_Emu_Machine.Text != "geneve")
                        {
                            s = " -ioport:peb:" + s;
                        }
                        else
                        {
                            s = " -peb:" + s;
                        }
                        s = s + "slot5 " + cmb_Emu_Peb5.Text;
                    }
                }
                else if (i == 35) //emu_peb6
                {
                    if (cmb_Emu_Peb6.Text != "-----")
                    {
                        if (cmb_Emu_Machine.Text != "geneve")
                        {
                            s = " -ioport:peb:" + s;
                        }
                        else
                        {
                            s = " -peb:" + s;
                        }
                        s = s + "slot6 " + cmb_Emu_Peb6.Text;
                    }
                }
                else if (i == 36) //emu_peb7
                {
                    if (cmb_Emu_Peb7.Text != "-----")
                    {
                        if (cmb_Emu_Machine.Text != "geneve")
                        {
                            s = " -ioport:peb:" + s;
                        }
                        else
                        {
                            s = " -peb:" + s;
                        }
                        s = s + "slot7 " + cmb_Emu_Peb7.Text;
                    }
                }
                else if (i == 37) //emu_peb8
                {
                    if (cmb_Emu_Peb8.Text != "-----")
                    {
                        if (cmb_Emu_Machine.Text != "geneve")
                        {
                            s = " -ioport:peb:" + s;
                        }
                        else
                        {
                            s = " -peb:" + s;
                        }
                        s = s + "slot8 " + cmb_Emu_Peb8.Text;
                    }
                }
                else if (i == 38) //emu_fdc1
                {
                    if (cmb_Emu_Fdd1.Text != "-----") { s = fdc + ":f1 " + cmb_Emu_Fdd1.Text; }
                }
                else if (i == 39) //emu_fdc2
                {
                    if (cmb_Emu_Fdd2.Text != "-----") { s = fdc + ":f2 " + cmb_Emu_Fdd2.Text; }
                }
                else if (i == 40) //emu_fdc3
                {
                    if (cmb_Emu_Fdd3.Text != "-----") { s = fdc + ":f3 " + cmb_Emu_Fdd3.Text; }
                }
                else if (i == 41) //emu_fdc4
                {
                    if (cmb_Emu_Fdd4.Text != "-----") { s = fdc + ":f4 " + cmb_Emu_Fdd4.Text; }
                }
                else if (i == 42) //emu_hdc1
                {
                    if (cmb_Emu_Hdd1.Text != "-----") { s = hdc + ":h1 " + cmb_Emu_Hdd1.Text; }
                }
                else if (i == 43) //emu_hdc2
                {
                    if (cmb_Emu_Hdd2.Text != "-----") { s = hdc + ":h2 " + cmb_Emu_Hdd2.Text; }
                }
                else if (i == 44) //emu_hdc3
                {
                    if (cmb_Emu_Hdd3.Text != "-----") { s = hdc + ":h3 " + cmb_Emu_Hdd3.Text; }
                }
                else if (i == 45) //emu_options
                {
                    if (txt_Emu_AddOptions.Text != "") { s = " " + txt_Emu_AddOptions.Text; }
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

            saveSettingsAll();

            n = bin.Length-1;
            while ((n>=0) & (bin.Substring(n,1)!="."))
            {
                n = n - 1;
            }
            ext = bin.Substring(n+1);
            if (ext == "bat")
            {
                runmod = 2;
            }
            else if (ext=="py")
            {
                runmod = 21;
            }
            else if (ext == "exe")
            {
                runmod = 30;
            }
            Console.WriteLine("  trying runmod: " + runmod.ToString());

            ProcessStartInfo psi = new ProcessStartInfo();
            if (runmod == 1)
            {
                psi.WorkingDirectory = wrk;
                psi.FileName = cmd;
                psi.Arguments = "/k " + bin + " " + opt;
                // c:\win\cmd.exe   -   /k c:\prg\batch.bat e:\pyt\script.py opt1 opt2 ...
            }
            else if (runmod == 2)
            {
                psi.WorkingDirectory = wrk;
                psi.FileName = cmd1;
                psi.Arguments = "/c " + bin + " " + opt;
                // cmd   -   /k c:\prg\batch.bat opt1 opt2 ...
            }
            else if (runmod == 10)
            {
                psi.WorkingDirectory = wrk;
                psi.FileName = cmd;
                psi.Arguments = "/k " + pyt + " " + bin + " " + opt;
                // c:\win\cmd.exe   -   /k c:\prg\python.exe e:\pyt\script.py opt1 opt2 ...
            }
            else if (runmod == 11)
            {
                psi.WorkingDirectory = wrk;
                psi.FileName = cmd1;
                psi.Arguments = "/k " + pyt1 + " " + bin + " " + opt;
                // cmd   -   /k python e:\pyt\script.py opt1 opt2 ...
            }
            else if (runmod == 20)
            {
                psi.WorkingDirectory = wrk;
                psi.FileName = pyt;
                psi.Arguments = bin + " " + opt;
                // c:\prg\python.exe   -   e:\pyt\script.py opt1 opt2 ...
            }
            else if (runmod == 21)
            {
                psi.WorkingDirectory = wrk;
                psi.FileName = pyt1;
                psi.Arguments = bin + " " + opt;
                // python   -   e:\pyt\script.py opt1 opt2 ...
            }
            else if (runmod == 30)
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
                Console.WriteLine("  psi workingdir [" + psi.WorkingDirectory + "], filename [" + psi.FileName + "], arguments [" + psi.Arguments + "]");
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
            catch (Exception e)
            {
                // ...
                Console.WriteLine(e.Message);
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
            // txt_Project.Text = "";
            lst_Projects.DataSource = null;
            l = getProjectList();
            lst_Projects.DataSource = l;
            for (int n=0; n<lst_Projects.Items.Count; n++)
            {
                if ( lst_Projects.Items[n].ToString() == s )
                {
                    lst_Projects.SelectedIndex = n;
                    // txt_Project.Text = s;
                }
            }
            // refreshSourceList();
            return Result;
        }

        private bool refreshSourceList()
        {
            bool Result;
            List<string> l;
            string s;
            Result = false;
            s = txt_Source.Text;
            // txt_Source.Text = "";
            lst_Sourcefiles.DataSource = null;
            l = getSourceList();
            lst_Sourcefiles.DataSource = l;
            for (int n = 0; n < lst_Sourcefiles.Items.Count; n++)
            {
                if (lst_Sourcefiles.Items[n].ToString() == s)
                {
                    lst_Sourcefiles.SelectedIndex = n;
                    // txt_Source.Text = s;
                }
            }
            return Result;
        }

        private bool refreshEmuOptions()
        {
            bool Result;
            string opt;
            Result = false;

            opt = "";
            opt = opt + "<emu_options>";
            opt = opt + "<emu_rompath>";
            opt = opt + "<emu_machine>";
            opt = opt + "<emu_joyport>";
            opt = opt + "<emu_gromport>";
            opt = opt + "<emu_cart>";
            opt = opt + "<emu_ioport>";
            opt = opt + "<emu_peb2>";
            opt = opt + "<emu_peb3>";
            opt = opt + "<emu_peb4>";
            opt = opt + "<emu_peb5>";
            opt = opt + "<emu_peb6>";
            opt = opt + "<emu_peb7>";
            opt = opt + "<emu_peb8>";
            opt = opt + "<emu_fdc1>";
            opt = opt + "<emu_fdc2>";
            opt = opt + "<emu_fdc3>";
            opt = opt + "<emu_fdc4>";
            opt = opt + "<emu_hdc1>";
            opt = opt + "<emu_hdc2>";
            opt = opt + "<emu_hdc3>";
            opt = opt + "<emu_cass1>";
            opt = opt + "<emu_cass2>";
            opt = opt + "<emu_disk1>";
            opt = opt + "<emu_disk2>";
            opt = opt + "<emu_disk3>";
            opt = opt + "<emu_disk4>";
            opt = opt + "<emu_hard1>";
            opt = opt + "<emu_hard2>";
            opt = opt + "<emu_hard3>";
            txt_Emu_Options.Text = replacePatterns(opt);

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

            toolStripStatusLabel2.Text = "Editor"; Application.DoEvents();

            bin = replacePatterns(txt_Editor_Binary.Text);
            opt = replacePatterns(txt_Editor_Options.Text);
            wrk = replacePatterns(txt_Xdt_Base.Text + txt_Xdt_Projects.Text + txt_Project.Text);
            Result = runExternal(bin, opt, wrk, false);

            toolStripStatusLabel2.Text = "idle"; Application.DoEvents();

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
            int n;

            toolStripStatusLabel2.Text = "Assembler";

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
            n = 0;
            if (chk_Assembler_Object.Checked) { n = n + 1; }
            if (chk_Assembler_Image.Checked) { n = n + 1; }
            if (chk_Assembler_Rpk.Checked) { n = n + 1; }

            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = src.Count * n;
            toolStripProgressBar1.Value = 0;
            toolStripStatusLabel1.Text = "assembling"; Application.DoEvents();
            toolStripStatusLabel1.Visible = true;
            toolStripProgressBar1.Visible = true;

            wrk = replacePatterns(txt_Xdt_Base.Text + txt_Xdt_Projects.Text + txt_Project.Text);
            bin = replacePatterns(txt_Xdt_Base.Text + txt_Xdt_Assembler.Text);
            sav = txt_Source.Text;
            foreach (string s in src)
            {

                txt_Source.Text = s;
                if (chk_Assembler_Object.Checked)
                {
                    toolStripStatusLabel1.Text = "object"; Application.DoEvents();
                    opt = replacePatterns(txt_Xdt_AsOptions_Object.Text);
                    Result = runExternal(bin, opt, wrk, true);
                    toolStripProgressBar1.Value = toolStripProgressBar1.Value + 1; Application.DoEvents();
                }
                if (chk_Assembler_Image.Checked)
                {
                    toolStripStatusLabel1.Text = "image"; Application.DoEvents();
                    opt = replacePatterns(txt_Xdt_AsOptions_Image.Text);
                    Result = runExternal(bin, opt, wrk, true);
                    toolStripProgressBar1.Value = toolStripProgressBar1.Value + 1; Application.DoEvents();
                }
                if (chk_Assembler_Rpk.Checked)
                {
                    toolStripStatusLabel1.Text = "rpk"; Application.DoEvents();
                    opt = replacePatterns(txt_Xdt_AsOptions_Rpk.Text);
                    Result = runExternal(bin, opt, wrk, true);
                    toolStripProgressBar1.Value = toolStripProgressBar1.Value + 1; Application.DoEvents();
                }

            }
            toolStripStatusLabel1.Visible = false;
            toolStripStatusLabel1.Text = "";
            toolStripProgressBar1.Visible = false;

            txt_Source.Text = sav;
            if (txt_Standard_Output.Text != "")
            {
                // MessageBox.Show("See results...");
                // tabControl1.SelectedTab = tab_StdOut;
            }
            if (txt_Error_Output.Text != "")
            {
                MessageBox.Show("There were errors!");
                tabControl1.SelectedTab = tab_StdErr;
            }

            toolStripStatusLabel2.Text = "idle";

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
            int m;
            Result = false;

            toolStripStatusLabel2.Text = "DiskManager"; Application.DoEvents();
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
            m = 0;
            if (chk_Copy_Source.Checked) { m = m + 1; }
            if (chk_Copy_List.Checked) { m = m + 1; }
            if (chk_Copy_Object.Checked) { m = m + 1; }
            if (chk_Copy_Image.Checked) { m = m + 1; }
            m = src.Count * m;
            if ((chk_Copy_Catalog.Checked) | (chk_Copy_AutoStart.Checked)) { m = m + 1; }

            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = m;
            toolStripProgressBar1.Value = 0;
            toolStripStatusLabel1.Text = "copying"; Application.DoEvents();
            toolStripStatusLabel1.Visible = true;
            toolStripProgressBar1.Visible = true;

            wrk = replacePatterns(txt_Xdt_Base.Text + txt_Xdt_Projects.Text + txt_Project.Text);
            // wrk = replacePatterns(txt_Emu_Path.Text + txt_Emu_DiskPath.Text);
            bin = replacePatterns(txt_Xdt_Base.Text + txt_Xdt_DiskManager.Text);
            opt = replacePatterns(txt_Xdt_DmCreate_Diskfile.Text);

            toolStripStatusLabel1.Text = "disk file"; Application.DoEvents();
            Result = runExternal(bin, opt, wrk, true);
            sav = txt_Source.Text;
            foreach (string s in src)
            {
                txt_Source.Text = s;
                if (chk_Copy_Source.Checked)
                {
                    toolStripStatusLabel1.Text = "source"; Application.DoEvents();
                    opt = replacePatterns(txt_Xdt_DmCopy_Source.Text);
                    Result = runExternal(bin, opt, wrk, true);
                    toolStripProgressBar1.Value = toolStripProgressBar1.Value + 1; Application.DoEvents();
                }
                if (chk_Copy_List.Checked)
                {
                    toolStripStatusLabel1.Text = "list"; Application.DoEvents();
                    opt = replacePatterns(txt_Xdt_DmCopy_List.Text);
                    Result = runExternal(bin, opt, wrk, true);
                    toolStripProgressBar1.Value = toolStripProgressBar1.Value + 1; Application.DoEvents();
                }
                if (chk_Copy_Object.Checked)
                {
                    toolStripStatusLabel1.Text = "object"; Application.DoEvents();
                    opt = replacePatterns(txt_Xdt_DmCopy_Object.Text);
                    Result = runExternal(bin, opt, wrk, true);
                    toolStripProgressBar1.Value = toolStripProgressBar1.Value + 1; Application.DoEvents();
                }
                if (chk_Copy_Image.Checked)
                {
                    toolStripStatusLabel1.Text = "image"; Application.DoEvents();
                    opt = replacePatterns(txt_Xdt_DmCopy_Image.Text);
                    Result = runExternal(bin, opt, wrk, true);
                    toolStripProgressBar1.Value = toolStripProgressBar1.Value + 1; Application.DoEvents();
                }
            }
            txt_Source.Text = sav;
            if ((chk_Copy_Catalog.Checked) | (chk_Copy_AutoStart.Checked))
            {
                // wrk = replacePatterns(txt_Xdt_Base.Text + txt_Xdt_Projects.Text + txt_Project.Text);
                toolStripStatusLabel1.Text = "autorun"; Application.DoEvents();
                sav = txt_Xdt_Base.Text + txt_Xdt_Projects.Text + txt_Project.Text + "\\load.b99";
                using (StreamWriter bas = new StreamWriter(sav))
                {
                    for (int n = 0; n < basload1.Length; n++)
                    {
                        bas.WriteLine(basload1[n]);
                    }
                    if (chk_Copy_Catalog.Checked)
                    {
                        for (int n = 0; n < basload2.Length; n++)
                        {
                            bas.WriteLine(basload2[n]);
                        }
                    }
                    if (chk_Copy_AutoStart.Checked)
                    {
                        for (int n = 0; n < basload3.Length; n++)
                        {
                            bas.WriteLine(replacePatterns(basload3[n]));
                        }
                    }
                }
                bin = replacePatterns(txt_Xdt_Base.Text + txt_Xdt_BasConv.Text);
                opt = replacePatterns(txt_Xdt_BasConv_Load.Text);
                Result = runExternal(bin, opt, wrk, true);
                // wrk = replacePatterns(txt_Emu_Path.Text + txt_Emu_DiskPath.Text);
                bin = replacePatterns(txt_Xdt_Base.Text + txt_Xdt_DiskManager.Text);
                opt = replacePatterns(txt_Xdt_DmCopy_Run.Text);
                Result = runExternal(bin, opt, wrk, true);
                toolStripProgressBar1.Value = toolStripProgressBar1.Value + 1;
            }
            opt = replacePatterns(txt_Xdt_DmShow_Directory.Text);
            Result = runExternal(bin, opt, wrk, true);

            Result = runExternal("cmd.exe", replacePatterns("/c copy <prjdisk> " + replacePatterns(txt_Emu_Path.Text + txt_Emu_DiskPath.Text + "<prjdisk>")), wrk, true);

            toolStripStatusLabel1.Visible = false;
            toolStripStatusLabel1.Text = "";
            toolStripProgressBar1.Visible = false;

            if (txt_Standard_Output.Text != "")
            {
                // MessageBox.Show("See results...");
                // tabControl1.SelectedTab = tab_StdOut;
            }
            if (txt_Error_Output.Text != "")
            {
                MessageBox.Show("There were errors!");
                tabControl1.SelectedTab = tab_StdErr;
            }

            toolStripStatusLabel2.Text = "idle";
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
            string s;
            Result = false;

            toolStripStatusLabel2.Text = "Emulator"; Application.DoEvents();

            txt_Standard_Output.Text = "";
            txt_Error_Output.Text = "";

            s = cmb_Emu_Cartridge.Text;
            if (opt_Emu_EditAss.Checked) { cmb_Emu_Cartridge.Text = "EditAss"; txt_Emu_DSK1.Text = replacePatterns("<prjdisk>"); }
            if (opt_Emu_MiniMem.Checked) { cmb_Emu_Cartridge.Text = "MiniMem"; txt_Emu_DSK1.Text = replacePatterns("<prjdisk>"); }
            if (opt_Emu_ExBasic.Checked) { cmb_Emu_Cartridge.Text = "ExBasic"; txt_Emu_DSK1.Text = replacePatterns("<prjdisk>"); }
            refreshEmuOptions();
            bin = txt_Emu_Binary.Text;
            // opt = replacePatterns("ti99_4ev -gromport single -cart <ticart> -ioport peb -ioport:peb:slot2 evpc -ioport:peb:slot8 hfdc -ioport:peb:slot8:hfdc:f1 525dd -ioport:peb:slot8:hfdc:f2 525dd -ioport:peb:slot8:hfdc:h1 generic -flop1 disk/<prjdisk> -flop2 disk/flopdsk2.dsk -hard1 hard/harddsk1.chd");
            opt = txt_Emu_Options.Text.Trim();
            wrk = txt_Emu_Path.Text;
            runExternal(bin, opt, wrk, false);
            s = cmb_Emu_Cartridge.Text;

            if (txt_Standard_Output.Text != "")
            {
                // MessageBox.Show("See results...");
                // tabControl1.SelectedTab = tab_StdOut;
            }
            if (txt_Error_Output.Text != "")
            {
                MessageBox.Show("There were errors!");
                tabControl1.SelectedTab = tab_StdErr;
            }

            toolStripStatusLabel2.Text = "idle"; Application.DoEvents();

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
                // MessageBox.Show("settings saved");
                Result = true;
            }
            catch (Exception e)
            {
                // MessageBox.Show("error saving xdt99 settings !");
                Console.WriteLine(e.Message);
                
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
                s = Properties.Settings.Default["Editor_Binary"].ToString(); //if (s != "")
                    { txt_Editor_Binary.Text = s; }
                s = Properties.Settings.Default["Editor_Options"].ToString(); //if (s != "")
                    { txt_Editor_Options.Text = s; }
                s = Properties.Settings.Default["Xdt_Base"].ToString(); //if (s != "")
                    { txt_Xdt_Base.Text = s; }
                s = Properties.Settings.Default["Xdt_Projects"].ToString(); //if (s != "")
                    { txt_Xdt_Projects.Text = s; }
                s = Properties.Settings.Default["Xdt_Library"].ToString(); //if (s != "")
                    { txt_Xdt_Library.Text = s; }
                s = Properties.Settings.Default["Xdt_Assembler"].ToString(); //if (s != "")
                    { txt_Xdt_Assembler.Text = s; }
                s = Properties.Settings.Default["Xdt_AsOptions_Object"].ToString(); //if (s != "")
                    { txt_Xdt_AsOptions_Object.Text = s; }
                s = Properties.Settings.Default["Xdt_AsOptions_Rpk"].ToString(); //if (s != "")
                    { txt_Xdt_AsOptions_Rpk.Text = s; }
                s = Properties.Settings.Default["Xdt_AsOptions_Image"].ToString(); //if (s != "")
                    { txt_Xdt_AsOptions_Image.Text = s; }
                s = Properties.Settings.Default["Xdt_BasConv"].ToString(); //if (s != "")
                    { txt_Xdt_BasConv.Text = s; }
                s = Properties.Settings.Default["Xdt_BasConv_Load"].ToString(); //if (s != "")
                    { txt_Xdt_BasConv_Load.Text = s; }
                s = Properties.Settings.Default["Xdt_DiskManager"].ToString(); //if (s != "")
                    { txt_Xdt_DiskManager.Text = s; }
                s = Properties.Settings.Default["Xdt_DmCreate_Diskfile"].ToString(); //if (s != "")
                    { txt_Xdt_DmCreate_Diskfile.Text = s; }
                s = Properties.Settings.Default["Xdt_DmCopy_Source"].ToString(); //if (s != "")
                    { txt_Xdt_DmCopy_Source.Text = s; }
                s = Properties.Settings.Default["Xdt_DmCopy_List"].ToString(); //if (s != "")
                { txt_Xdt_DmCopy_List.Text = s; }
                s = Properties.Settings.Default["Xdt_DmCopy_Object"].ToString(); //if (s != "")
                { txt_Xdt_DmCopy_Object.Text = s; }
                s = Properties.Settings.Default["Xdt_DmCopy_Image"].ToString(); //if (s != "")
                { txt_Xdt_DmCopy_Image.Text = s; }
                s = Properties.Settings.Default["Xdt_DmCopy_Run"].ToString(); //if (s != "")
                { txt_Xdt_DmCopy_Run.Text = s; }
                s = Properties.Settings.Default["Xdt_DmShow_Directory"].ToString(); //if (s != "")
                { txt_Xdt_DmShow_Directory.Text = s; }
                s = Properties.Settings.Default["ExtWin_Source"].ToString(); //if (s != "")
                { txt_ExtWin_Source.Text = s; }
                s = Properties.Settings.Default["ExtWin_Object"].ToString(); //if (s != "")
                { txt_ExtWin_Object.Text = s; }
                s = Properties.Settings.Default["ExtWin_List"].ToString(); //if (s != "")
                { txt_ExtWin_List.Text = s; }
                s = Properties.Settings.Default["ExtWin_Rpk"].ToString(); //if (s != "")
                { txt_ExtWin_Rpk.Text = s; }
                s = Properties.Settings.Default["ExtWin_Image"].ToString(); //if (s != "")
                { txt_ExtWin_Image.Text = s; }
                s = Properties.Settings.Default["ExtWin_BasT"].ToString(); //if (s != "")
                { txt_ExtWin_BasT.Text = s; }
                s = Properties.Settings.Default["ExtWin_Basb"].ToString(); //if (s != "")
                { txt_ExtWin_BasB.Text = s; }
                s = Properties.Settings.Default["ExtWin_Disk"].ToString(); //if (s != "")
                { txt_ExtWin_Disk.Text = s; }
                s = Properties.Settings.Default["ExtEmu_Source"].ToString(); //if (s != "")
                { txt_ExtEmu_Source.Text = s; }
                s = Properties.Settings.Default["ExtEmu_Object"].ToString(); //if (s != "")
                { txt_ExtEmu_Object.Text = s; }
                s = Properties.Settings.Default["ExtEmu_List"].ToString(); //if (s != "")
                { txt_ExtEmu_List.Text = s; }
                s = Properties.Settings.Default["ExtEmu_Image"].ToString(); //if (s != "")
                { txt_ExtEmu_Image.Text = s; }
                s = Properties.Settings.Default["Emu_Load"].ToString(); //if (s != "")
                { txt_Emu_Load.Text = s; }
                Result = true;
            }
            catch (Exception e)
            {
                // MessageBox.Show("error loading xdt99 settings !");
                Console.WriteLine(e.Message);
            }
            return Result;
        }

        private bool saveSettingsMame()
        {
            bool Result;
            Result = false;
            try
            {
                Properties.Settings.Default["Emu_Binary"] = txt_Emu_Binary.Text;
                Properties.Settings.Default["Emu_Path"] = txt_Emu_Path.Text;
                Properties.Settings.Default["Emu_RomPath"] = txt_Emu_RomPath.Text;
                Properties.Settings.Default["Emu_CartPath"] = txt_Emu_CartPath.Text;
                Properties.Settings.Default["Emu_DiskPath"] = txt_Emu_DiskPath.Text;
                Properties.Settings.Default["Emu_HardPath"] = txt_Emu_HardPath.Text;
                Properties.Settings.Default["Emu_Machine"] = cmb_Emu_Machine.Text;
                Properties.Settings.Default["Emu_JoyPort"] = cmb_Emu_JoyPort.Text;
                Properties.Settings.Default["Emu_GromPort"] = cmb_Emu_GromPort.Text;
                Properties.Settings.Default["Emu_Cart"] = cmb_Emu_Cartridge.Text;
                Properties.Settings.Default["Emu_IoPort"] = cmb_Emu_IoPort.Text;
                Properties.Settings.Default["Emu_Peb2"] = cmb_Emu_Peb2.Text;
                Properties.Settings.Default["Emu_Peb3"] = cmb_Emu_Peb3.Text;
                Properties.Settings.Default["Emu_Peb4"] = cmb_Emu_Peb4.Text;
                Properties.Settings.Default["Emu_Peb5"] = cmb_Emu_Peb5.Text;
                Properties.Settings.Default["Emu_Peb6"] = cmb_Emu_Peb6.Text;
                Properties.Settings.Default["Emu_Peb7"] = cmb_Emu_Peb7.Text;
                Properties.Settings.Default["Emu_Peb8"] = cmb_Emu_Peb8.Text;
                Properties.Settings.Default["Emu_FDD1"] = cmb_Emu_Fdd1.Text;
                Properties.Settings.Default["Emu_FDD2"] = cmb_Emu_Fdd2.Text;
                Properties.Settings.Default["Emu_FDD3"] = cmb_Emu_Fdd3.Text;
                Properties.Settings.Default["Emu_FDD4"] = cmb_Emu_Fdd4.Text;
                Properties.Settings.Default["Emu_HDD1"] = cmb_Emu_Hdd1.Text;
                Properties.Settings.Default["Emu_HDD2"] = cmb_Emu_Hdd2.Text;
                Properties.Settings.Default["Emu_HDD3"] = cmb_Emu_Hdd3.Text;
                Properties.Settings.Default["Emu_CS1"] = txt_Emu_CS1.Text;
                Properties.Settings.Default["Emu_CS2"] = txt_Emu_CS2.Text;
                Properties.Settings.Default["Emu_DSK1"] = txt_Emu_DSK1.Text;
                Properties.Settings.Default["Emu_DSK2"] = txt_Emu_DSK2.Text;
                Properties.Settings.Default["Emu_DSK3"] = txt_Emu_DSK3.Text;
                Properties.Settings.Default["Emu_DSK4"] = txt_Emu_DSK4.Text;
                Properties.Settings.Default["Emu_WDS1"] = txt_Emu_WDS1.Text;
                Properties.Settings.Default["Emu_WDS2"] = txt_Emu_WDS2.Text;
                Properties.Settings.Default["Emu_WDS3"] = txt_Emu_WDS3.Text;
                Properties.Settings.Default["Emu_Options"] = txt_Emu_AddOptions.Text;
                Properties.Settings.Default.Save();
                // MessageBox.Show("settings saved");
                Result = true;
            }
            catch (Exception e)
            {
                // MessageBox.Show("error saving emulator settings !");
                Console.WriteLine(e.Message);
            }
            return Result;
        }

        private bool loadSettingsMame()
        {
            bool Result;
            string s;
            Result = false;
            try
            {
                // s = Properties.Settings.Default["Editor_Binary"].ToString(); if (s != "")
                //     { txt_Editor_Binary.Text = s; }
                s = Properties.Settings.Default["Emu_Binary"].ToString(); //if (s != "")
                { txt_Emu_Binary.Text = s; }
                s = Properties.Settings.Default["Emu_Path"].ToString(); //if (s != "")
                { txt_Emu_Path.Text = s; }
                s = Properties.Settings.Default["Emu_RomPath"].ToString(); //if (s != "")
                { txt_Emu_RomPath.Text = s; }
                s = Properties.Settings.Default["Emu_CartPath"].ToString(); //if (s != "")
                { txt_Emu_CartPath.Text = s; }
                s = Properties.Settings.Default["Emu_DiskPath"].ToString(); //if (s != "")
                { txt_Emu_DiskPath.Text = s; }
                s = Properties.Settings.Default["Emu_HardPath"].ToString(); //if (s != "")
                { txt_Emu_HardPath.Text = s; }
                s = Properties.Settings.Default["Emu_Machine"].ToString(); if (s != "")
                { cmb_Emu_Machine.Text = s; }
                s = Properties.Settings.Default["Emu_JoyPort"].ToString(); if (s != "")
                { cmb_Emu_JoyPort.Text = s; }
                s = Properties.Settings.Default["Emu_GromPort"].ToString(); if (s != "")
                { cmb_Emu_GromPort.Text = s; }
                s = Properties.Settings.Default["Emu_Cart"].ToString(); if (s != "")
                { cmb_Emu_Cartridge.Text = s; }
                s = Properties.Settings.Default["Emu_IoPort"].ToString(); if (s != "")
                { cmb_Emu_IoPort.Text = s; }
                s = Properties.Settings.Default["Emu_Peb2"].ToString(); if (s != "")
                { cmb_Emu_Peb2.Text = s; }
                s = Properties.Settings.Default["Emu_Peb3"].ToString(); if (s != "")
                { cmb_Emu_Peb3.Text = s; }
                s = Properties.Settings.Default["Emu_Peb4"].ToString(); if (s != "")
                { cmb_Emu_Peb4.Text = s; }
                s = Properties.Settings.Default["Emu_Peb5"].ToString(); if (s != "")
                { cmb_Emu_Peb5.Text = s; }
                s = Properties.Settings.Default["Emu_Peb6"].ToString(); if (s != "")
                { cmb_Emu_Peb6.Text = s; }
                s = Properties.Settings.Default["Emu_Peb7"].ToString(); if (s != "")
                { cmb_Emu_Peb7.Text = s; }
                s = Properties.Settings.Default["Emu_Peb8"].ToString(); if (s != "")
                { cmb_Emu_Peb8.Text = s; }
                s = Properties.Settings.Default["Emu_FDD1"].ToString(); if (s != "")
                { cmb_Emu_Fdd1.Text = s; }
                s = Properties.Settings.Default["Emu_FDD2"].ToString(); if (s != "")
                { cmb_Emu_Fdd2.Text = s; }
                s = Properties.Settings.Default["Emu_FDD3"].ToString(); if (s != "")
                { cmb_Emu_Fdd3.Text = s; }
                s = Properties.Settings.Default["Emu_FDD4"].ToString(); if (s != "")
                { cmb_Emu_Fdd4.Text = s; }
                s = Properties.Settings.Default["Emu_HDD1"].ToString(); if (s != "")
                { cmb_Emu_Hdd1.Text = s; }
                s = Properties.Settings.Default["Emu_HDD2"].ToString(); if (s != "")
                { cmb_Emu_Hdd2.Text = s; }
                s = Properties.Settings.Default["Emu_HDD3"].ToString(); if (s != "")
                { cmb_Emu_Hdd3.Text = s; }
                s = Properties.Settings.Default["Emu_CS1"].ToString(); //if (s != "")
                { txt_Emu_CS1.Text = s; }
                s = Properties.Settings.Default["Emu_CS2"].ToString(); //if (s != "")
                { txt_Emu_CS2.Text = s; }
                s = Properties.Settings.Default["Emu_DSK1"].ToString(); //if (s != "")
                { txt_Emu_DSK1.Text = s; }
                s = Properties.Settings.Default["Emu_DSK2"].ToString(); //if (s != "")
                { txt_Emu_DSK2.Text = s; }
                s = Properties.Settings.Default["Emu_DSK3"].ToString(); //if (s != "")
                { txt_Emu_DSK3.Text = s; }
                s = Properties.Settings.Default["Emu_DSK4"].ToString(); //if (s != "")
                { txt_Emu_DSK4.Text = s; }
                s = Properties.Settings.Default["Emu_WDS1"].ToString(); //if (s != "")
                { txt_Emu_WDS1.Text = s; }
                s = Properties.Settings.Default["Emu_WDS2"].ToString(); //if (s != "")
                { txt_Emu_WDS2.Text = s; }
                s = Properties.Settings.Default["Emu_WDS3"].ToString(); //if (s != "")
                { txt_Emu_WDS3.Text = s; }
                s = Properties.Settings.Default["Emu_Options"].ToString(); //if (s != "")
                { txt_Emu_AddOptions.Text = s; }
                Result = true;
            }
            catch (Exception e)
            {
                // MessageBox.Show("error loading emulator settings !");
                Console.WriteLine(e.Message);
            }
            return Result;
        }

        private bool saveSettingsIde()
        {
            bool Result;
            Result = false;
            try
            {
                Properties.Settings.Default["IDE_Project"] = txt_Project.Text;
                Properties.Settings.Default["IDE_Source"] = txt_Source.Text;
                Properties.Settings.Default["IDE_chk_Assembler_all"] = chk_Assembler_all.Checked;
                Properties.Settings.Default["IDE_chk_Assembler_Object"] = chk_Assembler_Object.Checked;
                Properties.Settings.Default["IDE_chk_Assembler_Image"] = chk_Assembler_Image.Checked;
                Properties.Settings.Default["IDE_chk_Assembler_Rpk"] = chk_Assembler_Rpk.Checked;
                Properties.Settings.Default["IDE_chk_Copy_all"] = chk_Copy_all.Checked;
                Properties.Settings.Default["IDE_chk_Copy_Source"] = chk_Copy_Source.Checked;
                Properties.Settings.Default["IDE_chk_Copy_List"] = chk_Copy_List.Checked;
                Properties.Settings.Default["IDE_chk_Copy_Object"] = chk_Copy_Object.Checked;
                Properties.Settings.Default["IDE_chk_Copy_Image"] = chk_Copy_Image.Checked;
                Properties.Settings.Default["IDE_chk_Copy_Catalog"] = chk_Copy_Catalog.Checked;
                Properties.Settings.Default["IDE_chk_Copy_AutoStart"] = chk_Copy_AutoStart.Checked;
                Properties.Settings.Default["IDE_opt_Emu_EditAss"] = opt_Emu_EditAss.Checked;
                Properties.Settings.Default["IDE_opt_Emu_MiniMem"] = opt_Emu_MiniMem.Checked;
                Properties.Settings.Default["IDE_opt_Emu_ExBasic"] = opt_Emu_ExBasic.Checked;
                Properties.Settings.Default["IDE_opt_Emu_other"] = opt_Emu_other.Checked;
                Properties.Settings.Default.Save();
                // MessageBox.Show("settings saved");
                Result = true;
            }
            catch (Exception e)
            {
                // MessageBox.Show("error saving ide settings !");
                Console.WriteLine(e.Message);
            }
            return Result;
        }

        private bool loadSettingsIde()
        {
            bool Result;
            string s;
            Result = false;
            try
            {
                s = Properties.Settings.Default["IDE_Project"].ToString(); //if (s != "")
                { txt_Project.Text = s; }
                refreshProjectList();
                s = Properties.Settings.Default["IDE_Source"].ToString(); //if (s != "")
                { txt_Source.Text = s; }
                refreshSourceList();
                chk_Assembler_all.Checked = (bool)Properties.Settings.Default["IDE_chk_Assembler_all"];
                chk_Assembler_Object.Checked = (bool)Properties.Settings.Default["IDE_chk_Assembler_Object"];
                chk_Assembler_Image.Checked = (bool)Properties.Settings.Default["IDE_chk_Assembler_Image"];
                chk_Assembler_Rpk.Checked = (bool)Properties.Settings.Default["IDE_chk_Assembler_Rpk"];
                chk_Copy_all.Checked = (bool)Properties.Settings.Default["IDE_chk_Copy_all"];
                chk_Copy_Source.Checked = (bool)Properties.Settings.Default["IDE_chk_Copy_Source"];
                chk_Copy_List.Checked = (bool)Properties.Settings.Default["IDE_chk_Copy_List"];
                chk_Copy_Object.Checked = (bool)Properties.Settings.Default["IDE_chk_Copy_Object"];
                chk_Copy_Image.Checked = (bool)Properties.Settings.Default["IDE_chk_Copy_Image"];
                chk_Copy_Catalog.Checked = (bool)Properties.Settings.Default["IDE_chk_Copy_Catalog"];
                chk_Copy_AutoStart.Checked = (bool)Properties.Settings.Default["IDE_chk_Copy_AutoStart"];
                opt_Emu_EditAss.Checked = (bool)Properties.Settings.Default["IDE_opt_Emu_EditAss"];
                opt_Emu_MiniMem.Checked = (bool)Properties.Settings.Default["IDE_opt_Emu_MiniMem"];
                opt_Emu_ExBasic.Checked = (bool)Properties.Settings.Default["IDE_opt_Emu_ExBasic"];
                opt_Emu_other.Checked = (bool)Properties.Settings.Default["IDE_opt_Emu_other"];
                Result = true;
            }
            catch (Exception e)
            {
                // MessageBox.Show("error loading ide settings !");
                Console.WriteLine(e.Message);
            }
            return Result;
        }

        private bool saveSettingsAll()
        {
            bool Result;
            Result = false;
            saveSettingsXdt();
            saveSettingsMame();
            saveSettingsIde();
            Result = true;
            return Result;
        }

        private bool loadSettingsAll()
        {
            bool Result;
            Result = false;
            loadSettingsXdt();
            loadSettingsMame();
            loadSettingsIde();
            Result = true;
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

        private void btn_Check_Mame_Click(object sender, EventArgs e)
        {
            startEmulator();
        }

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

        private void btn_AsmDskEmu_Click(object sender, EventArgs e)
        {
            startAssembler();
            startDiskManager();
            startEmulator();
        }

        // create new project sub folder
        private void btn_New_Project_Click(object sender, EventArgs e)
        {
            MessageBox.Show("not implementet yet");
            // ...
        }

        // create new source file
        // use an optional template file, create empty file otherwise
        private void btn_New_Source_Click(object sender, EventArgs e)
        {
            MessageBox.Show("not implementet yet");
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

        private void Form1_Load(object sender, EventArgs e)
        {
            loadSettingsAll();
        }

        // updates the "options" textbox whenever any of the options is changed
        // one sub for all textboxes, comboboxes etc "onchange" events)
        private void txt_Emu_TextChanged(object sender, EventArgs e)
        {
            refreshEmuOptions();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tab_IDE)
            {
                refreshProjectList();
            }
            if (tabControl1.SelectedTab == tab_MAME)
            {
                refreshEmuOptions();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveSettingsAll();
        }

    }

}
