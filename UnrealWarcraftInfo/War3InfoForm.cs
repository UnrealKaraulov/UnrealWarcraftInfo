using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Web;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace UnrealWarcraftInfo
{
    public partial class War3InfoForm : Form
    {
        public War3InfoForm ( )
        {
            InitializeComponent( );
        }



        string GetWarcraftUsername ( )
        {
            string bnetname = String.Empty;

            try
            {
                bnetname = "[ " + ( Registry.CurrentUser.OpenSubKey( @"Software\Blizzard Entertainment\WarCraft III\String" ).GetValue( "userbnet" ) as string ) + " ]";
                if ( bnetname == null || bnetname.Length == 0 )
                    bnetname = "[ Имя пользователя ]";
            }
            catch
            {
                bnetname = "[ Имя пользователя ]";
            }
            return bnetname;
        }

        string GetWar3PathFromRegistry ( )
        {
            string war3path = String.Empty;

            try
            {
                war3path = "[ " + ( Registry.CurrentUser.OpenSubKey( @"Software\Blizzard Entertainment\WarCraft III" ).GetValue( "InstallPath" ) as string ) + " ]";
                if ( war3path == null || war3path.Length == 0 )
                    war3path = "[ Не найден в реестре ]";
            }
            catch
            {

                war3path = "[ Не найден в реестре ]";
            }
            return war3path;
        }

        string GetWar3PathFromProcess ( Process war3proc )
        {
            return Path.GetDirectoryName( war3proc.MainModule.FileName );
        }


        string GetExternalIPAddress ( )
        {

            /*
             * 
             * 
             * 
             * */
            try
            {
                // Скачать строку http://checkip.dyndns.org/ и поместить ее в externalIP
                string externalIP = new WebClient( ).DownloadString( "http://checkip.dyndns.org/" );
                // С помощью простого Regex выражения вырезать IP адрес
                externalIP = new Regex( @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}" )
                             .Matches( externalIP ) [ 0 ].ToString( );
                return externalIP;
            }
            catch
            {
                try
                {
                    return new WebClient( ).DownloadString( "http://icanhazip.com" );
                }
                catch
                {
                    try
                    {
                        return new WebClient( ).DownloadString( "http://bot.whatismyipaddress.com" );
                    }
                    catch
                    {
                        try
                        {
                            return new WebClient( ).DownloadString( "http://ipinfo.io/ip" );
                        }
                        catch
                        {
                            return "[IP не обнаружен]";
                        }
                    }
                }

            }
        }

        private void GenerateWar3Info_Click ( object sender , EventArgs e )
        {
            List<string> OutWarcraftInfo = new List<string>( ); // Создать пустой список строк

            OutWarcraftInfo.Add( //Добавить новую строку в созданный список строк:
                "[center][b][u] Информация о пользователе:[/u][/b][b][i] " + GetWarcraftUsername( ) + "[/i][/b][/center]" );
            OutWarcraftInfo.Add( @"&#20" ); // Это для удобного переноса строк на сайте iCCup

            if ( SaveIP.Checked )
            {
                string IPforSave = @"[u][b]Ваш IP[/b][/u] : [color=green]"
                    + GetExternalIPAddress( )  // Получить внешний IP
                    + @"[/color]";

                OutWarcraftInfo.Add( IPforSave );
                OutWarcraftInfo.Add( @"&#20" );
            }

            if ( GenerateProcessList.Checked )
            {
                List<string> GenProcessList = new List<string>( );


                foreach ( Process curproc in Process.GetProcesses( ) )
                {
                    string curprocinfo = "[" + curproc.Id.ToString( ) + "] : " + curproc.ProcessName + ".exe ";

                    string procwindowname = curproc.MainWindowTitle;

                    if ( procwindowname.Length > 51 )
                        procwindowname = procwindowname.Remove( 50 );
                    else if ( procwindowname.Length == 0 )
                        procwindowname = "[unnamed]";

                    curprocinfo = curprocinfo + "\"" + procwindowname + "\"";

                    GenProcessList.Add( curprocinfo );
                }

                string outprocliststring = @"[b][u]Список процессов(" + GenProcessList.Count( ) + @")[/u][/b] : [spoiler=Показать]";

                OutWarcraftInfo.Add( outprocliststring );

                OutWarcraftInfo.AddRange( GenProcessList );

                OutWarcraftInfo.Add( "[/spoiler]" );

                OutWarcraftInfo.Add( @"&#20" );
            }

            string war3pathfromregistry = GetWar3PathFromRegistry( );
            string war3pathfromprocess = string.Empty;

            if ( PrintWar3ModuleList.Checked )
            {

                int war3processcount = Process.GetProcessesByName( "war3" ).Length;

                List<string> war3modules = new List<string>( );
                war3pathfromprocess = "[ процесс war3 не найден ]";
                if ( war3processcount > 0 )
                {
                    Process war3proc = Process.GetProcessesByName( "war3" ) [ 0 ];
                    war3pathfromprocess = GetWar3PathFromProcess( war3proc );
                    foreach ( ProcessModule curmdl in war3proc.Modules )
                    {
                        string moduleinf = "[" + curmdl.ModuleName + "]" + "[" + curmdl.BaseAddress.ToString( "X8" ) + "]";

                        if ( curmdl.FileVersionInfo.FileDescription.Length > 0 )
                        {
                            string moduledescr = curmdl.FileVersionInfo.FileDescription;
                            if ( moduledescr.Length > 51 )
                                moduledescr = moduledescr.Remove( 50 );
                            moduleinf += "\"" + moduledescr + "\"";
                        }

                        moduleinf += "[" + curmdl.FileVersionInfo.FileVersion + "]";
                        war3modules.Add( moduleinf );
                    }
                }

                OutWarcraftInfo.Add( "Путь к Warcraft III:" );
                OutWarcraftInfo.Add( "С реестра:" + war3pathfromregistry );
                OutWarcraftInfo.Add( war3pathfromprocess );

                if ( war3modules.Count > 0 )
                {
                    string outprocliststring = @"[b][u]Список модулей Warcraft III(" + war3modules.Count( ) + @")[/u][/b] : [spoiler=Показать]";

                    OutWarcraftInfo.Add( outprocliststring );

                    OutWarcraftInfo.AddRange( war3modules );

                    OutWarcraftInfo.Add( "[/spoiler]" );
                }

                OutWarcraftInfo.Add( @"&#20" );
            }

            if ( Warcraft3DirectoryInfo.Checked )
            {
                List<string> war3files = new List<string>( );

                try
                {
                    int removelen = war3pathfromregistry.Length;
                    if ( removelen > 3 )
                        foreach ( string file in Directory.GetFiles( war3pathfromregistry , "*" , SearchOption.AllDirectories ) )
                        {
                            war3files.Add( file.Remove( 0 , removelen ) );
                        }


                }
                catch
                {

                }
                try
                {
                    if ( war3pathfromregistry != war3pathfromprocess )
                    {
                        int removelen = war3pathfromprocess.Length;
                        if ( removelen > 3 )
                            foreach ( string file in Directory.GetFiles( war3pathfromprocess , "*" , SearchOption.AllDirectories ) )
                            {
                                war3files.Add( file.Remove( 0 , removelen ) );
                            }
                    }
                }
                catch
                {

                }
                string outprocliststring = @"[b][u]Список файлов Warcraft III(" + war3files.Count( ) + @")[/u][/b] : [spoiler=Показать]";

                OutWarcraftInfo.Add( outprocliststring );

                OutWarcraftInfo.AddRange( war3files );

                OutWarcraftInfo.Add( "[/spoiler]" );

            }

            File.WriteAllLines( "WarcraftInfo.txt" , OutWarcraftInfo.ToArray( ) );
            Process.Start( Directory.GetCurrentDirectory( ) + "\\WarcraftInfo.txt" );
        }
    }
}
