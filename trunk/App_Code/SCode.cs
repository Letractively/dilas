using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ExtensionMethods
{
    public static class SCode
    {


        #region "取得學期名稱"
        /// <summary>
        /// 取得學期名稱
        /// </summary>
        /// <param name="semesterTerm"></param>
        /// <returns></returns>
        static public string ToScodeSemesterTermName(this string semesterTerm)
        {
            switch (semesterTerm)
            {
                case "0":
                    return "上學期";
                case "1":
                    return "下學期";
                case "2":
                    return "暑假";
                case "3":
                    return "寒假";
                default:
                    return "";
            }
        }
        #endregion


        #region "轉換性別ID to Name,DataTable=People,(True:男，False:女)"
        /// <summary>
        /// 轉換性別ID to Name,DataTable=People,(True:男，False:女)
        /// </summary>
        /// <param name="genderId">性別編號</param>
        /// <returns>性別名稱</returns>
        static public string ToScodeGenderName(this string genderId)
        {
            return genderId == "True" ? "男" : "女";
        }
        #endregion


        #region "身分(0:老師，1:學生，2:家長,3學校管理者,4總管理者),DataTable=People "
        /// <summary>
        /// 身分(0:老師，1:學生，2:家長,3學校管理者,4總管理者),DataTable=People
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns>角色 Name</returns>
        static public string ToScodeRoleName(this string roleId)
        {
            switch (roleId)
            {
                case "0":
                    return "老師";
                case "1":
                    return "學生";
                case "2":
                    return "家長";
                case "3":
                    return "學校管理者";
                case "4":
                    return "總管理者";
                default:
                    return "";
            }
        }
        #endregion

        #region "是否啟用,(0:停用，1:啟用)"
        /// <summary>
        /// 是否啟用,(0:停用，1:啟用)
        /// </summary>
        /// <param name="enableId">ID</param>
        /// <returns>Name</returns>
        static public string ToScodeEnableName(this string enableId)
        {
            return enableId == "True" ? "啟用" : "停用";
        }
        #endregion


        #region "等級(0:正式，1:代課)"
        /// <summary>
        /// 等級(0:正式，1:代課)
        /// </summary>
        /// <param name="rankId">ID</param>
        /// <returns>Name</returns>
        static public string ToScodeRankName(this string rankId)
        {
            return rankId == "True" ? "代課" : "正式";
        }
        #endregion


        #region "教師類型(0:級任老師，1:專任老師)"
        /// <summary>
        /// 教師類型(0:級任老師，1:專任老師)
        /// </summary>
        /// <param name="classifyId"></param>
        /// <returns></returns>
        static public string ToScodeClassifyName(this string classifyId)
        {
            switch (classifyId)
            {
                case "0":
                    return "級任老師";
                case "1":
                    return "專任老師";
                default:
                    return "";
            }
        }
        #endregion

        static public string ToScodeBookCaseURL(this string fileName, string school_id, string people_id)
        {
            return String.Format("{0}/{1}/{2}/{3}", ConfigurationManager.AppSettings["FileUploadPath"], school_id, people_id, fileName);
        }

        #region "書籍類型(0:免費，1:付費，2:圖書館借閱)"
        /// <summary>
        /// 書籍類型(0:免費，1:付費，2:圖書館借閱)
        /// </summary>
        /// <param name="type">type</param>
        /// <returns>Name</returns>
        static public string ToScodeBookTypeName(this string type)
        {
            switch (type)
            {
                case "0":
                    return "免費";
                case "1":
                    return "付費";
                case "2":
                    return "圖書館借閱";
                default:
                    return "";
            }
        }
        #endregion

        #region "公開等級(0:不公開，2:公開)"
        /// <summary>
        /// 公開等級(0:不公開，2:公開)
        /// </summary>
        /// <param name="type">type</param>
        /// <returns>Name</returns>
        static public string ToScodePublicLevelName(this string PublicLevelName)
        {
            switch (PublicLevelName)
            {
                case "0":
                    return "不公開";
                case "2":
                    return "公開";
                default:
                    return "";
            }
        }
        #endregion

        #region "下載狀態(0:尚未下載，2:下載成功)"
        /// <summary>
        /// 下載狀態(0:尚未下載，2:下載成功)
        /// </summary>
        /// <param name="type">type</param>
        /// <returns>Name</returns>
        static public string TocheckDownloadName(this string checkDownload)
        {
            switch (checkDownload)
            {
                case "0":
                    return "尚未下載";
                case "1":
                    return "下載成功";
                default:
                    return "";
            }
        }
        #endregion

        #region "回傳狀態(0:尚未回傳，2:回傳成功)"
        /// <summary>
        /// 回傳狀態(0:尚未回傳，2:回傳成功)
        /// </summary>
        /// <param name="type">type</param>
        /// <returns>Name</returns>
        static public string TocheckUploadName(this string checkUpload)
        {
            switch (checkUpload)
            {
                case "0":
                    return "尚未回傳";
                case "1":
                    return "回傳成功";
                default:
                    return "";
            }
        }
        #endregion

        #region "家長簽名(0:已簽名，2:未簽名)"
        /// <summary>
        /// 回傳狀態(0:尚未回傳，2:回傳成功)
        /// </summary>
        /// <param name="type">type</param>
        /// <returns>Name</returns>
        static public string ToisSignName(this string isSign)
        {
            return isSign == "True" ? "已簽名" : "未簽名";
        }
        #endregion

        #region "回應狀態(0:尚未回傳，2:回傳成功)"
        /// <summary>
        /// 回傳狀態(0:尚未回傳，2:回傳成功)
        /// </summary>
        /// <param name="type">type</param>
        /// <returns>Name</returns>
        static public string ToMessageReplyName(this string checkUpload)
        {
            switch (checkUpload)
            {
                case "0":
                    return "";
                default:
                    return "V";
            }
        }
        #endregion




    }
}

