﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("WeatherBridgeDataArchive.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to -----------------------_-------------------------------- [ ERROR ] ----------------_---------------------------------.
        '''</summary>
        Friend ReadOnly Property errSeparator() As String
            Get
                Return ResourceManager.GetString("errSeparator", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property PS_LOGO_transparent_190x150() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("PS_LOGO_transparent_190x150", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to -----------------------------------------------------------------------------------------------------------------------.
        '''</summary>
        Friend ReadOnly Property separator() As String
            Get
                Return ResourceManager.GetString("separator", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Button becomes active when 
        '''all required information has 
        '''been entered..
        '''</summary>
        Friend ReadOnly Property ttip_btn_runevents() As String
            Get
                Return ResourceManager.GetString("ttip_btn_runevents", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to If the WeatherBridge Update 
        '''is set to True, this will populate 
        '''automatically..
        '''</summary>
        Friend ReadOnly Property ttip_elevation() As String
            Get
                Return ResourceManager.GetString("ttip_elevation", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to This value is set in minutes.
        '''</summary>
        Friend ReadOnly Property ttip_min_val() As String
            Get
                Return ResourceManager.GetString("ttip_min_val", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to This value is set in seconds.
        '''</summary>
        Friend ReadOnly Property ttip_sec_val() As String
            Get
                Return ResourceManager.GetString("ttip_sec_val", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Enter Ambient Station name 
        '''here.  Default: Ambient.
        '''</summary>
        Friend ReadOnly Property ttip_station_name() As String
            Get
                Return ResourceManager.GetString("ttip_station_name", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
