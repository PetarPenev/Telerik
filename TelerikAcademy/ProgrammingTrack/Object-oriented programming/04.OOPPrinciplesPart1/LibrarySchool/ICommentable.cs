using System;
using System.Collections.Generic;

namespace LibrarySchool
{
    // Interface for classes that implement comments
    interface ICommentable
    {
        List<string> Comments
        {
            get;
        }

        void AddComment(string comment);
    }
}
