﻿'------------------------------------------------------------------------------
' <auto-generated>
'     このコードはツールによって生成されました。
'     ランタイム バージョン:4.0.30319.18033
'
'     このファイルへの変更は、正しくない動作の原因となる場合があります。
'     また、コードの再生成時には変更が失われます。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My.Resources

    'このクラスは、StronglyTypedResourceBuilder クラスから、
    'ResGen または Visual Studio のようなツールによって自動生成されました。
    'メンバーを追加または削除するには、.ResX ファイルを編集し、ResGen を
    '/str オプションと共に再実行するか、VS プロジェクトを再度ビルドします。
    '<summary>
    '  ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    '</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"),
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>
    Friend Module Resources

        Private resourceMan As Global.System.Resources.ResourceManager

        Private resourceCulture As Global.System.Globalization.CultureInfo

        '<summary>
        '  このクラスに使用される、キャッシュされた ResourceManager のインスタンスを返します。
        '</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("WebAPI_VB_NoAuth.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property

        '<summary>
        '  厳密に型指定されたこのリソース クラスを使用して、すべてのリソース ルックアップについて、現在のスレッドの CurrentUICulture プロパティを
        '  オーバーライドします。
        '</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set(ByVal value As Global.System.Globalization.CultureInfo)
                resourceCulture = value
            End Set
        End Property
    End Module
End Namespace
