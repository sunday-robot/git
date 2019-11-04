// ------------------------------------------------------------------------------
// <copyright file="UiResource.cs" company="OLYMPUS,LI">
//     Copyright (C) 2010-2011 OLYMPUS CORPORATION All Rights Reserved.
// </copyright>
// ------------------------------------------------------------------------------
// Source history
// version      date        person      content
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace Olympus.LI.Triumph.Application.Resource
{
    /// <summary>
    /// ﾒｯｾｰｼﾞ・UIﾘｿｰｽｸﾗｽ
    /// </summary>
    public static class UiResource
    {
        #region Consts
        /// <summary>
        /// ﾘｿｰｽを含むｱｾﾝﾌﾞﾘ名(=OlyuUiResource.dll)
        /// </summary>
        private const System.String _RESOURCE_FILE = "OlyuUiResource.dll";

        /// <summary>
        /// ﾘｿｰｽﾙｰﾄ(=Olympus.LI.Triumph.Application.Resource.Strings)
        /// </summary>
        private const System.String _RESOURCE_ROOT = "Olympus.LI.Triumph.Application.Resource.Strings";
        #endregion Consts

        #region Member
        /// <summary>
        /// ﾘｿｰｽﾏﾈｰｼﾞｬ
        /// </summary>
        private static System.Resources.ResourceManager _resManager;
        #endregion Member

        /// <summary>
        /// 指定のｶﾙﾁｬ情報を設定する
        /// </summary>
        /// <param name="cultureInfo">ｶﾙﾁｬ情報</param>
        public static void SetCurrentCulture(System.Globalization.CultureInfo cultureInfo)
        {
            // ﾘｿｰｽﾏﾈｰｼﾞｬ作成
            _resManager = _GetResourceManager(cultureInfo);
        }

        /// <summary>
        /// 指定のｶﾙﾁｬ情報を設定する
        /// </summary>
        /// <param name="_strInfo">ｶﾙﾁｬ情報</param>
        public static void SetCurrentCulture(String _strInfo)
        {
            System.String strCulture = _strInfo;

            switch (strCulture)
            {
                case "ja-JP":
                    break;
                case "de-DE":
                    break;
                case "ko-KR":
                    break;
                case "zh-CN":
                    break;
                case "en-US":
                default:
                    // Cultureが該当なしでは、Defaultのリソースを選択。
                    strCulture = string.Empty; 
                    break;
            }

            // ﾘｿｰｽﾏﾈｰｼﾞｬ作成
            var cultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture(strCulture);
            cultureInfo.NumberFormat.NumberDecimalSeparator = ".";  // Triumphでは、言語、地域によらず、小数点は必ずピリオド(ドイツは本来カンマ)
            _resManager = _GetResourceManager(cultureInfo);
        }

        /// <summary>
        /// 現在のｶﾙﾁｬ言語のﾘｿｰｽ文字列を取得する。
        /// SetCurrentCulture()ﾒｿｯﾄﾞで設定したｶﾙﾁｬに基づいたﾘｿｰｽ文字列を取得する。
        /// </summary>
        /// <param name="strResourceId">ﾘｿｰｽID</param>
        /// <returns>ﾘｿｰｽ文字列</returns>
        public static System.String GetResourceValue(System.String strResourceId)
        {
            System.String strResource = System.String.Empty;

            if (_resManager == null)
            {
                // リソース未設定では、デフォルトを設定。
                SetCurrentCulture(string.Empty);
            }

            if (_resManager != null)
            {
                strResource = _resManager.GetString(strResourceId);
            }

            // TODO: 将来、以下の処理を削除し、#xxxに対する検討結果に従い、
            // 必要であれば取得ﾒｯｾｰｼﾞがﾌﾞﾗﾝｸやNULLだった場合の実装を追記する

            // ﾘｿｰｽ文字列がﾌﾞﾗﾝｸorNULLの場合、どのﾒｯｾｰｼﾞIDなのか瞬時に分かるよう
            // ﾘｿｰｽ文字列としてそのIDを設定する
            if (String.IsNullOrEmpty(strResource))
            {
                strResource = strResourceId;
            }

            // 改行ﾀｸﾞ(<BR>)を改行ｺｰﾄﾞに置き換えた文字列を返却する
            return strResource.Replace("<BR>", System.Environment.NewLine);
        }

        /// <summary>
        /// 現在のｶﾙﾁｬ言語のﾘｿｰｽ文字列の書式項目({0})をﾊﾟﾗﾒｰﾀで置換した文字列を取得する。
        /// SetCurrentCulture()ﾒｿｯﾄﾞで設定したｶﾙﾁｬに基づいたﾘｿｰｽ文字列を取得する。
        /// </summary>
        /// <param name="strResourceId">ﾘｿｰｽID</param>
        /// <param name="parameter">ﾊﾟﾗﾒｰﾀ</param>
        /// <returns>ﾘｿｰｽ文字列の書式項目{0}をﾊﾟﾗﾒｰﾀで置換した文字列</returns>
        public static System.String GetResourceValue(System.String strResourceId, object parameter)
        {
            String strResource = GetResourceValue(strResourceId);
            return String.Format(strResource, parameter);
        }

        /// <summary>
        /// 現在のｶﾙﾁｬ言語のﾘｿｰｽ文字列の書式項目({0},{1}…)をﾊﾟﾗﾒｰﾀで置換した文字列を取得する。
        /// SetCurrentCulture()ﾒｿｯﾄﾞで設定したｶﾙﾁｬに基づいたﾘｿｰｽ文字列を取得する。
        /// </summary>
        /// <param name="strResourceId">ﾘｿｰｽID</param>
        /// <param name="parameters">ﾊﾟﾗﾒｰﾀ</param>
        /// <returns>ﾘｿｰｽ文字列の書式項目({0},{1}…)をﾊﾟﾗﾒｰﾀで置換した文字列</returns>
        /// <remarks>ﾘｿｰｽ文字列の書式項目({0},{1}…)とﾊﾟﾗﾒｰﾀの数が一致すること！</remarks>
        public static System.String GetResourceValue(System.String strResourceId, object[] parameters)
        {
            String strResource =  GetResourceValue(strResourceId);
            return String.Format(strResource, parameters);
        }

        /// <summary>
        /// ﾘｿｰｽﾏﾈｰｼﾞｬを作成する
        /// </summary>
        /// <param name="cultureInfo">ｶﾙﾁｬ情報</param>
        /// <returns>ﾘｿｰｽﾏﾈｰｼﾞｬ</returns>
        private static System.Resources.ResourceManager _GetResourceManager(System.Globalization.CultureInfo cultureInfo)
        {
            // ｶﾙﾁｬ情報設定
            System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
           
            // ﾘｿｰｽを含むｱｾﾝﾌﾞﾘを読み込む(BaseDirectoryパス文字列の末尾にパス区切り文字がある場合もない場合もパスとファイル名の間にパス区切り文字を強制的に付与しているが読込に問題はないことを確認済)
            System.Reflection.Assembly asmResource = System.Reflection.Assembly.LoadFile(System.AppDomain.CurrentDomain.BaseDirectory + System.IO.Path.DirectorySeparatorChar + _RESOURCE_FILE);
           
            // ﾘｿｰｽﾏﾈｰｼﾞｬ作成
            return new System.Resources.ResourceManager(_RESOURCE_ROOT, asmResource);
        }
    }
}
