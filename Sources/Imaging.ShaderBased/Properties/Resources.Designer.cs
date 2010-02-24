namespace AForge.Imaging.ShaderBased.Properties {
    using System;
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
               
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AForge.Imaging.ShaderBased.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
               
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static string HLSLChessboard {
            get {
                return ResourceManager.GetString("HLSLChessboard", resourceCulture);
            }
        }
        
        internal static string HLSLGrayscale {
            get {
                return ResourceManager.GetString("HLSLGrayscale", resourceCulture);
            }
        }
        
        internal static string HLSLInvert {
            get {
                return ResourceManager.GetString("HLSLInvert", resourceCulture);
            }
        }
                
        internal static string HLSLLaplace {
            get {
                return ResourceManager.GetString("HLSLLaplace", resourceCulture);
            }
        }
                
        internal static string HLSLOriginal {
            get {
                return ResourceManager.GetString("HLSLOriginal", resourceCulture);
            }
        }
               
        internal static string HLSLSepia {
            get {
                return ResourceManager.GetString("HLSLSepia", resourceCulture);
            }
        }
               
        internal static string HLSLSobelEdgeDetector {
            get {
                return ResourceManager.GetString("HLSLSobelEdgeDetector", resourceCulture);
            }
        }
    }
}
