﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnitTestTransportsCommuns {
    using System;
    
    
    /// <summary>
    ///   Une classe de ressource fortement typée destinée, entre autres, à la consultation des chaînes localisées.
    /// </summary>
    // Cette classe a été générée automatiquement par la classe StronglyTypedResourceBuilder
    // à l'aide d'un outil, tel que ResGen ou Visual Studio.
    // Pour ajouter ou supprimer un membre, modifiez votre fichier .ResX, puis réexécutez ResGen
    // avec l'option /str ou régénérez votre projet VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Json1 {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Json1() {
        }
        
        /// <summary>
        ///   Retourne l'instance ResourceManager mise en cache utilisée par cette classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("UnitTestTransportsCommuns.Json1", typeof(Json1).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Remplace la propriété CurrentUICulture du thread actuel pour toutes
        ///   les recherches de ressources à l'aide de cette classe de ressource fortement typée.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à [{&quot;id&quot;:&quot;SEM:13&quot;,&quot;shortName&quot;:&quot;13&quot;,&quot;longName&quot;:&quot;Meylan Lycée du Grésivaudan / Poisat Prémol&quot;,&quot;color&quot;:&quot;00BC9E&quot;,&quot;textColor&quot;:&quot;FFFFFF&quot;,&quot;mode&quot;:&quot;BUS&quot;,&quot;type&quot;:&quot;PROXIMO&quot;}].
        /// </summary>
        internal static string jsonDetailsLine {
            get {
                return ResourceManager.GetString("jsonDetailsLine", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à [{&quot;id&quot;:&quot;SEM:1986&quot;,&quot;name&quot;:&quot;GRENOBLE, CASERNE DE BONNE&quot;,&quot;lon&quot;:5.72533,&quot;lat&quot;:45.18506,&quot;lines&quot;:[&quot;SEM:13&quot;,&quot;SEM:16&quot;,&quot;SEM:C4&quot;]},{&quot;id&quot;:&quot;SEM:1987&quot;,&quot;name&quot;:&quot;GRENOBLE, CASERNE DE BONNE&quot;,&quot;lon&quot;:5.72542,&quot;lat&quot;:45.18509,&quot;lines&quot;:[&quot;SEM:16&quot;]}].
        /// </summary>
        internal static string jsonStation {
            get {
                return ResourceManager.GetString("jsonStation", resourceCulture);
            }
        }
    }
}
