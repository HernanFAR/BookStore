﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AuthorDomain.Properties.Validators.AuthorAggregateRoot.AuthorValidator {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class LanguageResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LanguageResources() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AuthorDomain.Properties.Validators.AuthorAggregateRoot.AuthorValidator.LanguageRe" +
                            "sources", typeof(LanguageResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
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
        ///   Busca una cadena traducida similar a Debes enviar un autor.
        /// </summary>
        internal static string AuthorNull {
            get {
                return ResourceManager.GetString("AuthorNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El autor enviado no cumple con el minimo de edad ({0}).
        /// </summary>
        internal static string BirthDateMustBeAdult {
            get {
                return ResourceManager.GetString("BirthDateMustBeAdult", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Debes enviar grados universitarios validos.
        /// </summary>
        internal static string DegreeNotNull {
            get {
                return ResourceManager.GetString("DegreeNotNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El nombre del autor no es valido.
        /// </summary>
        internal static string NameNotEmpty {
            get {
                return ResourceManager.GetString("NameNotEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El apellido del autor no es valido.
        /// </summary>
        internal static string SubnameNotEmpty {
            get {
                return ResourceManager.GetString("SubnameNotEmpty", resourceCulture);
            }
        }
    }
}
