using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akiyama
{
    public sealed class PasswordValidatorV1
    {
        /// <summary>
        /// パスワードの長さの最小値(最大は定義していない)
        /// </summary>
        private const int MinimumPasswordLength = 8;

        /// <summary>
        /// 新しいパスワードについて、以下のチェックをする。
        /// ・長さが8以上である
        /// ・ユーザー名と同じではない
        /// ・現在のパスワードと同じではない
        /// </summary>
        /// <param name="newPassword">新しいパスワード(の候補)</param>
        /// <param name="userName">ユーザー名(ユーザーID)</param>
        /// <param name="currentPassword">現在のパスワード</param>
        /// <returns>newPasswordが適切かどうか</returns>
        public Boolean IsValid(String newPassword, String userName, String currentPassword)
        {
            if (newPassword.Length < MinimumPasswordLength)
                return false;

            if (newPassword.Equals(userName))
                return false;

            if (newPassword.Equals(currentPassword))
                return false;

            return true;
        }
    }
}
