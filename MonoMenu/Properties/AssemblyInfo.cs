using System.Resources;
using System.Reflection;
using System.Runtime.InteropServices;
using MelonLoader;

[assembly: AssemblyTitle(MonoMenu.BuildInfo.Name)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(MonoMenu.BuildInfo.Company)]
[assembly: AssemblyProduct(MonoMenu.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + MonoMenu.BuildInfo.Author)]
[assembly: AssemblyTrademark(MonoMenu.BuildInfo.Company)]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
//[assembly: Guid("")]
[assembly: AssemblyVersion(MonoMenu.BuildInfo.Version)]
[assembly: AssemblyFileVersion(MonoMenu.BuildInfo.Version)]
[assembly: NeutralResourcesLanguage("en")]
[assembly: MelonInfo(typeof(MonoMenu.MonoMenu), MonoMenu.BuildInfo.Name, MonoMenu.BuildInfo.Version, MonoMenu.BuildInfo.Author, MonoMenu.BuildInfo.DownloadLink)]


// Create and Setup a MelonModGame to mark a Mod as Universal or Compatible with specific Games.
// If no MelonModGameAttribute is found or any of the Values for any MelonModGame on the Mod is null or empty it will be assumed the Mod is Universal.
// Values for MelonModGame can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame(null, null)]